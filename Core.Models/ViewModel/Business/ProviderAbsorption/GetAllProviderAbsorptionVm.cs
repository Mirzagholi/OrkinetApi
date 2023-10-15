using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Business.ProviderAbsorption
{
    public class GetAllProviderAbsorptionVm : BaseDataResult
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProviderName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
