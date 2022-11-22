using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.Dto
{
    public record CreateShippingOrderDto
    {
        public string CarrierId { get; set; }
        public string ShippingServiceId { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
    }
}