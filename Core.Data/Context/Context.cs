using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Core.Data.Context
{
    public partial class Context : IDisposable
    {
        private IDbConnection _db;
        private int _timeout = 30;

        public Context(string connection, int timeout)
        {
            this._db = new SqlConnection(connection);
            this._timeout = timeout;
        }

        public int Execute(string sp, object param)
        {
            return this.Execute(sp, param, this._timeout);
        }

        public int Execute(string sp, object param, int timeout)
        {
            return this._db.Execute(sp, param, null, timeout, CommandType.StoredProcedure);
        }

        public T Get<T>(string sp, object param)
        {
            return this.Get<T>(sp, param, this._timeout);
        }

        public T Get<T>(string sp, object param, int timeout)
        {
            return this._db.QueryFirstOrDefault<T>(sp, param, null, timeout, CommandType.StoredProcedure);
        }

        public T Scaler<T>(string sp, object param)
        {
            return this.Scaler<T>(sp, param, this._timeout);
        }

        public T Scaler<T>(string sp, object param, int timeout)
        {
            return this._db.ExecuteScalar<T>(sp, param, null, timeout, CommandType.StoredProcedure);
        }

        public IEnumerable<T> Select<T>(string sp, object param)
        {
            return this.Select<T>(sp, param, this._timeout);
        }

        public IEnumerable<T> Select<T>(string sp, object param, int timeout)
        {
            return this._db.Query<T>(sp, param, null, true, timeout, CommandType.StoredProcedure);
        }

        //public T GetAndCache<T>(string sp, object param, int seconds)
        //{
        //    return this.GetAndCache<T>(sp, param, seconds, this._timeout);
        //}

        //public T GetAndCache<T>(string sp, object param, int seconds, int timeout)
        //{
        //    string key = this.GetKey(sp, param);

        //    Func<T> build = () => this.Get<T>(sp, param, timeout);

        //    return dlCache.Get(key, build, false, seconds);
        //}

        //public IEnumerable<T> SelectAndCache<T>(string sp, object param, int seconds)
        //{
        //    return this.SelectAndCache<T>(sp, param, seconds, this._timeout);
        //}

        //public IEnumerable<T> SelectAndCache<T>(string sp, object param, int seconds, int timeout)
        //{
        //    string key = this.GetKey(sp, param);

        //    Func<IEnumerable<T>> build = () => this.Select<T>(sp, param, timeout);

        //    return dlCache.Get(key, build, false, seconds);
        //}

        public SqlMapper.ICustomQueryParameter GetTvp<T>(IEnumerable<T> models, string type)
        {
            DataTable table = new DataTable();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                table.Columns.Add
                (
                    property.Name,
                    property.PropertyType.IsGenericType
                        ? property.PropertyType.GenericTypeArguments[0]
                        : property.PropertyType
                );
            }

            foreach (T model in models)
            {
                DataRow row = table.NewRow();

                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(model) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table.AsTableValuedParameter(type);
        }

        private string GetKey(string sp, object param)
        {
            string key = sp;

            if (param != null)
            {
                PropertyInfo[] props = param.GetType().GetProperties();

                foreach (PropertyInfo prop in props)
                {
                    key += $"{prop.Name}{Convert.ToString(prop.GetValue(param))}";
                }
            }

            return key;
        }


        public void Dispose()
        {
            if (this._db != null)
            {
                if (this._db.State == ConnectionState.Open)
                {
                    this._db.Close();
                }

                this._db.Dispose();

                this._db = null;
            }
        }
    }
}
