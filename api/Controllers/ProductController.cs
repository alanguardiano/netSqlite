using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("TestController")]
        public IActionResult TestController(){
            return Ok("first get request");
        }

        [HttpGet]
        [Route("EF/GetAllProducts")]
        public ActionResult<List<Product>> GetAllProducts(){
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }
    }
}