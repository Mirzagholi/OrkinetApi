using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.Favorite;
using Core.Models.Request.Business.Favorite;
using Core.Models.ViewModel.Business.Favorite;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Http;

namespace Core.Service.Business
{
    public class FavoriteSrv : IFavoriteSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor

        public FavoriteSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;

            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddFavoriteSAsync(AddFavoriteRequest request)
        {
            var response = await _repository.Sp_AddFavorite(
                new AddFavoriteParam()
                {
                    UserId =  HttpContextExtensions.GetUserId().Value,
                    ProductId = request.ProductId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> DeleteFavoriteSAsync(DeleteFavoriteRequest request)
        {
            var response = await _repository.Sp_DeleteFavorite(
                new DeleteFavoriteParam()
                {
                    UserId = HttpContextExtensions.GetUserId().Value,
                    ProductId = request.ProductId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetAllFavoriteUiVm>> GetAllFavoriteUiAsync(GetAllFavoriteUiRequest request)
        {
            var results =
                await _repository.Sp_GetAllFavoriteUi(new GetAllFavoriteUiParam
                {
                    UserId = HttpContextExtensions.GetUserId().Value,
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord
                });

            if (results == null || results?.List == null || results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if(photo != null)
                    result.Photo = photo.Path;
            }
                

            return results;
        }

        #endregion
    }
}
