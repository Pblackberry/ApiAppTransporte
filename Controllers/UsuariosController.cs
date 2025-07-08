using ApiAppTransporte.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace ApiAppTransporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public UsuariosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> EnviarDatosUsuario([FromBody][Required] Usuario newUser)
        {
            var jsonContent = new StringContent(
            JsonSerializer.Serialize(newUser),
            Encoding.UTF8,
            "application/json");

            string springUri = "http://host.docker.internal:8080/api/usuarios";
            var response = await _httpClient.PostAsync(springUri, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return Ok("Datos reenviados correctamente.");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
