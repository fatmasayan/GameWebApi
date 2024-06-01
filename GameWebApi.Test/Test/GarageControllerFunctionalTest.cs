using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // Stopwatch sınıfını ekleyin

namespace GameWebApi.Test
{
    public class GarageControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public GarageControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya ekleyin
        }

        [Fact]
        public async Task GetAll_Returns_AllGarages()
        {
            // Stopwatch sınıfını kullanarak zamanı ölçme işlemi başlatılıyor
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Arrange
            // Burada, herhangi bir özel düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/Garage/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var garages = await response.Content.ReadFromJsonAsync<IEnumerable<GarageViewModel>>(); // Bu satırda değişiklik yapıldı
            Assert.NotEmpty(garages); // Garaj listesinin boş olmadığını kontrol edin

            // Stopwatch sınıfını kullanarak zamanı durdurma işlemi gerçekleştiriliyor
            stopwatch.Stop();
            Console.WriteLine($"Uygulama başlatılma süresi: {stopwatch.Elapsed.TotalSeconds} saniye");
        }
    }
}
