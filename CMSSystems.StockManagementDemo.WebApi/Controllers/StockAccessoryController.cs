using CMSSystems.StockManagementDemo.Data;
using CMSSystems.StockManagementDemo.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockAccessoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public StockAccessoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var StockAccessories = new List<StockAccessory>();

            StockAccessories = this.unitOfWork.StockAccessoryRepository.GetAll().ToList();

            return Ok(StockAccessories);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var StockAccessory = this.unitOfWork.StockAccessoryRepository.Get(id);

            return Ok(StockAccessory);
        }

        [HttpPost]
        public IActionResult Post(StockAccessory StockAccessory)
        {
            this.unitOfWork.StockAccessoryRepository.Insert(StockAccessory);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok("StockAccessory model inserted successfully");
        }

        [HttpPut]
        public IActionResult Update(StockAccessory StockAccessory)
        {
            this.unitOfWork.StockAccessoryRepository.Update(StockAccessory);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok("StockAccessory model updated successfully");
        }

        [HttpDelete]
        public IActionResult Delete(StockAccessory StockAccessory)
        {
            this.unitOfWork.StockAccessoryRepository.Delete(StockAccessory);
            var rowsAffected = this.unitOfWork.Commit();

            return Ok("StockAccessory model deleted successfully");
        }
    }
}
