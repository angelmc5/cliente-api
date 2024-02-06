using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace Clientes.UnitTest.API
{
    public class ReportesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public ReportesControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetReports_ReturnsCorrectResponse()
        {
            // Crea un cliente HTTPS
            var client = new HttpClient();

            // Define las fechas de inicio y fin para la prueba.
            var startDate = new DateTime(2024, 2, 5);
            var endDate = new DateTime(2024, 2, 6);
            var url = $"https://localhost:7228/api/reportes?inicioFecha={startDate}&finFecha={endDate}";
            
            // Envía una solicitud GET a la API.
            var response = await client.GetAsync(url);

            // Verifica que la respuesta tiene un código de estado exitoso.
            response.EnsureSuccessStatusCode();

            // Deserializa la respuesta a una lista de informes.
            //var reports = JsonConvert.DeserializeObject<List<Report>>(await response.Content.ReadAsStringAsync());

            // Aquí debes verificar que 'reportes' contiene los informes correctos.

            // Assert
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}


