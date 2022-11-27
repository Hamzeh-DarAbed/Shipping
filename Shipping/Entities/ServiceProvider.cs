using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.Entities
{
    public record ServiceProvider
    {
        [Key]
        public string CarrierId { get; set; }
        [Required]
        public virtual List<ShippingService> ShippingService { get; set; }
        
    }
}