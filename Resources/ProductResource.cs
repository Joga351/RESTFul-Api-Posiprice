using System;
namespace PosiPrice.API.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //---
        public double Price { get; set; }
        public int Minimum_users { get; set; }
        public string Description { get; set; }
        //---

        public CategoryResource Category { get; set; }

        ///
        public UserResource User { get; set; }
        ///
    }
}