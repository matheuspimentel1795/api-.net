using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services
{
    public interface IProductsApiService
    {
        Task<IEnumerable<ProductsDTO>> GetAll();
        Task<ProductsDTO> GetProductById(int id);

        Task Create(ProductsDTO product);
        Task Update(ProductsDTO product);
        Task Delete(int id);

        Task<ProductsDTO> GetProductsByName (string name);
       
    }
}
