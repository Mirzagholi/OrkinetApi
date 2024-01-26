using System;
using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.ViewModel.Business.WebSiteFile
{
    public class GetAllWebSiteFileVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CdnFileId { get; set; }
        public string Path { get; set; }
        public DateTime CreatedOn { get; set; }

        public WebSiteFileGroupType FileGroupTypeId { get; set; }
        public string AltImageFile { get; set; }
        public string MetaDesc { get; set; }
        public string  LinkAddress { get; set; }
        public string TargetLinkType { get; set; }
        public bool IsActive { get; set; }

        public int  Order {  get; set; }    




    }
}