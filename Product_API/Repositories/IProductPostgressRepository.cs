using Npgsql;
using Product_API.Models;

namespace Product_API.Repositories
{
    public class ProductPostgressRepository : IProductRepository
    {
        public string ConnectionString= "Host=localhost;Port=5432;Database=TestDB;username=postgres;Password=Akramjon_09;";
        public Product Add(Product product)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {

                connection.Open();
                try
                {
                    using NpgsqlCommand cmd = new NpgsqlCommand(@$"insert into products(Name,Description,PhotoPath) values ('{product.Name}','{product.Description}','{product.PhotoPath}') ", connection);
                    var reader = cmd.ExecuteNonQuery();


                }
                catch
                {
                    Console.WriteLine("Something wrong with getting all students");
                }
            }
            return product;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {

                connection.Open();
                try
                {
                    Product product = new Product();
                    using NpgsqlCommand cmd = new NpgsqlCommand(@$"select username from users ", connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        product.Name = reader.GetString(0);
                        product.Description = reader.GetString(1);
                        product.PhotoPath = reader.GetString(2);
                        products.Add(product);
                    }

                }
                catch
                {
              
                }
                return products;
            }
        }

    }
}
