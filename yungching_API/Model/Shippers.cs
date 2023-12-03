using System.ComponentModel.DataAnnotations;

namespace yungching_API.Model
{
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }


    }
}
