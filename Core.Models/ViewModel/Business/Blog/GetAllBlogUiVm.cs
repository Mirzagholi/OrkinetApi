using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Business.Blog
{
    public class GetAllBlogUiVm : BaseDataResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CdnFileId { get; set; }

        public string Photo { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
