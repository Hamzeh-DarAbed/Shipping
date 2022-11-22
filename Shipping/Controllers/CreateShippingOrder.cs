using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shipping.Context;
using Shipping.Dto;

namespace Shipping.Controllers
{
    [Route("[controller]")]
    public class CreateShippingOrder : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateShippingOrder(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateShippingOrderDto createShippingOrderDto)
        {
            try
            {

                var serviceProvider = _context.ServiceProviders.Find(createShippingOrderDto.CarrierId);
                if (serviceProvider == null)
                {
                    return BadRequest("Carrier not found");
                }

                var carrierService = _context.CarrierServices.Find(createShippingOrderDto.ShippingServiceId);

                if (carrierService == null || serviceProvider.CarrierId != carrierService.CarrierId)
                {
                    return BadRequest("Carrier service not found");
                }

                var package = new Entities.Package
                {
                    ShippingServiceId = carrierService.ShippingServiceId,
                    Weight = createShippingOrderDto.Weight,
                    Height = createShippingOrderDto.Height,
                    Width = createShippingOrderDto.Width,
                    Length = createShippingOrderDto.Length
                };

                _context.Packages.Add(package);
                _context.SaveChangesAsync();

                return Ok("shipment has been placed successfully");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}