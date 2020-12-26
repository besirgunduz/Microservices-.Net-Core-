using Catalog.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> products)
        {
            bool existProduct = products.Find(p => true).Any();
            if (!existProduct)
            {
                products.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product{ Name="Kalem 1", Description="Kalem açıklama",  Price=100M, Category="Kalemler", Picture="kalem1.png"},
                  new Product{ Name="Kalem 2", Description="Kalem açıklama",  Price=100M, Category="Kalemler", Picture="kalem1.png"},
                    new Product{ Name="Kalem 3", Description="Kalem açıklama",  Price=100M, Category="Kalemler", Picture="kalem1.png"},
                      new Product{ Name="Kalem 4", Description="Kalem açıklama",  Price=100M, Category="Kalemler", Picture="kalem1.png"}
            };
        }
    }
}