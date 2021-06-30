using System;
using AutoMapper;
using PosiPrice.API.Domain.Models;

using PosiPrice.API.Extensions;
using PosiPrice.API.Resources;

namespace PosiPrice.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category,CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<User, UserResource>();
        }
    }
}