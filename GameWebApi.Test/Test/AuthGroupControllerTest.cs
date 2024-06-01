//namespace GameWebApi.Test
//{
//    public class AuthGroupControllerTest
//    {

//    }
//}
using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;
namespace GameWebApi.Test
{
    public class AuthGroupControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public AuthGroupControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllAuthGroups()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthGroup/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authGroups = await response.Content.ReadFromJsonAsync<IEnumerable<AuthGroupViewModel>>();
            Assert.NotNull(authGroups); // AuthGroup listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_AuthGroup_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthGroup/getSingle/1"); // Buradaki ID'yi mevcut bir AuthGroup ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authGroup = await response.Content.ReadFromJsonAsync<AuthGroupViewModel>();
            Assert.NotNull(authGroup); // Belirtilen ID'ye sahip AuthGroup'un boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthGroupAddDTO modeli oluşturun

            var newAuthGroup = new AuthGroupAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir AuthGroupAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/AuthGroup/add", newAuthGroup);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen AuthGroup'un geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthGroupUpdateDTO modeli oluşturun

            var updateAuthGroup = new AuthGroupUpdateDTO
            {
                // Buraya güncelleme işlemi için gerekli özelliklerle bir AuthGroupUpdateDTO örneği oluşturun
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/AuthGroup/update", updateAuthGroup);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen AuthGroup'un geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir AuthGroup ID'si belirleyin

            var authGroupIdToDelete = 1; // Silinecek AuthGroup'un ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/AuthGroup/delete/{authGroupIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen AuthGroup'un geri döndürülen içeriğini kontrol edin
        }
    }
}

