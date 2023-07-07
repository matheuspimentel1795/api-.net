using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;
        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetProductById(id);
            _context.Product.Remove(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await  _context.Product.ToListAsync(); 
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
