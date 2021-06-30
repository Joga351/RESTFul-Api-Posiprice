using System;
using System.ComponentModel.DataAnnotations;

namespace PosiPrice.API.Resources
{   
    public class SaveUserResource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        //--------------------------------
        [Required]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string emailAddress { get; set; }

        
     
    }
}
