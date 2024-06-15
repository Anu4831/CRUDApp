using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApp.Models.Address
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        [ForeignKey("Province")]
        public int ProvinceId {  get; set; }
        public Province Province { get; set; }
    }
}
