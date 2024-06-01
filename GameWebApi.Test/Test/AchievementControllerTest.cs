using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;
//namespace GameWebApi.Test;

//public class AchievementControllerTest
//{

//}


namespace GameWebApi.Test
{
    public class AchievementControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public AchievementControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllAchievements()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.
            // Arrange
            var stopwatch = Stopwatch.StartNew();
            // Act
            var response = await _client.GetAsync("api/Achievement/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var achievements = await response.Content.ReadFromJsonAsync<IEnumerable<AchievementViewModel>>(); // Değişiklik yapıldı
            Assert.NotNull(achievements); // Achievement listesinin boş olmadığını kontrol edin
            stopwatch.Stop();
            Console.WriteLine($"GetAll test successful in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
