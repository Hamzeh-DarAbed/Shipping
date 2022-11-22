using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities
{
    public record Package
    {
        [Key]
        public int PackageId { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public string ShippingServiceId { get; set; }
        public ShippingService ShippingService { get; set; }

    }
}