using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace GameWebApi.Test;

//internal class CharItemsControllerTest
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
    public class CharItemsControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public CharItemsControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllCharItems()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/CharItems/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var charItems = await response.Content.ReadFromJsonAsync<IEnumerable<CharItemsViewModel>>();
            Assert.NotNull(charItems); // CharItems listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_CharItem_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/CharItems/getSingle/1"); // Buradaki ID'yi mevcut bir CharItem ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var charItem = await response.Content.ReadFromJsonAsync<CharItemsViewModel>();
            Assert.NotNull(charItem); // Belirtilen ID'ye sahip CharItem'ın boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir CharItemsAddDTO modeli oluşturun

            var newCharItem = new CharItemsAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir CharItemsAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/CharItems/add", newCharItem);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen CharItem'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir CharItemsUpdateDTO modeli oluşturun

            var updateCharItem = new CharItemsUpdateDTO
            {
                // Buraya güncelleme işlemi için gerekli özelliklerle bir CharItemsUpdateDTO örneği oluşturun
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/CharItems/update", updateCharItem);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen CharItem'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir CharItem ID'si belirleyin

            var charItemIdToDelete = 1; // Silinecek CharItem'ın ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/CharItems/delete/{charItemIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen CharItem'ın geri döndürülen içeriğini kontrol edin
        }
    }
}

