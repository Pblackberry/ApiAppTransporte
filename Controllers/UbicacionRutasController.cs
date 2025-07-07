
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ApiAppTransporte.Models;
namespace ApiAppTransporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionRutasController : Controller
    {
        string connectionString = "Server=LAPTOP-OJJP1HNK;Database=SLR_DB;User Id=adminRutas;Password=admin;TrustServerCertificate=True;";
        [Route("[action]")]
        [HttpGet]
        public ActionResult GetUbicacionActual(int rutaId)
        {

            string query = $"SELECT TOP 1 longitud, latitud FROM Ruta WHERE id = @rutaId";
            Rutas.Coordenadas ubicacion = new();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@rutaId", rutaId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ubicacion.latitud = double.Parse(reader.GetValue(0).ToString());
                            ubicacion.longitud = double.Parse(reader.GetValue(1).ToString());

                        }
                    }
                }
                
            }
            return Ok(ubicacion);

        }
    }
}
