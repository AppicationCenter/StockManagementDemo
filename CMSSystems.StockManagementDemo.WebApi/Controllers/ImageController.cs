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
    public class ImageController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ImageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult UploadImage(Image image)
        {
            this.unitOfWork.ImageRepository.Insert(image);
            var rowsAffected = this.unitOfWork.Commit();
            return Ok();
        }
    }
}
