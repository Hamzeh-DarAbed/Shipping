using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities
{
    public record ShippingService
    {
        [Key]
        public string ShippingServiceId { get; set; }

        public List<Package> Packages { get; set; }
        public string CarrierId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

    }
}