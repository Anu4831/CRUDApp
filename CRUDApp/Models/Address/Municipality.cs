using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApp.Models.Address
{
    public class Municipality
    {
        [Key]
        public int MunId { get; set; }
        public string MunName { get; set; }

        [ForeignKey("District")]
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
