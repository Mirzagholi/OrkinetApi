using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Enum.Common;
using Core.Models.Parameter.Business.Category;
using Core.Models.Parameter.Business.Menu;
using Core.Models.Parameter.Business.SideBar;
using Core.Models.Request.Business.Category;
using Core.Models.ViewModel.Business.Menu;
using Core.Models.ViewModel.Business.SideBar;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Http;

namespace Core.Service.Business
{
    public class SideBarSrv : ISideBarSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        #endregion Property

        #region Constructor

        public SideBarSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<GetLandingSideBarVm>> GetLandingSideBarAsync(int menuId)
        {
            var results =
                await _repository.Sp_GetLandingSideBar(new GetLandingSideBarParam { MenuId = menuId });
            var response = new List<GetLandingSideBarVm>();

            foreach (var item in results.ToArray())
            {
                if (item.ParentId == null)
                {
                    response.Add(item);
                }
                else
                {
                    response.FirstOrDefault(z => z.Id == item.ParentId && z.SideBarTypeId == item.SideBarTypeId)?.SubSideBar.Add(item);
                }
            }
            return response;
        }

        #endregion
    }
}
