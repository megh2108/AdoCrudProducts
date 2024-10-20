using AdoCrudWebApi.Data.Contract;
using AdoCrudWebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace AdoCrudWebApi.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductTable", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row["ProductName"].ToString(),
                    ProductPrice = Convert.ToInt32(row["ProductPrice"]),
                    EntryDate = Convert.ToDateTime(row["EntryDate"])
                };
                products.Add(product);
            }

            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = new Product();
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductTable WHERE ProductId = @ProductId", con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    product = new Product
                    {
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        ProductName = row["ProductName"].ToString(),
                        ProductPrice = Convert.ToInt32(row["ProductPrice"]),
                        EntryDate = Convert.ToDateTime(row["EntryDate"])
                    };
                }
            }

            return product;
        }

        public bool AddProduct(Product product)
        {
            var result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ProductTable (ProductName, ProductPrice, EntryDate) VALUES (@ProductName, @ProductPrice, @EntryDate)", con);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@EntryDate", product.EntryDate);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
            }
            return result;
        }

        public bool UpdateProduct(Product product)
        {
            var result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("UPDATE ProductTable SET ProductName = @ProductName, ProductPrice = @ProductPrice, EntryDate = @EntryDate WHERE ProductId = @ProductId", con);
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@EntryDate", product.EntryDate);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                result = true;
            }
            return result;
        }

        public bool DeleteProduct(int productId)
        {
            var result = false;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("mydb")))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM ProductTable WHERE ProductId = @ProductId", con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
            }
            return result;
        }




    }
}
