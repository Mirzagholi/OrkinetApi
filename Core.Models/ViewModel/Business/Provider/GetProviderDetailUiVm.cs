using Core.Common.Base;
using System.Collections.Generic;

namespace Core.Models.ViewModel.Business.Provider
{
    public class GetProviderDetailUiVm : BaseDataResult
    {
        public GetProviderDetailUiVm()
        {
            Photos = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Rating { get; set; }
        public List<string> Photos { get; set; }
    }
}
