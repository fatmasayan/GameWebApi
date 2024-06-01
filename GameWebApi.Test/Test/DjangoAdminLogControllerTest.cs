using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace GameWebApi.Test;

//internal class DjangoAdminLogControllerTest
//{
//}

using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using GameWebApi2.DTO;

namespace GameWebApi.Test
{
    public class DjangoAdminLogControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public DjangoAdminLogControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllDjangoAdminLogs()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/DjangoAdminLog/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var djangoAdminLogs = await response.Content.ReadFromJsonAsync<IEnumerable<DjangoAdminLogViewModel>>();
            Assert.NotNull(djangoAdminLogs); // DjangoAdminLog listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_DjangoAdminLog_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/DjangoAdminLog/getSingle/1"); // Buradaki ID'yi mevcut bir DjangoAdminLog ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var djangoAdminLog = await response.Content.ReadFromJsonAsync<DjangoAdminLogViewModel>();
            Assert.NotNull(djangoAdminLog); // Belirtilen ID'ye sahip DjangoAdminLog'ın boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir DjangoAdminLogAddDTO modeli oluşturun

            var newDjangoAdminLog = new DjangoAdminLogAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir DjangoAdminLogAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/DjangoAdminLog/add", newDjangoAdminLog);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen DjangoAdminLog'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir DjangoAdminLogUpdateDTO modeli oluşturun

            var updateDjangoAdminLog = new DjangoAdminLogUpdateDTO
            {
                // Buraya güncelleme işlemi için gerekli özelliklerle bir DjangoAdminLogUpdateDTO örneği oluşturun
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/DjangoAdminLog/update", updateDjangoAdminLog);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen DjangoAdminLog'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir DjangoAdminLog ID'si belirleyin

            var djangoAdminLogIdToDelete = 1; // Silinecek DjangoAdminLog'ın ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/DjangoAdminLog/delete/{djangoAdminLogIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen DjangoAdminLog'ın geri döndürülen içeriğini kontrol edin
        }
    }
}
