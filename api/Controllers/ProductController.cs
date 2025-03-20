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
        private readonly AppDbContextWithDapper _dbDapperContext;

        public ProductController(AppDbContext dbContext, AppDbContextWithDapper dbDapper)
        {
            _dbContext = dbContext;
            _dbDapperContext = dbDapper;
        }

        [HttpGet]
        [Route("TestController")]
        public IActionResult TestController(){
            return Ok("first get request");
        }

        [HttpGet]
        [Route("EF/GetAllProducts")]
        public ActionResult<List<Product>> GetEAllProducts(){
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("DP/GetAllProducts")]
        public ActionResult<List<Product>> GetAllProducts(){
            var products = _dbDapperContext.GetAllProducts().ToList();
            return Ok(products);
        }
    }
}