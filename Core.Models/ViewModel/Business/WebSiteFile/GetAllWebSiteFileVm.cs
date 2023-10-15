using System;
using Core.Common.Base;

namespace Core.Models.ViewModel.Business.WebSiteFile
{
    public class GetAllWebSiteFileVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CdnFileId { get; set; }
        public string Path { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}