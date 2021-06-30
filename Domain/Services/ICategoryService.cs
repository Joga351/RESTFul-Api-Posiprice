using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//interacciones con el servicio->servicio
namespace PosiPrice.API.Domain.Services
{
    public interface ICategoryService
    {
        //Get ALL
        Task<IEnumerable<Category>> ListAsync();
        //GET BY ID
        Task<CategoryResponse> GetByIdAsync(int id);
        //POST 
        Task<CategoryResponse> SaveAsync(Category category);
        //PUT
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        //DELETE
        Task<CategoryResponse> DeleteAsync(int id); 
    }
}