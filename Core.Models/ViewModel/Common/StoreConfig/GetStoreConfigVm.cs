using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Common.StoreConfig
{
    public class GetStoreConfigVm : BaseDataResult
    {
        public int Id { get; set; }
        public TimeSpan StartOn { get; set; }
        public TimeSpan EndOn { get; set; }
    }
}
