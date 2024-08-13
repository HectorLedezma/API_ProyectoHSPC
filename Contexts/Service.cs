using EventApi.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace EventApi.Context{
    public class MyService
    {
        private readonly string _connectionString;

        public MyService(IOptions<DatabaseSettings> dbSettings)
        {
            var settings = dbSettings.Value;
            _connectionString = $"Server={settings.Server};Database={settings.Database};User Id={settings.User};Password={settings.Password};TrustServerCertificate=True;";
        }

        public async void ConnectToDatabase()
        {
            Console.WriteLine("CONNECTING...");
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    Console.WriteLine("CONNECTED");
                    // Ejecuta operaciones en la base de datos
                }    
            }
            catch (System.Exception err)
            {
                Console.WriteLine("ERROR = "+err.ToString());
                throw;
            }
            
        }

        public void DisConnectToDatabase()
        {
            Console.WriteLine(_connectionString);
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {

                    connection.Close();
                    // Ejecuta operaciones en la base de datos
                }    
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error");
                throw;
            }
            
        }

        public async void EjecutarNoReturn(string sql){
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql,connection);
                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteReaderAsync();
                    Console.WriteLine($"Se ejecutó la query:\n{sql}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                }
            }
        }

        public DataTable Ejecutar(string sql){
            DataTable data = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql,connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine($"Se ejecutó la query:\n{sql}");
                    data.Load(reader);
                    return data;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return data;
                }
            }
        }
        
    }
}