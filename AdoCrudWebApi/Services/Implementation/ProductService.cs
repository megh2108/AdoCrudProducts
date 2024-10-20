using AdoCrudWebApi.Data.Contract;
using AdoCrudWebApi.Dtos;
using AdoCrudWebApi.Models;
using AdoCrudWebApi.Services.Contract;

namespace AdoCrudWebApi.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ServiceResponse<List<ProductDto>> GetAllProducts()
        {
            var response = new ServiceResponse<List<ProductDto>>();

            var products = _productRepository.GetAllProducts();

            if (products.Any())
            {

                List<ProductDto> productDto = new List<ProductDto>();
                foreach (var product in products)
                {
                    productDto.Add(new ProductDto()
                    {

                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        EntryDate = product.EntryDate,

                    });
                }

                response.Success = true;
                response.Data = productDto;
            }
            else
            {
                response.Success = false;
                response.Message = "No products found!";
            }

            return response;
        }


        public ServiceResponse<ProductDto> GetProductById(int productId)
        {
            var response = new ServiceResponse<ProductDto>();

            var product = _productRepository.GetProductById(productId);

            if (product != null)
            {

                var productDto = new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    EntryDate = product.EntryDate
                };

                response.Data = productDto;
                response.Success = true;

            }
            else
            {
                response.Success = false;
                response.Message = "Product not found!";
            }

            return response;
        }

        public ServiceResponse<string> AddProduct(AddProductDto productDto)
        {
            var response = new ServiceResponse<string>();

            var productModel = new Product
            {
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
                EntryDate = productDto.EntryDate,
            };

            var result = _productRepository.AddProduct(productModel);
            if (result)
            {
                response.Success = true;
                response.Message = "Product added successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
            }
            return response;
        }


        public ServiceResponse<string> UpdateProduct(UpdateProductDto productDto)
        {
            var response = new ServiceResponse<string>();

            var productModel = new Product
            {
                ProductId = productDto.ProductId,
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
                EntryDate = productDto.EntryDate,
            };

            var result = _productRepository.UpdateProduct(productModel);
            if (result)
            {
                response.Success = true;
                response.Message = "Product updated successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
            }
            return response;
        }

        public ServiceResponse<string> DeleteProduct(int productId)
        {
            var response = new ServiceResponse<string>();
            var result = _productRepository.DeleteProduct(productId);

            if (result)
            {
                response.Success = true;
                response.Message = "Product deleted successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
            }

            return response;
        }
    }
}
