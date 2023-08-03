using Microsoft.Data.SqlClient; 
namespace ConsoleApp47
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter productId");
            var userSelection = Console.ReadLine();
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=MyShopDB;Trusted_Connection=True;");
           connection.Open();
            SqlCommand command = new SqlCommand($"select * from Products where id = @p1", connection);
            command.Parameters.AddWithValue("@p1", userSelection);
            var result = command.ExecuteReader();
            if(result.HasRows)
            {
                while(result.Read())
                {
                   Product p = new Product();
                    var check = result.GetValue(3);
                    p.Id = (int)result["Id"];
                    p.Name = (string)result["Name"];
                    p.Price = (int)result["Price"];
                   
                    p.Description= (string)result["Description"];
                    products.Add(p);
                }
            }
            if(!products.Any())
            {
                Console.WriteLine("No data found");
            }
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }

        }
    }
}