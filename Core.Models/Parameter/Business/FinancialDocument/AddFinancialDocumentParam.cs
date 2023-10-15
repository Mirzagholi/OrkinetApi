using Core.Common.Base;
using System;
using System.Data;

namespace Core.Models.Parameter.Business.FinancialDocument
{
    public class AddFinancialDocumentParam : BaseParam
    {
        public string Name { get; set; }
        public DateTime EndOn { get; set; }
        public int CreatedById { get; set; }
    }
}
