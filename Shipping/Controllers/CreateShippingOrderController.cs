using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Context;
using Shipping.Dto;
using Shipping.repo;
using Shipping.Entities;
using ServiceProvider = Shipping.Entities.ServiceProvider;

namespace Shipping.Controllers
{
    [Route("[controller]")]
    public class CreateShippingOrderController : Controller
    {

        private readonly IRepository<ServiceProvider, string> _shippingOrderRepository;
        private readonly IRepository<Package, string> _packageRepository;

        public CreateShippingOrderController(IRepository<ServiceProvider, string> shippingOrderRepository, IRepository<Package, string> packageRepository)
        {
            _shippingOrderRepository = shippingOrderRepository;
            _packageRepository = packageRepository;

        }


        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateShippingOrderDto createShippingOrderDto)
        {
            try
            {

                var serviceProvider = _shippingOrderRepository.Get(createShippingOrderDto.CarrierId);
                if (serviceProvider == null)
                {
                    return BadRequest("Carrier not found");
                }

                var carrierService = serviceProvider.ShippingService.Find(x => x.ShippingServiceId == createShippingOrderDto.ShippingServiceId);
                
                    System.Console.WriteLine(carrierService);

                
                if (carrierService == null)
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

                _packageRepository.Add(package);

                return Ok("shipment has been placed successfully");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}