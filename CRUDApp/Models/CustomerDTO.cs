using System.ComponentModel.DataAnnotations;

namespace CRUDApp.Models
{
    public class CustomerDTO
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]


        public string Phone { get; set; }

        [Required]
        public string Province { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        [Required]
        public int WardNo { get; set; }

    }
}
