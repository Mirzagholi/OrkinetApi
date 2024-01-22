using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Enum.Common;
using Core.Models.Parameter.Business.Category;
using Core.Models.Request.Business.Category;
using Core.Models.ViewModel.Business.Category;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Http;

namespace Core.Service.Business
{
    public class CategorySrv : ICategorySrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        #endregion Property

        #region Constructor

        public CategorySrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddCategoryAsync(AddCategoryRequest request)
        {
            AddCategoryVm response = await _repository.Sp_AddCategory(
                new AddCategoryParam()
                {
                    Name = request.Name.Trim(),
                    ParentId = request.ParentId,
                    Order = request.Order ?? 1,
                    Icon = request.Icon,
                    StatusId = (int)StatusType.Active,
                    Description = request.Description,
                    ShowInFirstPage = request.ShowInFirstPage
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            UpdateCategoryVm response = await _repository.Sp_UpdateCategory(
                new UpdateCategoryParam()
                {
                    Id = request.Id,
                    Name = request.Name,
                    ParentId = request.ParentId,
                    Order = request.Order ?? 1,
                    Icon = request.Icon,
                    Description = request.Description,
                    ShowInFirstPage = request.ShowInFirstPage
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> UpdateCategoryStatusAsync(UpdateCategoryStatusRequest request)
        {
            UpdateCategoryStatusVm response = await _repository.Sp_UpdateCategoryStatus(
                new UpdateCategoryStatusParam()
                {
                    Id = request.Id,
                    StatusId = request.StatusId
                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<GetCategoryByIdVm> GetCategoryByIdAsync(int id) => await _repository.Sp_GetCategoryById(new GetCategoryByIdParam() { Id = id });

        public async Task<IEnumerable<GetCategoryVm>> GetCategoryAsync() => await _repository.Sp_GetCategory();

        public async Task<IEnumerable<GetCategoryVm>> GetCategoryInFirstPageAsync() => await _repository.Sp_GetCategoryInFirstPage();

        public async Task<IEnumerable<GetCategoryDropDownVm>> GetCategoryDropDownAsync() => await _repository.Sp_GetCategoryDropDown();

        #endregion
    }
}
