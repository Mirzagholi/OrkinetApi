
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Common.Base;
using Dapper;

namespace Core.DataContract
{
    public interface IContext : IDisposable
    {

        #region Synchronize
        int Execute(string sp, object param);

        int Execute(string sp, object param, int timeout);

        T Get<T>(string sp, object param);

        T Get<T>(string sp, object param, int timeout);

        T Scaler<T>(string sp, object param);

        T Scaler<T>(string sp, object param, int timeout);

        IEnumerable<T> Select<T>(string sp, object param);

        IEnumerable<T> Select<T>(string sp, object param, int timeout);

        SqlMapper.ICustomQueryParameter GetTvp<T>(IEnumerable<T> models, string type);

        #endregion Synchronize

        #region Asynchronous

        Task<int> ExecuteAsync(string sp);

        Task<int> ExecuteAsync(string sp, object param);

        Task<int> ExecuteAsync(string sp, object param, int timeout);

        Task<IEnumerable<T>> GetManyAsync<T>(object param);

        Task<IEnumerable<T>> GetManyAsync<T>(string sp);

        Task<IEnumerable<T>> GetManyAsync<T>(string sp, object param);

        Task<IEnumerable<T>> GetManyAsync<T>(string sp, object param, int timeout);

        Task<BasePagingResult<T>> GetManyWithPagingAsync<T>(string sp, object param, int timeout = 0);

        Task<BasePagingResult<T>> GetManyWithPagingAsync<T>(string sp, int timeout = 0);

        Task<BaseProductPagingResult<T, Y, N, M, Z>> GetManyProductWithPagingAsync<T, Y, N, M, Z>(string sp, object param, int timeout = 0);

        Task<BaseProductPagingResult<T, Y, N, M, Z>> GetManyProductWithPagingAsync<T, Y, N, M, Z>(string sp, int timeout = 0);

        Task<BaseProductDetailResult<T>> GetManyProductDetailAsync<T>(string sp, object param, int timeout = 0);

        Task<BaseProductDetailResult<T>> GetManyProductDetailAsync<T>(string sp, int timeout = 0);

        Task<BaseCartInfoResult<T, Y>> GetManyCartInfoAsync<T, Y>(string sp, object param, int timeout = 0);

        Task<BaseCartInfoResult<T, Y>> GetManyCartInfoAsync<T, Y>(string sp, int timeout = 0);

        Task<BaseDoubleResult<T, Y>> GetDoubleAsync<T, Y>(string sp, object param, int timeout = 0);

        Task<BaseDoubleResult<T, Y>> GetDoubleAsync<T, Y>(string sp, int timeout = 0);

        Task<BaseFifthResult<T, Y, N, M, Z>> GetFifthAsync<T, Y, N, M, Z>(string sp, object param, int timeout = 0);

        Task<BaseFifthResult<T, Y, N, M, Z>> GetFifthAsync<T, Y, N, M, Z>(string sp, int timeout = 0);

        Task<T> GetAsync<T>(object param);

        Task<T> GetAsync<T>(string sp);

        Task<T> GetAsync<T>(string sp, object param);

        Task<T> GetAsync<T>(string sp, object param, int timeout);
        
        Task<T> ScalerAsync<T>(string sp, object param);

        Task<T> ScalerAsync<T>(string sp, object param, int timeout);

        Task<IEnumerable<T>> SelectAsync<T>(string sp, object param);

        Task<IEnumerable<T>> SelectAsync<T>(string sp, object param, int timeout);

        #endregion Asynchronous

    }
}
