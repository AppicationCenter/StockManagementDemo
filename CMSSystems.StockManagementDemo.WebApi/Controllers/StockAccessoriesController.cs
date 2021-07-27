using CMSSystems.StockManagementDemo.Data;
using CMSSystems.StockManagementDemo.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSSystems.StockManagementDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockAccessoriesController : ControllerBase
    {
        private readonly ILogger<StockAccessoriesController> logger;
        private readonly IUnitOfWork unitOfWork;

        public StockAccessoriesController(ILogger<StockAccessoriesController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        //[RoutePrefix("quotes")]
        public IActionResult GetAll()
        {
            try
            {
                var stockAccessories = new List<StockAccessory>();

                stockAccessories = this.unitOfWork.StockAccessoryRepository.GetAll().ToList();

                if (stockAccessories != null && stockAccessories.Count > 0)
                {
                    return Ok(stockAccessories); 
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var stockAccessory = this.unitOfWork.StockAccessoryRepository.Get(id);

                if (stockAccessory != null)
                {
                    return Ok(stockAccessory); 
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex) { this.logger.LogError(ex.StackTrace); throw; }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(StockAccessory StockAccessory)
        {
            try
            {
                this.unitOfWork.StockAccessoryRepository.Insert(StockAccessory);
                var rowsAffected = this.unitOfWork.Commit();

                if (rowsAffected > 0)
                {
                    return Ok("StockAccessory model inserted successfully"); 
                }
                else
                {
                    return BadRequest("Stock Accessory model not inserted.");
                }
            }
            catch (Exception ex )
            {
                this.logger.LogError(ex.StackTrace);
                throw;
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(StockAccessory StockAccessory)
        {
            try
            {
                this.unitOfWork.StockAccessoryRepository.Update(StockAccessory);
                var rowsAffected = this.unitOfWork.Commit();

                if (rowsAffected > 0)
                {
                    return Ok("StockAccessory model updated successfully");
                }
                else
                {
                    return BadRequest("Stock Accessory not model updated");
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                throw;
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                StockAccessory stockAccessory = this.unitOfWork.StockAccessoryRepository.Get(id);

                if (stockAccessory != null)
                {
                    this.unitOfWork.StockAccessoryRepository.Delete(stockAccessory);
                    var rowsAffected = this.unitOfWork.Commit();
                    if (rowsAffected > 0)
                    {
                        return Ok("Stock accessory deleted successfully.");
                    }
                    else
                    {
                        return BadRequest("Stock accessory not deleted.");
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.StackTrace);
                throw;
            }
        }
    }
}
