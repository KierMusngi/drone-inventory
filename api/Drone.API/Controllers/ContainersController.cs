using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drone.API.Helpers;
using Drone.API.Models.Requests;
using Drone.API.Models.Views;
using Drone.Core.DomainModels;
using Drone.Core.Helpers;
using Drone.DataAccess;
using Drone.DataAccess.Entities;
using Drone.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Drone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly DroneContext _context;
        private readonly IContainerRepository _containerRepository;

        public ContainersController(
            DroneContext context,
            IContainerRepository containerRepository)
        {
            _context = context;
            _containerRepository = containerRepository;
        }

        // GET: api/Containers
        [HttpGet]
        public async Task<IActionResult> GetContainers()
        {
            try
            {
                var containerEntities = await _containerRepository.GetAll();

                var containers = new List<Container>();
                containerEntities.ForEach(containerEntity =>
                {
                    containers.Add(containerEntity.ToDomainModel());
                });

                var containerViews = new List<ContainerView>();
                containers.ForEach(container =>
                {
                    containerViews.Add(container.ToViewModel(0));
                });

                return new OkObjectResult(containerViews);
            }
            catch (Exception exception)
            {
                return new BadRequestObjectResult(exception.Message.ToString());
            }
        }

        // GET: api/Containers/5
        [HttpGet("{containerId}")]
        public async Task<IActionResult> GetContainerById(int containerId)
        {
            try
            {
                var containerEntity = await _containerRepository.GetById(containerId);
                var containerQuantity = _containerRepository
                    .GetContainerCountBySerialNumber(containerEntity.SerialNumber);

                var container = containerEntity.ToDomainModel();

                return new OkObjectResult(container.ToViewModel(containerQuantity));
            }
            catch (Exception exception)
            {
                return new BadRequestObjectResult(exception.Message.ToString());
            }
        }

        // POST: api/Containers
        [HttpPost]
        public async Task<IActionResult> Post(ContainerRequest containerRequest)
        {
            try
            {
                var container = new Container(
                    name: containerRequest.Name,
                    description: containerRequest.Description,
                    serialNumber: containerRequest.SerialNumber,
                    itemCount: containerRequest.ItemCount,
                    expirationDate: containerRequest.ExpirationDate,
                    manufacturingDate: containerRequest.ManufacturingDate,
                    dateCreated: DateTime.Now);

                var containerEntity = new ContainerEntity()
                {
                    Id = container.Id,
                    Name = container.Name,
                    Description = container.Description,
                    SerialNumber = container.SerialNumber,
                    ItemCount = container.ItemCount,
                    ExpirationDate = container.ExpirationDate,
                    ManufacturingDate = container.ManufacturingDate,
                    DateCreated = container.DateCreated
                };

                await _containerRepository.Add(containerEntity);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception exception)
            {
                return new BadRequestObjectResult(exception.Message.ToString());
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{containerId}")]
        public async Task<IActionResult> DeleteContainer(int containerId)
        {
            try
            {
                var container = await _containerRepository.GetById(containerId);

                _containerRepository.Remove(container);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception exception)
            {
                return new BadRequestObjectResult(exception.Message.ToString());
            }
        }
    }
}
