using System;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using BingCdn.NetCoreConnector.Common.Helper.ServiceResponse;
using BingCdn.NetCoreConnector.Dto.Cdn.CdnDeleteFile;
using BingCdn.NetCoreConnector.Dto.Cdn.CdnUploadFile;
using Core.Common.Base;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.WebSiteFile;
using Core.Models.Request.Business.WebSiteFile;
using Core.Models.ViewModel.Business.WebSiteFile;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class WebSiteFileSrv : IWebSiteFileSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor


        public WebSiteFileSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddWebSiteFileAsync(AddWebSiteFileRequest request)
        {
            var cdnResponse = await _cdnService.CdnUploadFileAsync(new CdnUploadFileRequestDto { File = request.File });

            if (cdnResponse.ResultCode != (int)ServiceResponseKey.Cdn_UploadSuccess)
                return null;

            await _repository.Sp_AddWebSiteFile(
                new AddWebSiteFileParam()
                {
                    Title = request.Title.Trim(),
                    CdnFileId = cdnResponse.FileId
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<BasePagingResult<GetAllWebSiteFileVm>> GetAllWebSiteFileAsync(GetAllWebSiteFileRequest request)
        {
            var results =
                await _repository.Sp_GetAllWebSiteFile(new GetAllWebSiteFileParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });

            if (results != null && results.List.Count() > 0)
            {
                var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

                foreach (var result in results.List.ToList())
                    result.Path = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId).Path;
            }

            return new BasePagingResult<GetAllWebSiteFileVm>()
            {
                List = results.List,
                TotalCount = results.TotalCount
            };
        }

        public async Task<ServiceResult> DeleteWebSiteFileAsync(DeleteWebSiteFileRequest request)
        {
            var result = await _repository.Sp_DeleteWebSiteFile(new DeleteWebSiteFileParam{ Id = request.Id });

            await _cdnService.CdnDeleteFileAsync(new CdnDeleteFileRequestDto { Id = result.CdnFileId });

            return _serviceResultHelper.Response(null);
        }

        #endregion
    }
    }
