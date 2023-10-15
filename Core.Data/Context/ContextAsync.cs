using Core.Common.Helpers;
using Core.DataContract;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Base;

namespace Core.Data.Context
{
    public partial class Context : IContext
    {
        public async Task<int> ExecuteAsync(string sp)
        {
            return await this.ExecuteAsync(sp, null, this._timeout);
        }

        public async Task<int> ExecuteAsync(string sp, object param)
        {
            return await this.ExecuteAsync(sp, param, this._timeout);
        }

        public async Task<int> ExecuteAsync(string sp, object param, int timeout)
        {
            return await this._db.ExecuteAsync(sp, param, null, timeout, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> GetManyAsync<T>(object param)
        {
            var spAttrs = ReflectionHelper.GetSpAttribute(param.GetType());
            var spName = spAttrs.SpName;

            return await this.GetManyAsync<T>(spName, param, this._timeout);
        }

        public async Task<IEnumerable<T>> GetManyAsync<T>(string sp, object param)
        {
            return await this.GetManyAsync<T>(sp, param, this._timeout);
        }

        public async Task<IEnumerable<T>> GetManyAsync<T>(string sp, object param, int timeout)
        {
            return await this._db.QueryAsync<T>(sp, param,commandTimeout : timeout, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> GetManyAsync<T>(string sp)
        {
            return await this._db.QueryAsync<T>(sp, CommandType.StoredProcedure);
        }

        public async Task<BasePagingResult<T>> GetManyWithPagingAsync<T>(string sp, object param, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, param, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data = await multipleResult.ReadAsync<T>();
            var totalCount = multipleResult.Read<int>().FirstOrDefault();

            return new BasePagingResult<T>() { List = data, TotalCount = totalCount };
        }

        public async Task<BasePagingResult<T>> GetManyWithPagingAsync<T>(string sp, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data = multipleResult.Read<T>();
            var totalCount = multipleResult.Read<int>().FirstOrDefault();

            return new BasePagingResult<T>() { List = data, TotalCount = totalCount };
        }

        public async Task<BaseProductPagingResult<T,Y,N,M,Z>> GetManyProductWithPagingAsync<T,Y,N,M,Z>(string sp, object param, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, param, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data = await multipleResult.ReadAsync<T>();
            IEnumerable<Y> data1 = await multipleResult.ReadAsync<Y>();
            IEnumerable<N> data2 = await multipleResult.ReadAsync<N>();
            IEnumerable<M> data3 = await multipleResult.ReadAsync<M>();
            IEnumerable<Z> data4 = await multipleResult.ReadAsync<Z>();
            var totalCount = multipleResult.Read<int>().FirstOrDefault();

            return new BaseProductPagingResult<T, Y, N, M, Z>()
            {
                List = data,
                List1 = data1,
                List2 = data2,
                List3 = data3,
                List4 = data4,
                TotalCount = totalCount
            };
        }

        public async Task<BaseProductPagingResult<T, Y, N, M, Z>> GetManyProductWithPagingAsync<T, Y, N, M, Z>(string sp, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data = multipleResult.Read<T>();
            IEnumerable<Y> data1 = await multipleResult.ReadAsync<Y>();
            IEnumerable<N> data2 = await multipleResult.ReadAsync<N>();
            IEnumerable<M> data3 = await multipleResult.ReadAsync<M>();
            IEnumerable<Z> data4 = await multipleResult.ReadAsync<Z>();
            var totalCount = multipleResult.Read<int>().FirstOrDefault();

            return new BaseProductPagingResult<T, Y, N, M, Z>()
            {
                List = data, 
                List1 = data1,  
                List2 = data2,
                List3 = data3,
                List4 = data4,
                TotalCount = totalCount
            };
        }

        public async Task<BaseProductDetailResult<T>> GetManyProductDetailAsync<T>(string sp, object param, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, param, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            T data = (await multipleResult.ReadAsync<T>()).FirstOrDefault();
            IEnumerable<int> cdnFileIdes = await multipleResult.ReadAsync<int>();

            return new BaseProductDetailResult<T>() { Product = data, CdnFileIdes = cdnFileIdes };
        }

        public async Task<BaseProductDetailResult<T>> GetManyProductDetailAsync<T>(string sp, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            T data = (await multipleResult.ReadAsync<T>()).FirstOrDefault();
            IEnumerable<int> cdnFileIdes = await multipleResult.ReadAsync<int>();

            return new BaseProductDetailResult<T>() { Product = data, CdnFileIdes = cdnFileIdes };
        }

        public async Task<BaseCartInfoResult<T, Y>> GetManyCartInfoAsync<T, Y>(string sp, object param, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, param, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data1 = await multipleResult.ReadAsync<T>();
            Y data2 = (await multipleResult.ReadAsync<Y>()).FirstOrDefault();

            return new BaseCartInfoResult<T, Y>() { Products = data1, CartInfo = data2 };
        }

        public async Task<BaseCartInfoResult<T, Y>> GetManyCartInfoAsync<T, Y>(string sp, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data1 = await multipleResult.ReadAsync<T>();
            Y data2 = (await multipleResult.ReadAsync<Y>()).FirstOrDefault();

            return new BaseCartInfoResult<T, Y>() { Products = data1, CartInfo = data2 };
        }

        public async Task<BaseDoubleResult<T, Y>> GetDoubleAsync<T, Y>(string sp, object param, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, param, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data1 = await multipleResult.ReadAsync<T>();
            IEnumerable<Y> data2 = await multipleResult.ReadAsync<Y>();

            return new BaseDoubleResult<T, Y>() { Data1 = data1, Data2 = data2 };
        }

        public async Task<BaseDoubleResult<T, Y>> GetDoubleAsync<T, Y>(string sp, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data1 = await multipleResult.ReadAsync<T>();
            IEnumerable<Y> data2 = await multipleResult.ReadAsync<Y>();

            return new BaseDoubleResult<T, Y>() { Data1 = data1, Data2 = data2 };
        }

        public async Task<BaseFifthResult<T, Y, N, M, Z>> GetFifthAsync<T, Y, N, M, Z>(string sp, object param, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, param, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data1 = await multipleResult.ReadAsync<T>();
            IEnumerable<Y> data2 = await multipleResult.ReadAsync<Y>();
            IEnumerable<N> data3 = await multipleResult.ReadAsync<N>();
            IEnumerable<M> data4 = await multipleResult.ReadAsync<M>();
            IEnumerable<Z> data5 = await multipleResult.ReadAsync<Z>();

            return new BaseFifthResult<T, Y, N, M, Z>() { List1 = data1, List2 = data2, List3 = data3, List4 = data4, List5 = data5};
        }

        public async Task<BaseFifthResult<T, Y, N, M, Z>> GetFifthAsync<T, Y, N, M, Z>(string sp, int timeout = 0)
        {
            var multipleResult = await this._db.QueryMultipleAsync(sp, commandTimeout: timeout, commandType: CommandType.StoredProcedure);

            IEnumerable<T> data1 = await multipleResult.ReadAsync<T>();
            IEnumerable<Y> data2 = await multipleResult.ReadAsync<Y>();
            IEnumerable<N> data3 = await multipleResult.ReadAsync<N>();
            IEnumerable<M> data4 = await multipleResult.ReadAsync<M>();
            IEnumerable<Z> data5 = await multipleResult.ReadAsync<Z>();

            return new BaseFifthResult<T, Y, N, M, Z>() { List1 = data1, List2 = data2, List3 = data3, List4 = data4, List5 = data5 };
        }

        public async Task<T> GetAsync<T>(object param)
        {
            var spAttrs = ReflectionHelper.GetSpAttribute(param.GetType());
            var spName = spAttrs.SpName;

            return await this.GetAsync<T>(spName, param, this._timeout);
        }

        public async Task<T> GetAsync<T>(string sp, object param)
        {
            return await this.GetAsync<T>(sp, param, this._timeout);
        }

        public async Task<T> GetAsync<T>(string sp, object param, int timeout)
        {
            return await this._db.QueryFirstOrDefaultAsync<T>(sp, param, null, timeout, CommandType.StoredProcedure);
        }

        public async Task<T> GetAsync<T>(string sp)
        {
            return await this._db.QueryFirstOrDefaultAsync<T>(sp, CommandType.StoredProcedure);
        }

        public async Task<T> ScalerAsync<T>(string sp, object param)
        {
            return await this.ScalerAsync<T>(sp, param, this._timeout);
        }

        public async Task<T> ScalerAsync<T>(string sp, object param, int timeout)
        {
            return await this._db.ExecuteScalarAsync<T>(sp, param, null, timeout, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> SelectAsync<T>(string sp, object param)
        {
            return await this.SelectAsync<T>(sp, param, this._timeout);
        }

        public async Task<IEnumerable<T>> SelectAsync<T>(string sp, object param, int timeout)
        {
            return await this._db.QueryAsync<T>(sp, param, null, timeout, CommandType.StoredProcedure);
        }


        //public Task<T> GetAndCacheAsync<T>(string sp, object param, int seconds)
        //{
        //    return this.GetAndCacheAsync<T>(sp, param, seconds, this._timeout);
        //}

        //public Task<T> GetAndCacheAsync<T>(string sp, object param, int seconds, int timeout)
        //{
        //    string key = this.GetKey(sp, param);

        //    Func<Task<T>> build = () => this.GetAsync<T>(sp, param, timeout);

        //    return dlCache.GetAsync(key, build, false, seconds);
        //}

        //public Task<IEnumerable<T>> SelectAndCacheAsync<T>(string sp, object param, int seconds)
        //{
        //    return this.SelectAndCacheAsync<T>(sp, param, seconds, this._timeout);
        //}

        //public Task<IEnumerable<T>> SelectAndCacheAsync<T>(string sp, object param, int seconds, int timeout)
        //{
        //    string key = this.GetKey(sp, param);

        //    Func<Task<IEnumerable<T>>> build = () => this.SelectAsync<T>(sp, param, timeout);

        //    return dlCache.GetAsync(key, build, false, seconds);
        //}
    }
}
