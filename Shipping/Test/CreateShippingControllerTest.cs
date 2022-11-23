using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipping.Controllers;
using Shipping.Dto;
using Shipping.Entities;
using Shipping.FakeRepo;
using Shipping.repo;
using Xunit;
using ServiceProvider = Shipping.Entities.ServiceProvider;

namespace Shipping.Test
{
    public class CreateShippingControllerTest
    {
        private readonly IRepository<Entities.Package> _packageRepository;
        private readonly IRepository<ShippingService> _shippingServiceRepository;
        private readonly IRepository<ServiceProvider> _serviceProviderRepository;
        private readonly CreateShippingOrderController _createShippingController;
        
        public CreateShippingControllerTest()
        {
            _packageRepository = new PackageRepoFake();
            _serviceProviderRepository = new ServiceProviderRepoFake();
            _shippingServiceRepository = new ShippingServiceRepoFake();
            _createShippingController = new CreateShippingOrderController(_serviceProviderRepository, _shippingServiceRepository,_packageRepository);
            
        }
        [Fact]
        public void TestCreateShippingOrder_WhenCalled_ReturnsOkResult()
        {
            var createShippingOrderDto=new CreateShippingOrderDto()
            {
                CarrierId = "fedex",
                ShippingServiceId = "fedexAIR",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
            };
            var result = _createShippingController.CreateOrder(createShippingOrderDto);
            var okResult = result as OkObjectResult;

            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal("shipment has been placed successfully", okResult.Value);

        }
        [Fact]
        public void TestCreateShippingOrder_WrongServiceProviderID_ReturnsBadRequestResult()
        {
            var createShippingOrderDto=new CreateShippingOrderDto()
            {
                CarrierId = "htto",
                ShippingServiceId = "fedexAIR",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
            };
            var result = _createShippingController.CreateOrder(createShippingOrderDto);
            Assert.IsType<BadRequestObjectResult>(result as BadRequestObjectResult);
        }
        [Fact]
        public void TestCreateShippingOrder_WrongShippingServiceID_ReturnsBadRequestResult()
        {
            var createShippingOrderDto=new CreateShippingOrderDto()
            {
                CarrierId = "fedex",
                ShippingServiceId = "fedexA",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
            };
            var result = _createShippingController.CreateOrder(createShippingOrderDto);
            Assert.IsType<BadRequestObjectResult>(result as BadRequestObjectResult);
        }
        
    }
}