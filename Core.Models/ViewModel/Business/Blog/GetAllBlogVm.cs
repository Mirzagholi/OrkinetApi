using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;
using System;

namespace Core.Models.ViewModel.Business.Blog
{
    public class GetAllBlogVm : BaseDataResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int ViewCount { get; set; }

        public int CdnFileId { get; set; }

        public string Photo { get; set; }

        public StatusType StatusId { get; set; }

        public string StatusText => StatusId.GetStatusTextByCulture();

        public DateTime CreatedOn { get; set; }
    }
}
