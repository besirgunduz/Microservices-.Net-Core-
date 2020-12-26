using Catalog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getProductList();

        Task<Product> GetProduct(string id);

        Task<IEnumerable<Product>> getProductByName(string name);

        Task<IEnumerable<Product>> getProductByCategory(string categoryName);

        Task Create(Product product);

        Task<bool> Update(Product product);

        Task<bool> Delete(string id);
    }
}