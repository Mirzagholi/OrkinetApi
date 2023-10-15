using System;
using System.Collections.Generic;
using Core.Common.Base;

namespace Core.Models.ViewModel.Business.ProductComment
{
    public class GetAllProductCommentUiVm : BaseDataResult
    {
        public GetAllProductCommentUiVm()
        {
            Replies = new List<GetAllProductCommentUiVm>();
        }

        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int? ReplyId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<GetAllProductCommentUiVm> Replies { get; set; }
    }
}
