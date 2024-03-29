﻿using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetCheapestProductUiVm>> Sp_GetCheapestProductUi(GetCheapestProductUiParam parameters) => await _context.GetManyWithPagingAsync<GetCheapestProductUiVm>
            (
                "Business.sp_GetCheapestProductUi",
                parameters
            );


        public async Task<BasePagingResult<GetFirstPageProductUiVm>> Sp_GetFirstPageProductUi(GetFirstPageProductUiParam parameters) => await _context.GetManyWithPagingAsync<GetFirstPageProductUiVm>
            (
                "Business.sp_GetFirstPageProductUi",
                parameters
            );

        

    }

}
