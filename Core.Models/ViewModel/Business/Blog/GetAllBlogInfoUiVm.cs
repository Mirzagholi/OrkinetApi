using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Business.Blog
{
    public class GetAllBlogInfoUiVm : BaseDataResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int CdnFileId { get; set; }

        public string Photo { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
