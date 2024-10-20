using AdoCrudWebApi.Models;

namespace AdoCrudWebApi.Data.Contract
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        bool AddProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int productId);

        Product GetProductById(int productId);
    }

}
