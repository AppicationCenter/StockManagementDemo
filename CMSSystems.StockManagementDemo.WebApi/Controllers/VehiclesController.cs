using CMSSystems.StockManagementDemo.Data;
using CMSSystems.StockManagementDemo.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public VehiclesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vehicles = new List<Vehicle>();

            string includeProperties = "Accessories,Images";
            vehicles = this.unitOfWork.VehicleRepository.GetAll(null, null, includeProperties).ToList();
            //var vehiclesJson = JsonConvert.SerializeObject(vehicles, Formatting.Indented,
            //new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            //});

            return Ok(vehicles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var vehicle = this.unitOfWork.VehicleRepository.Get(id);

            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Post(Vehicle vehicle)
        {
            this.unitOfWork.VehicleRepository.Insert(vehicle);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Vehicle vehicle)
        {
            this.unitOfWork.VehicleRepository.Update(vehicle);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Vehicle vehicle)
        {
            this.unitOfWork.VehicleRepository.Delete(vehicle);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok();
        }
    }
}
