using System;
using System.Collections.Generic;

namespace PosiPrice.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //------

        public double Price { get; set; }
        public int Minimum_users { get; set; }
        public string Description { get; set; }

     

        //------

        // Una Categoria 1....... N Productos
        public int CategoryId { get; set; }
        public Category Category { get; set; } 

        ////////////Usuario compra varios productos
        public int UserId { get; set; }
        public User User { get; set; }
        
    }


}