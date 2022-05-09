using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitys;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        private ActionResult<ICollection<Product>> OK(List<Product> products)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product;
        }
    }
}