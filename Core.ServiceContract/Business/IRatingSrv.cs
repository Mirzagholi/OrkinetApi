using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Rating;

namespace Core.ServiceContract.Business
{
    public interface IRatingSrv : IInjectableService
    {
        Task<ServiceResult> UpdateProductRatingAsync(UpdateProductRatingRequest request);
        Task<ServiceResult> UpdateProviderRatingAsync(UpdateProviderRatingRequest request);
    }
}
