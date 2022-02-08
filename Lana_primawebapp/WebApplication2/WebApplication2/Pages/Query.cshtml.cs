using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlDataReader = Microsoft.Data.SqlClient.SqlDataReader;
using SqlException = Microsoft.Data.SqlClient.SqlException;
namespace WebApplication2.Pages
{
    public class QueryModel : PageModel
    {
        public string errore { get; set; }
        public string dato0 { get; set; }
        public string dato1 { get; set; }
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    String sql = "SELECT LastName, FirstName FROM Employees";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dato0 = reader.GetString(0);
                                dato1 = reader.GetString(1);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                errore = e.ToString();
            }

        }
    }
}