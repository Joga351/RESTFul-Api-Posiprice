using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Resources;

namespace PosiPrice.API.Controllers
{
    [Route("/api/users/{userId}/products")]
    public class UserProductsPurchasesController
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public UserProductsPurchasesController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByUserIdAsync(int userId)
        {
            var products = await _productService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }
    }
}
