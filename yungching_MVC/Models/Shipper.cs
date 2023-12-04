using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yungching_MVC.Models
{
    public partial class Shipper
    {
        [Key]
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
