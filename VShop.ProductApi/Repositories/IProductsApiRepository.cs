using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IProductsApiRepository
    {
        Task<IEnumerable<ProductsApi>> GetAll();
        Task<ProductsApi> GetProductById(int id);
        Task<ProductsApi> Create(ProductsApi product);
        Task<ProductsApi> Update(ProductsApi product);
        Task<ProductsApi> Delete(int id);
    }
}
