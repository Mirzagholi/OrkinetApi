using System;
using Core.Common.Base;

namespace Core.Models.ViewModel.Business.ProductComment
{
    public class GetAllProductCommentVm : BaseDataResult
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFullName => $"{UserFirstName} {UserLastName}";
        public string Text { get; set; }
        public string ConfirmStatus { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
