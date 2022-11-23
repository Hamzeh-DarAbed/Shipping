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
        
        private readonly IRepository<ServiceProvider> _shippingOrderRepository;
        private readonly IRepository<ShippingService> _shippingServiceRepository;
        private readonly IRepository<Package> _packageRepository;

        public CreateShippingOrderController(IRepository<ServiceProvider> shippingOrderRepository, IRepository<ShippingService> shippingServiceRepository, IRepository<Package> packageRepository)
        {
            _shippingOrderRepository = shippingOrderRepository;
            _shippingServiceRepository = shippingServiceRepository;
            _packageRepository = packageRepository;
        }
        
        


        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateShippingOrderDto createShippingOrderDto)
        {
            try
            {

                var serviceProvider =_shippingOrderRepository.Get(createShippingOrderDto.CarrierId);
                 if (serviceProvider == null)
                {
                    return BadRequest("Carrier not found");
                }

                var carrierService =_shippingServiceRepository.Find(x => x.CarrierId == createShippingOrderDto.CarrierId && x.ShippingServiceId == createShippingOrderDto.ShippingServiceId).FirstOrDefault();

                if (carrierService == null )
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