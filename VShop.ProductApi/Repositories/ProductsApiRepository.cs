using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class ProductsApiRepository : IProductsApiRepository
    {
        private readonly AppDbContext _context;
        public ProductsApiRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductsApi> Create(ProductsApi product)
        {
            _context.ProductsApi.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductsApi> Delete(int id)
        {
            var product = await GetProductById(id);
            _context.ProductsApi.Remove(product);
            return product;
        }

        public async Task<IEnumerable<ProductsApi>> GetAll()
        {
            return await _context.ProductsApi.ToListAsync();
        }

        public async Task<ProductsApi> GetProductById(int id)
        {
            return await _context.ProductsApi.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductsApi> Update(ProductsApi product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
