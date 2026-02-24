using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TechApp.Models;
using TechApp.Data;

namespace TechApp.Controllers
{
    public class EquipoController
    {
        public List<Equipo> ObtenerTodos()
        {
            var lista = new List<Equipo>();

            using (SqlConnection conn = DbContext.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Marca, Precio, Stock FROM Equipos";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Equipo
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"]?.ToString() ?? string.Empty, // evita CS8601
                            Marca = reader["Marca"]?.ToString() ?? string.Empty,   // evita CS8601
                            Precio = (decimal)reader["Precio"],
                            Stock = (int)reader["Stock"]
                        });
                    }
                }
            }

            return lista;
        }

        public void InsertarEquipo(Equipo e)
        {
            using (SqlConnection conn = DbContext.Instance.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Equipos (Nombre, Marca, Precio, Stock) VALUES (@n, @m, @p, @s)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", e.Nombre);
                    cmd.Parameters.AddWithValue("@m", e.Marca);
                    cmd.Parameters.AddWithValue("@p", e.Precio);
                    cmd.Parameters.AddWithValue("@s", e.Stock);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
