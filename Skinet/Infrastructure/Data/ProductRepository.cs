using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitys;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var t = await _context.ProductBrands.ToArrayAsync();
            return t;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductType)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                        .Include(x => x.ProductBrand)
                        .Include(x => x.ProductType)
                        .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}