using System;
using System.ComponentModel.DataAnnotations;

namespace PosiPrice.API.Resources
{
    public class SaveProductResource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Minimum_users { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        //
        public int UserId { get; set; }
    }
}
