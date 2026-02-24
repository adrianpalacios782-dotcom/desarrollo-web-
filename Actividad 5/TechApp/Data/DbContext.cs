using Microsoft.Data.SqlClient;

namespace TechApp.Data
{
    public class DbContext
    {
        private static DbContext? instance;

        // Ajuste de cadena de conexión para evitar error SSL
        private readonly string _connectionString =
            "Server=localhost;Database=TechInventoryDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        private DbContext() { }

        public static DbContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new DbContext();
                return instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
