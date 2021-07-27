using CMSSystems.StockManagementDemo.Data;
using CMSSystems.StockManagementDemo.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<VehiclesController> logger;

        public VehiclesController(IUnitOfWork unitOfWork, ILogger<VehiclesController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            this.logger.LogInformation("Getting all vehicles");
            var vehicles = new List<Vehicle>();

            string includeProperties = "Accessories,Images";
            vehicles = this.unitOfWork.VehicleRepository.GetAll(null, null, includeProperties).ToList();

            if (vehicles.Count > 0)
            {
                return Ok(vehicles);
            }

            this.logger.LogInformation($"{vehicles.Count} vehicles returned");
            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var vehicle = this.unitOfWork.VehicleRepository.Get(id);


            if (vehicle != null)
            {
                return Ok(vehicle);
            }

            this.logger.LogInformation($"vehicles returned: {vehicle} ");
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(Vehicle vehicle)
        {
            this.unitOfWork.VehicleRepository.Insert(vehicle);
            var rowsAffected = this.unitOfWork.Commit();

            if (rowsAffected > 0)
            {
                var message = $"Vehicle {vehicle.Id} was inserted successfully.";
                this.logger.LogInformation(message);
                return Ok(message);
            }

            return BadRequest($"Vehicle {vehicle.Id} was not inserted.");
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(Vehicle vehicle)
        {
            this.unitOfWork.VehicleRepository.Update(vehicle);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var vehicle = this.unitOfWork.VehicleRepository.Get(id);
            if (vehicle != null)
            {
                this.unitOfWork.VehicleRepository.Delete(vehicle);
                var rowsAffected = this.unitOfWork.Commit();
                if (rowsAffected > 0)
                {
                    return Ok("Vehicle deleted successfully.");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
