using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.Data.DataHelpers;
using Core.DataContract;
using Core.Models.Parameter.Business.Product;
using Core.Models.Request.Business.Product;
using Core.Models.ViewModel.Business.Product;
using Core.Models.ViewModel.Business.Product.GetProviderProductById;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProductSrv : IProductSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor

        public ProductSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;

            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddProductAsync(AddProductRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_AddProduct(
                new AddProductParam()
                {
                    Name = request.Name.Trim(),
                    CategoryIdes = (request.CategoryIdes ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    ProviderId = providerId,
                    PreparationTypeId = request.PreparationTypeId,
                    Price = request.Price,
                    ValueIdes = (request.ValueIdes ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    PrivateValueIdes = (request.PrivateValueIdes ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    ProviderGalleryIdes = (request.ProviderGalleryIdes ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    ShortDescription = request.ShortDescription,
                    Description = request.Description

                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<BasePagingResult<GetProductVm>> GetProductAsync(GetProductRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var results = await _repository.Sp_GetProduct(new GetProductParam
            {
                ProviderId = providerId,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });

            foreach (var item in results.List)
            {
                item.ProductAttrVal =
                    results.List1.Where(z => z.ProductId == item.Id).ToList();
                item.ProductPrivateAttrVal =
                    results.List2.Where(z => z.ProductId == item.Id).ToList();
                item.ProductPhoto =
                    results.List3.Where(z => z.ProductId == item.Id).ToList();
                if (item.ProductPhoto.Count() > 0)
                {
                    var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(item.ProductPhoto.Select(z => z.CdnFileId).ToArray());
                    foreach (var result in item.ProductPhoto.ToList())
                    {
                        var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                        if (photo != null)
                            result.Photo = photo.Path;
                    }
                }
                item.ProductCategory =
                    results.List4.Where(z => z.ProductId == item.Id).ToList();
            }

            return new BasePagingResult<GetProductVm>()
            {
                List = results.List,
                TotalCount = results.TotalCount
            };
        }

        public async Task<ServiceResult> UpdateProductAsync(UpdateProductRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProduct(
                new UpdateProductParam()
                {
                    Id = request.Id,
                    Name = request.Name.Trim(),
                    CategoryIdes = (request.CategoryIdes ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    ProviderId = providerId,
                    PreparationTypeId = request.PreparationTypeId,
                    Values = (request.Values ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    PrivateValues = (request.PrivateValues ?? Array.Empty<string>()).
                        ToList().MapToIdesStrSqlType().ToDataTable(),
                    ShortDescription = request.ShortDescription,
                    Description = request.Description
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateProductStatusAsync(UpdateProductStatusRequest request)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;
            var response = await _repository.Sp_UpdateProductStatus(
                new UpdateProductStatusParam()
                {
                    Id = request.Id,
                    ProviderId = providerId,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<IEnumerable<GetProductDropDownVm>> GetProductDropDownAsync()
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            return
                await _repository.Sp_GetProductDropDown(new GetProductDropDownParam() { ProviderId = providerId });
        }

        public async Task<IEnumerable<GetLandingDiscountedProductVm>> GetLandingDiscountedProductAsync()
        {
            var results =
                await _repository.Sp_GetLandingDiscountedProduct();

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<IEnumerable<GetLandingEconomicProductVm>> GetLandingEconomicProductAsync()
        {
            var results =
                await _repository.Sp_GetLandingEconomicProduct();

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<IEnumerable<GetLandingMostSalesProductVm>> GetLandingMostSalesProductAsync(GetProductByCategoryIdRequest parameters)
        {
            var results =
                await _repository.Sp_GetLandingMostSalesProduct(parameters);

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }
            return results;
        }

        public async Task<IEnumerable<GetLandingVipProductVm>> GetLandingVipProductAsync()
        {
            var results =
                await _repository.Sp_GetLandingVipProduct();

            if (results == null || results.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }
            return results;
        }

        public async Task<BasePagingResult<GetAllProductUiVm>> GetAllProductUiAsync(GetAllProductUiRequest request)
        {
            var results =
                await _repository.Sp_GetAllProductUi(new GetAllProductUiParam
                {
                    MenuId = request.MenuId,
                    StartingPrice = request.StartingPrice,
                    EndingPrice = request.EndingPrice,
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    ProviderIdes = (request.ProviderIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                    SideBarIdes = (request.SideBarIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                });

            if (results == null || results?.List == null|| results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<BasePagingResult<GetDiscountedProductUiVm>> GetDiscountedProductUiAsync(GetDiscountedProductUiRequest request)
        {
            var results =
                await _repository.Sp_GetDiscountedProductUi(new GetDiscountedProductUiParam
                {
                    MenuId = request.MenuId,
                    StartingPrice = request.StartingPrice,
                    EndingPrice = request.EndingPrice,
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    ProviderIdes = (request.ProviderIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                    SideBarIdes = (request.SideBarIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                });

            if (results == null || results?.List == null || results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }
            return results;
        }

        public async Task<BasePagingResult<GetNewestProductUiVm>> GetNewestProductUiAsync(GetNewestProductUiRequest request)
        {
            var results =
                await _repository.Sp_GetNewestProductUi(new GetNewestProductUiParam
                {
                    MenuId = request.MenuId,
                    StartingPrice = request.StartingPrice,
                    EndingPrice = request.EndingPrice,
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    ProviderIdes = (request.ProviderIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                    SideBarIdes = (request.SideBarIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                });

            if (results == null || results?.List == null || results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<BasePagingResult<GetExpensiveProductUiVm>> GetExpensiveProductUiAsync(GetExpensiveProductUiRequest request)
        {
            var results =
                await _repository.Sp_GetExpensiveProductUi(new GetExpensiveProductUiParam
                {
                    MenuId = request.MenuId,
                    StartingPrice = request.StartingPrice,
                    EndingPrice = request.EndingPrice,
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    ProviderIdes = (request.ProviderIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                    SideBarIdes = (request.SideBarIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                });

            if (results == null || results?.List == null || results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            return results;
        }

        public async Task<BasePagingResult<GetCheapestProductUiVm>> GetCheapestProductUiAsync(GetCheapestProductUiRequest request)
        {
            var results =
                await _repository.Sp_GetCheapestProductUi(new GetCheapestProductUiParam
                {
                    MenuId = request.MenuId,
                    StartingPrice = request.StartingPrice,
                    EndingPrice = request.EndingPrice,
                    PageNumber = request.PageNumber,
                    PageRecord = request.PageRecord,
                    ProviderIdes = (request.ProviderIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                    SideBarIdes = (request.SideBarIdes ?? Array.Empty<string>()).
                    ToList().MapToIdesStrSqlType().ToDataTable(),
                });

            if (results == null || results?.List == null || results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }
            return results;
        }

        public async Task<GetProductDetailUiVm> GetProductDetailUiAsync(GetProductDetailUiRequest request)
        {
            var result =
                await _repository.Sp_GetProductDetailUi(new GetProductDetailUiParam { ProductId = request.ProductId });

            if (result == null)
                return null;

            if (result.CdnFileIdes == null || result.CdnFileIdes.Count() == 0)
                return result.Product;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(result.CdnFileIdes.ToArray());

            foreach (var fileId in result.CdnFileIdes)
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == fileId);
                if (photo != null)
                    result.Product.Photo.Add(photo.Path);
            }

            return
                result.Product;
        }

        public async Task<IEnumerable<CheckProductForCartVm>> CheckProductForCartAsync(List<CheckProductForCartRequest> request)
        {
            var response = 
                    await _repository.Sp_CheckProductForCart(new CheckProductForCartParam
                    {
                        Products = request.MapToCheckCartProductDataSqlType().ToDataTable()
                    });

            return response;
        }

        public async Task<BasePagingResult<GetAllProductForAdminVm>> GetAllProductForAdminAsync(GetAllProductForAdminRequest request)
        {
            var results = await _repository.Sp_GetAllProductForAdmin(new GetAllProductForAdminParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });

            foreach (var item in results.List)
            {
                item.ProductAttrVal =
                    results.List1.Where(z => z.ProductId == item.Id).ToList();
                item.ProductPrivateAttrVal =
                    results.List2.Where(z => z.ProductId == item.Id).ToList();
                item.ProductPhoto =
                    results.List3.Where(z => z.ProductId == item.Id).ToList();
                item.ProductCategory =
                    results.List4.Where(z => z.ProductId == item.Id).ToList();
            }

            return new BasePagingResult<GetAllProductForAdminVm>()
            {
                List = results.List,
                TotalCount = results.TotalCount
            };
        }

        public async Task<ServiceResult> ConfirmProductAsync(ConfirmProductRequest request)
        {
            await _repository.Sp_ConfirmProduct(
                new ConfirmProductParam()
                {
                    ProductId = request.ProductId
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<GetProviderProductByIdVm> GetProviderProductByIdAsync(int id)
        {
            var providerId = HttpContextExtensions.GetProviderId().Value;

            var results = await _repository.Sp_GetAdminProductById(
                new GetProviderProductByIdParam 
                { 
                    Id = id,
                    ProviderId = providerId
                });

            var response = results.List1.FirstOrDefault();
            response.ProductAttrVal = results.List2.ToList();
            response.ProductPrivateAttrVal = results.List3.ToList();
            response.ProductPhoto = results.List4.ToList();

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(response.ProductPhoto.Select(z => z.CdnFileId).ToArray());
            foreach (var result in response.ProductPhoto.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }

            response.ProductCategory = results.List5.ToList();

            return response;
        }


        public async Task<BasePagingResult<GetFirstPageProductUiVm>> GetFirstPageProductUiAsync(GetFirstPageProductUiRequest request)
        {
            var results =
                await _repository.Sp_GetFirstPageProductUi(new GetFirstPageProductUiParam
                {
                    CategoryId = request.CategoryId,
                    ProductListTypeId = request.ProductListTypeId,
                    PageRecord = request.PageRecord,

                    
                });

            if (results == null || results?.List == null || results?.List.Count() == 0)
                return null;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.List.Select(z => z.CdnFileId).ToArray());

            foreach (var result in results?.List.ToList())
            {
                var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnFileId);
                if (photo != null)
                    result.Photo = photo.Path;
            }
            return results;
        }
        

        #endregion
    }
}
