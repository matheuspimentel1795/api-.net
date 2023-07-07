using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class ProductsApiService : IProductsApiService
    {
        private readonly IProductsApiRepository _productsApiRepository;
        private readonly IMapper _mapper;

        public ProductsApiService(IProductsApiRepository productsApiRepository, IMapper mapper)
        {
            _productsApiRepository = productsApiRepository;
            _mapper = mapper;
        }

        public async Task Create(ProductsDTO productDto)
        {
            var products = _mapper.Map<ProductsApi>(productDto);
            await _productsApiRepository.Create(products);
            
        }

        public async Task Delete(int id)
        {
            var productEntity = await _productsApiRepository.GetProductById(id);
            if(productEntity != null)
            {
                await _productsApiRepository.Delete(productEntity.Id);
            }
        }

        public async Task<IEnumerable<ProductsDTO>> GetAll()
        {
            var productsEntity = await _productsApiRepository.GetAll();
            return _mapper.Map<List<ProductsDTO>>(productsEntity);
        }

        public async Task<ProductsDTO> GetProductById(int id)
        {
            var productEntity = await _productsApiRepository.GetProductById(id);
            return _mapper.Map<ProductsDTO>(productEntity);
        }

        public async Task Update(ProductsDTO product)
        {
            var productEntity = await _productsApiRepository.GetProductById(product.Id);
            if(productEntity != null)
            {
                await _productsApiRepository.Update(productEntity);
            }
        }
    }
}
