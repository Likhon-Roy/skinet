using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitys;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return products;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            return product;
        }
    }
}