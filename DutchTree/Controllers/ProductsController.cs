using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTree.Data;
using DutchTree.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTree.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IDutchRepository repository, ILogger<ProductsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }  

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(repository.GetAllProducts());

            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");    
            }
        }
    }
}
