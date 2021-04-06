using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mitek_API.Db;
using Mitek_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mitek_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private IDbContext _context;

        public Products(IDbContext context)
        {
            _context = context;
        }

        // GET: api/<Products>
        [HttpGet]
        public async Task<Product[]> Get()
        {
            try
            {
                var products = await _context.GetProducts();
                return products.ToArray();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET api/<Products>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            try
            {
                return await _context.GetProduct(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST api/<Products>
        [HttpPost]
        public async Task<Product> Post([FromBody] Product product)
        {
            try
            {
                var result = await _context.AddProduct(product);
                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT api/<Products>/5
        [HttpPut("{id}")]
        public async Task<Product> Put(int id, [FromBody] Product product)
        {
            try
            {
                var result = await _context.UpdateProduct(id, product);
                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<Products>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.DeleteProduct(id);
                return result > 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
