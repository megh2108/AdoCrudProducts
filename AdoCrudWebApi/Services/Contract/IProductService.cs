using AdoCrudWebApi.Dtos;
using AdoCrudWebApi.Models;

namespace AdoCrudWebApi.Services.Contract
{
    public interface IProductService
    {
        ServiceResponse<List<ProductDto>> GetAllProducts();

        ServiceResponse<string> AddProduct(AddProductDto productDto);

        ServiceResponse<string> UpdateProduct(UpdateProductDto productDto);

        ServiceResponse<string> DeleteProduct(int productId);

        ServiceResponse<ProductDto> GetProductById(int productId);
    }
}
