using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingCdn.NetCoreConnector;
using Core.Common.ShareContract;
using Core.DataContract;
using Core.Models.Enum.Common;
using Core.Models.Parameter.Business.Menu;
using Core.Models.ViewModel.Business.Menu;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class MenuSrv : IMenuSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ICdnService _cdnService;

        #endregion Property

        #region Constructor

        public MenuSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ICdnService cdnService)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;

            _cdnService = cdnService ?? throw new ArgumentNullException(nameof(_cdnService));
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetRootMenuBoxVm>> GetRootMenuBoxAsync()
        {
            var results =
                await _repository.Sp_GetRootMenuBox();

            if (results == null || results.Count() == 0)
                return null;

            if (!results.Any(z => z.CdnImageId.HasValue))
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Where(z => z.CdnImageId.HasValue).Select(z => z.CdnImageId.Value).ToArray());

            foreach (var result in results.ToList())
                if (result.CdnImageId.HasValue)
                {
                    var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnImageId.Value);
                    if (photo != null)
                        result.Image = photo.Path;
                }

            return
                results;
        }

        public async Task<IEnumerable<GetSubMenuBoxVm>> GetSubMenuBoxAsync(int id)
        {
            var results =
                await _repository.Sp_GetSubMenuBox(new GetSubMenuBoxParam() { Id = id });

            if (results == null || results.Count() == 0)
                return null;

            if (!results.Any(z => z.CdnImageId.HasValue))
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Where(z => z.CdnImageId.HasValue).Select(z => z.CdnImageId.Value).ToArray());

            foreach (var result in results.ToList())
                if (result.CdnImageId.HasValue)
                {
                    var photo = cdnFiles.FirstOrDefault(z => z.Id == result.CdnImageId.Value);
                    if (photo != null)
                        result.Image = photo.Path;
                }

            return
                results;
        }

        public async Task<IEnumerable<GetLandingMenuVm>> GetLandingMenuAsync()
        {
            var results =
                await _repository.Sp_GetLandingMenu();
            var response = new List<GetLandingMenuVm>();

            if (results == null || results.Count() == 0)
                return null;

            if (!results.Any(z => z.CdnImageId.HasValue))
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Where(z => z.CdnImageId.HasValue).Select(z => z.CdnImageId.Value).ToArray());

            foreach (var item in results.ToArray())
            {
                if (item.CdnImageId.HasValue)
                {
                    var photo = cdnFiles.FirstOrDefault(z => z.Id == item.CdnImageId.Value);
                    if (photo != null)
                        item.Image = photo.Path;
                }

                if (item.ParentId == null)
                    response.Add(item);
                else
                    response.FirstOrDefault(z => z.Id == item.ParentId && z.MenuTypeId == item.MenuTypeId)?.SubMenu.Add(item);
            }
            return response;
        }

        public async Task<IEnumerable<MainMenuVm>> GetMainMenuAsync()
        {
            var results =
                await _repository.Sp_GetMainMenu(new GetMainMenuParam() { IsActiveOnly = true, MenuTypeId = (int)MenuType.Modern  });
            var response = new List<MainMenuVm>();

            if (results == null || results.Count() == 0)
                return null;

            if (!results.Any(z => z.CdnImageId.HasValue))
                return results;

            var cdnFiles = await _cdnService.GetCdnManyFilePathAsync(results.Where(z => z.CdnImageId.HasValue).Select(z => z.CdnImageId.Value).ToArray());

            foreach (var item in results.ToArray())
            {
                if (item.CdnImageId.HasValue)
                {
                    var photo = cdnFiles.FirstOrDefault(z => z.Id == item.CdnImageId.Value);
                    if (photo != null)
                        item.Image = photo.Path;
                }

                if (item.ParentId == null)
                    response.Add(item);
                else
                    response.FirstOrDefault(z => z.Id == item.ParentId && z.MenuTypeId == item.MenuTypeId)?.SubMenu.Add(item);
            }
            return response;
        }

        #endregion
    }
}
