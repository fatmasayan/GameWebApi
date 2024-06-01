//namespace GameWebApi.Test;

//internal class AuthUserControllerTest
//{
//}
using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test
{
    public class AuthUserControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public AuthUserControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllAuthUsers()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthUser/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authUsers = await response.Content.ReadFromJsonAsync<IEnumerable<AuthUserViewModel>>();
            Assert.NotNull(authUsers); // AuthUser listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_AuthUser_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthUser/getSingle/1"); // Buradaki ID'yi mevcut bir AuthUser ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authUser = await response.Content.ReadFromJsonAsync<AuthUserViewModel>();
            Assert.NotNull(authUser); // Belirtilen ID'ye sahip AuthUser'un boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthUserAddDTO modeli oluşturun

            var newAuthUser = new AuthUserAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir AuthUserAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/AuthUser/add", newAuthUser);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen AuthUser'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthUserUpdateDTO modeli oluşturun

            var updateAuthUser = new AuthUserUpdateDTO
            {
                // Buraya güncelleme işlemi için gerekli özelliklerle bir AuthUserUpdateDTO örneği oluşturun
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/AuthUser/update", updateAuthUser);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen AuthUser'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir AuthUser ID'si belirleyin

            var authUserIdToDelete = 1; // Silinecek AuthUser'ın ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/AuthUser/delete/{authUserIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen AuthUser'ın geri döndürülen içeriğini kontrol edin
        }
    }
}
