using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreApi.Data;
using MyFirstCoreApi.Models;

namespace MyFirstCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ProductsDbContext productsDbContext;

        public ProductsController(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }


        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productsDbContext.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
          var product=  productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            if(product==null)
            {
                return NotFound("No records Found......");
            }


            return Ok(product);
            
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Provide in proper format");
            }

            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            if(id!=product.ProductId)
            {
                return BadRequest();
            }

            try { 
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No records found against this id");
            }

            return Ok("Product Updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            if(product==null)
            {
                return NotFound("No records found");
            }

            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
            return Ok("Product Deleted...");
            
        }
    }
}
