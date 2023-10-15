using Core.Common.Extensions;
using Core.Data.Context;
using Core.Data.Repository;
using Core.DataContract;
using Core.ServiceContract.Security;
using Core.Service.Security;
using Microsoft.Extensions.DependencyInjection;
using Core.Common.ShareContract;
using Core.Common.Helpers;
using Core.Service.Base;
using Core.Service.Business;
using Core.Service.Common;
using Core.ServiceContract.Base;
using Core.ServiceContract.Business;
using Core.ServiceContract.Common;
using Microsoft.AspNetCore.Http;
using Core.ServiceContract.Security.Jwt;
using Core.Service.Security.Jwt;
using Core.Common.Settings;
using BingCdn.NetCoreConnector.Model;
using BingCdn.NetCoreConnector.Config;

namespace Core.Ioc
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, SiteSettings siteSettings)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IServiceResultHelper, ServiceResultHelper>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserSrv, UserSrv>();
            services.AddScoped<IRoleSrv, RoleSrv>();
            services.AddScoped<IUserRoleSrv, UserRoleSrv>();
            services.AddScoped<IAntiForgeryCookieService, AntiForgeryCookieService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ITokenFactoryService, TokenFactoryService>();
            services.AddScoped<ITokenStoreService, TokenStoreService>();
            services.AddScoped<ITokenValidatorService, TokenValidatorService>();
            services.AddScoped<ICategorySrv, CategorySrv>();
            services.AddScoped<IAttributeSrv, AttributeSrv>();
            services.AddScoped<IValueSrv, ValueSrv>();
            services.AddScoped<IProviderSrv, ProviderSrv>();
            services.AddScoped<IRegionSrv, RegionSrv>();
            services.AddScoped<IProviderContactSrv, ProviderContactSrv>();
            services.AddScoped<IPrivateAttributeSrv, PrivateAttributeSrv>();
            services.AddScoped<IPrivateValueSrv, PrivateValueSrv>();
            services.AddScoped<IProviderGallerySrv, ProviderGallerySrv>();
            services.AddScoped<IProductSrv, ProductSrv>();
            services.AddScoped<IProductPriceSrv, ProductPriceSrv>();
            services.AddScoped<IProductPhotoSrv, ProductPhotoSrv>();
            services.AddScoped<IProductDiscountSrv, ProductDiscountSrv>();
            services.AddScoped<IProductDeliverySrv, ProductDeliverySrv>();
            services.AddScoped<IContactUsSrv, ContactUsSrv>();
            services.AddScoped<IUserAddressSrv, UserAddressSrv>();
            services.AddScoped<IProvinceSrv, ProvinceSrv>();
            services.AddScoped<ICitySrv, CitySrv>();
            services.AddScoped<IDistrictSrv, DistrictSrv>();
            services.AddScoped<ICartSrv, CartSrv>();
            services.AddScoped<IFavoriteSrv, FavoriteSrv>();
            services.AddScoped<ISmsSrv, SmsSrv>();
            services.AddScoped<IMenuSrv, MenuSrv>();
            services.AddScoped<ISideBarSrv, SideBarSrv>();
            services.AddScoped<IInquiryHubSrv, InquiryHubSrv>();
            services.AddScoped<IPostalCartSrv, PostalCartSrv>();
            services.AddScoped<ICartDeliveryTypeSrv, CartDeliveryTypeSrv>();
            services.AddScoped<ICartDeliveryPlaceTypeSrv, CartDeliveryPlaceTypeSrv>();
            services.AddScoped<ICartFailedDeliveryTypeSrv, CartFailedDeliveryTypeSrv>();
            services.AddScoped<IStoreConfigSrv, StoreConfigSrv>();
            services.AddScoped<IRatingSrv, RatingSrv>();
            services.AddScoped<IProductCommentSrv, ProductCommentSrv>();
            services.AddScoped<IIndexSrv, IndexSrv>();
            services.AddScoped<IProviderAbsorptionSrv, ProviderAbsorptionSrv>();
            services.AddScoped<IBlogSrv, BlogSrv>();
            services.AddScoped<IProviderPhotoSrv, ProviderPhotoSrv>();
            services.AddScoped<IWebSiteFileSrv, WebSiteFileSrv>();
            services.AddScoped<IFinancialDocumentSrv, FinancialDocumentSrv>();

            
            services.AddCdnServices(new CdnInitialData
            {
                CdnUrl = siteSettings.CdnConfig.Url,
                Username = siteSettings.CdnConfig.Username,
                Password = siteSettings.CdnConfig.Password
            });

            string sqlConnection = siteSettings.SqlServer.ConnectionStrings.DefaultConnection;
            int sqlTimeout = siteSettings.SqlServer.Timeout;

            services.AddScoped<IContext>(x => new Context(sqlConnection, sqlTimeout));

            //services.AddScoped<IUserSrv, UserSrv>();

            //List<Assembly> assemblies = new List<Assembly>();
            //Parallel.ForEach(assemblies, assembly =>
            //{
            //    List<Type> types = assembly.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IInjectableService))).ToList();

            //    types.Union<Type>(assembly.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IInjectableData))));

            //    Parallel.ForEach(types, type => services.AddScoped(type));
            //});

            //string sqlConnection = configuration["SqlServer:ConnectionStrings:DefaultConnection"];
            //int sqlTimeout = int.Parse(configuration["SqlServer:Timeout"]);

            //services.AddScoped<IContext>(x => new Context(sqlConnection, sqlTimeout));

            var sp = services.BuildServiceProvider();
            var accessor = sp.GetService<IHttpContextAccessor>();
            HttpContextExtensions.SetHttpContextAccessor(accessor);
            return services;
        }
    }
}
