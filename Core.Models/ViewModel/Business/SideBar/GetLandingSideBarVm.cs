using System.Collections.Generic;
using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.ViewModel.Business.SideBar
{
    public class GetLandingSideBarVm : BaseDataResult
    {
        public GetLandingSideBarVm()
        {
            SubSideBar = new List<GetLandingSideBarVm>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public SideBarType SideBarTypeId { get; set; }
        public int? ParentId { get; set; }
        public List<GetLandingSideBarVm> SubSideBar { get; set; }
    }
}
