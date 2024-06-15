using CRUDApp.Models.Address;

namespace CRUDApp.Models
{
    public class CustomerViewModel
    {
        public CustomerDTO Customer { get; set; }
        public List<Province> Provinces { get; set; }
        public List<District> Districts { get; set; }
        public List<Municipality> Municipalities { get; set; }
    }
}

