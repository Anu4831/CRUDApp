using System.ComponentModel.DataAnnotations;

namespace CRUDApp.Models.Address
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
