using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        // private readonly IProductsApiService _productsApiService;
        private readonly IProductsApiService _productsApiService;
      
        public ProductsApiController( IProductsApiService productsApiService)
        {
            // _productsApiService = productsApiService;

            _productsApiService = productsApiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> Get()
        {
            var produtosDto = await _productsApiService.GetAll();
            if (produtosDto == null)
                return NotFound("Nenhum produto cadastrado");
            return Ok(produtosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDTO>> Get(int id)
        {
            var produtoDto = await _productsApiService.GetProductById(id);
            if (produtoDto == null)
                return NotFound("Produto nao encontrado");
            return produtoDto;
        }
        [HttpPost]
        public async Task<ActionResult<ProductsDTO>> Post([FromBody] ProductsDTO productDto)
        {
            if (productDto == null)
                return NotFound("Produto nao encontrado");
            await _productsApiService.Create(productDto);
            return productDto;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] ProductsDTO productDto)
        {
            
            if (productDto is null)
                return BadRequest("Data invalida");
            await _productsApiService.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {   
            await _productsApiService.Delete(id);
            return Ok();
        }
    }
}
