using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using BingCdn.NetCoreConnector.Common.Helper.ServiceResponse;
using BingCdn.NetCoreConnector.Dto.Cdn.CdnUploadFile;
using Core.Common.Base;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Blog;
using Core.Models.Request.Business.Blog;
using Core.Models.ViewModel.Business.Blog;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class BlogSrv : IBlogSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor

        public BlogSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
            _cdnService = cdnService;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddBlogAsync(AddBlogRequest request)
        {
            var cdnResponse = await _cdnService.CdnUploadFileAsync(new CdnUploadFileRequestDto { File = request.File });

            if (cdnResponse.ResultCode != (int)ServiceResponseKey.Cdn_UploadSuccess || cdnResponse.FileId == 0)
                return null;

            await _repository.Sp_AddBlog(
                new AddBlogParam()
                {
                    Title = request.Title.Trim(),
                    CdnFileId = cdnResponse.FileId,
                    Text = request.Text
                });

            return _serviceResultHelper.Response(null);
        }

        //TODO: ...
        public async Task<ServiceResult> UpdateBlogAsync(UpdateBlogRequest request)
        {
            //var cdnResponse = await _cdnService.CdnUploadFileAsync(new CdnUploadFileRequestDto { File = request.File });

            //if (cdnResponse.ResultCode != (int)ServiceResponseKey.Cdn_UploadSuccess || cdnResponse.FileId == 0)
            //    return null;

            //await _repository.Sp_AddBlog(
            //    new AddBlogParam()
            //    {
            //        Title = request.Title.Trim(),
            //        CdnFileId = cdnResponse.FileId,
            //        Text = request.Text
            //    });

            return _serviceResultHelper.Response(null);
        }

        //TODO: ...
        public async Task<ServiceResult> DeleteBlogAsync(DeleteBlogRequest request)
        {
            
            //var cdnResponse = await _cdnService.CdnDeleteFileAsync(new CdnUploadFileRequestDto { File = request.File });

            //if (cdnResponse.ResultCode != (int)ServiceResponseKey.Cdn_UploadSuccess || cdnResponse.FileId == 0)
            //    return null;

            //await _repository.Sp_AddBlog(
            //    new AddBlogParam()
            //    {
            //        Title = request.Title.Trim(),
            //        CdnFileId = cdnResponse.FileId,
            //        Text = request.Text
            //    });

            return _serviceResultHelper.Response(null);
        }

        /// <summary>
        /// GetAllBlogAsync 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<BasePagingResult<GetAllBlogVm>> GetAllBlogAsync(GetAllBlogRequest request)
        {
            var results =
                await _repository.Sp_GetAllBlog(new GetAllBlogParam
                {
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    SortColumn = request.SortColumn,
                    SortOrder = request.SortOrder
                });

            if (results == null || results.List.Count() == 0)
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        /// <summary>
        /// GetAllBlogUiAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetAllBlogUiVm>> GetAllBlogUiAsync()
        {
            var results =
                await _repository.Sp_GetAllBlogUi();

            if (results == null || results.Count() == 0)
                return results;
            var ids = results.Select(z => z.CdnFileId).ToArray();
            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(ids);

            foreach (var result in results.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<GetAllBlogInfoUiVm> GetAllBlogInfoUiAsync(int id)
        {
            var result =
                await _repository.Sp_GetAllBlogInfoUi(new GetAllBlogInfoUiParam { Id = id });

            if (result == null)
                return result;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(new List<int> { result.CdnFileId }.ToArray());

            var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
            if (photo != null)
                result.Photo = photo.Path;

            return result;
        }


        #endregion

    }
}
