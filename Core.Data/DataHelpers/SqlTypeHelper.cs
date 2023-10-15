using System.Collections.Generic;
using Core.Models.Model.Common.DapperModel;
using Core.Models.Request.Business.Cart;
using Core.Models.Request.Business.Product;

namespace Core.Data.DataHelpers
{
    public static class SqlTypeHelper
    {
        public static List<IdesSqlType> MapToIdesSqlType(this List<int> items)
        {
            var lst = new List<IdesSqlType>();
            foreach (var item in items)
                lst.Add(new IdesSqlType {Id = item});
            return lst;
        }

        public static List<IdesSqlType> MapToIdesStrSqlType(this List<string> items)
        {
            var lst = new List<IdesSqlType>();
            foreach (var item in items)
                lst.Add(new IdesSqlType { Id = int.Parse(item) });
            return lst;
        }

        public static List<CheckCartProductDataSqlType> MapToCheckCartProductDataSqlType(this List<CheckProductForCartRequest> items)
        {
            var results = new List<CheckCartProductDataSqlType>();

            foreach(var item in items)
                results.Add(new CheckCartProductDataSqlType { ProductId = item.ProductId, Price = item.Price , DiscountPrice = item.DiscountPrice });
                
            return results;
        }

        public static List<CartProductDataSqlType> MapToCartProductDataSqlType(this List<AddCartRequest> items)
        {
            var results = new List<CartProductDataSqlType>();

            foreach (var item in items)
                results.Add(new CartProductDataSqlType { ProductId = item.ProductId, Quantity = item.Quantity});

            return results;
        }

        public static List<ProviderDistanceDataSqlType> MapToProviderDistanceDataSqlType(this List<ProviderDistanceRequest> items)
        {
            var results = new List<ProviderDistanceDataSqlType>();

            foreach (var item in items)
                results.Add(new ProviderDistanceDataSqlType { ProviderId = item.ProviderId, Kilometer = item.Kilometer });

            return results;
        }
    }
}