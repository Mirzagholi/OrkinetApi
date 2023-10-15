using System;
using Core.Common.Base;

namespace Core.Models.ViewModel.Business.ProductComment
{
    public class GetAllProductCommentReplyVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
