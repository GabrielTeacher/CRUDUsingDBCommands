using CRUDUsingDBCommands.Common;
using CRUDUsingDBCommands.Data;
using System.Data.SqlClient;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public static void TestInsertData()
        {
            var myList = new List<Product>
            {
                new Product { Id = 1, Name = "gab", Price=32, Stock=14 },

            };

            ProductData productData = new ProductData();

            // Act
            var result = productData.GetAll();

            // Assert
            //Assert.Greater(result.Count, 0);
            var connectionString = "Data Source=.\\SQLEXPRESS;Database=product;Integrated Security=True;";
            var query = "SELECT * FROM product WHERE Id = @Id";
            var id = 1;

            // Act
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    // Assert
                    Assert.IsTrue(reader.HasRows);
                    while (reader.Read())
                    {
                        var expectedName = "gab";
                        var actualName = reader.GetString(reader.GetOrdinal("name"));
                        Assert.AreEqual(expectedName, actualName);
                    }
                }
            }
        }
    }
}
