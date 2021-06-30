using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosiPrice.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        //private readonly IProductUserRepository _productUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
           
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.ListByCategoryIdAsync(categoryId);
        }
        //
        
        //


        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
                return new ProductResponse("Product Not Found");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while deleting product: {ex.Message}");
            }

        }

        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
                return new ProductResponse("Product Not Found");

            return new ProductResponse(existingProduct);
        }


        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while saving the product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
                return new ProductResponse("Product Not Found");

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Minimum_users = product.Minimum_users;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.UserId = product.UserId;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while updating product: {ex.Message}");
            }


            //  Id 
            // Name
            ////Price 
            // Minimum_users
            // Description
            //---

        }

        public async Task<IEnumerable<Product>> ListByUserIdAsync(int userId)
        {
            return await _productRepository.ListByUserIdAsync(userId);
            
        }

        
    }
}
