
using ApiAppTransporte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;
namespace ApiAppTransporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionRutasController : Controller
    {
        private readonly HttpClient _httpClient;

        public UbicacionRutasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetUbicacionActual()
        {
            string springUrl = "http://host.docker.internal:8080/api/rutas"; 

            try
            {
                var response = await _httpClient.GetAsync(springUrl);
                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Error al obtener rutas desde Spring");

                var json = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var rutasFiltradas = root.EnumerateArray()
                    .Select(ruta => new UbicacionRuta
                    {
                        id = ruta.GetProperty("id").GetInt32(),
                        nombre = ruta.GetProperty("nombre").ToString(),
                        distancia = ruta.TryGetProperty("distancia", out var dist)
                                    && dist.ValueKind != JsonValueKind.Null ? dist.ToString() : "",
                        placa = ruta.TryGetProperty("placa", out var placa)
                                && placa.ValueKind != JsonValueKind.Null ? placa.ToString() : ""
                    })
                    .ToList();

                return Ok(rutasFiltradas);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error de conexión: {ex.Message}");
            }
        }

    }
}
