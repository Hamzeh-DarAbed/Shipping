using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Context;
using Shipping.Dto;
using Shipping.repo;
using Shipping.Entities;

using Shipping.repo.IRepositories;
using Shipping.UnitOfWork;
using Microsoft.AspNetCore.Authorization;

namespace Shipping.Controllers
{
    [Route("[controller]")]
    public class CreateShippingOrderController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateShippingOrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpPost("~/c")]
        [Authorize(Roles = "admin")]

        public IActionResult CreateOrder([FromBody] CreateShippingOrderDto createShippingOrderDto)
        {
            try
            {

                ServiceProviderEntity serviceProvider = _unitOfWork.ServiceRepository.Get(createShippingOrderDto.CarrierId);
                if (serviceProvider == null)
                {
                    return BadRequest("Carrier not found");
                }

                ShippingService carrierService = serviceProvider.ShippingService.Where(x => x.ShippingServiceId == createShippingOrderDto.ShippingServiceId).First();


                if (carrierService == null)
                {
                    return BadRequest("Carrier service not found");
                }

                Package package = new Entities.Package
                {
                    ShippingServiceId = carrierService.ShippingServiceId,
                    ShippingService = carrierService,
                    Weight = createShippingOrderDto.Weight,
                    Height = createShippingOrderDto.Height,
                    Width = createShippingOrderDto.Width,
                    Length = createShippingOrderDto.Length
                };
                _unitOfWork.PackageRepository.Add(package);
                _unitOfWork.Complete();

                return Ok("shipment has been placed successfully");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}