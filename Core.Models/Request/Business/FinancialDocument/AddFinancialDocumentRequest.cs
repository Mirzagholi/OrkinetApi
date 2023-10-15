using Core.Common.Base;
using System;

namespace Core.Models.Request.Business.FinancialDocument
{
    public class AddFinancialDocumentRequest : BaseRequest
    {
        /// <summary>
        /// نام سند
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// تاریخ پایان سند
        /// </summary>
        public DateTime EndOn { get; set; }
    }
}
