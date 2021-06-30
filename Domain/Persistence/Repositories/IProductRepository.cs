using PosiPrice.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);

        /// ////////////////
         Task<IEnumerable<Product>> ListByUserIdAsync(int categoryId);
        /// 
        /// 
        //

        Task AddAsync(Product product);
        Task<Product> FindById(int id);
        void Update(Product product);
        void Remove(Product product);

    }
}