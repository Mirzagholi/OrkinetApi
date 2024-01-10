using System.Collections.Generic;
using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.ViewModel.Business.Menu
{ 
    
    public class GetLandingMenuVm : BaseDataResult
    {
        public GetLandingMenuVm()
        {
            SubMenu = new List<GetLandingMenuVm>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public int? CdnImageId { get; set; }
        public MenuType MenuTypeId { get; set; }
        public int? ParentId { get; set; }
        public List<GetLandingMenuVm> SubMenu { get; set; }
    }


    public class MainMenuVm : BaseDataResult
    {
        public MainMenuVm()
        {
            SubMenu = new List<MainMenuVm>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public int? CdnImageId { get; set; }
        public MenuType MenuTypeId { get; set; }
        public int? ParentId { get; set; }

        public string LinkAddress { get; set; }
        public string TargetLinkType { get; set; }
        public string SubMenuContent { get; set; }
        public bool Active { get; set; }
        
        public List<MainMenuVm> SubMenu { get; set; }
    }

}
