//namespace GameWebApi.Test;
//internal class AuthGroupPermissionsControllerTest
//{
//}
using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace GameWebApi.Test
{
    public class AuthGroupPermissionsControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public AuthGroupPermissionsControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllAuthGroupPermissions()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthGroupPermissions/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authGroupPermissions = await response.Content.ReadFromJsonAsync<IEnumerable<AuthGroupPermissionsViewModel>>();
            Assert.NotNull(authGroupPermissions); // AuthGroupPermissions listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_AuthGroupPermissions_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthGroupPermissions/getSingle/1"); // Buradaki ID'yi mevcut bir AuthGroupPermissions ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authGroupPermissions = await response.Content.ReadFromJsonAsync<AuthGroupPermissionsViewModel>();
            Assert.NotNull(authGroupPermissions); // Belirtilen ID'ye sahip AuthGroupPermissions'un boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthGroupPermissionsAddDTO modeli oluşturun

            var newAuthGroupPermissions = new AuthGroupPermissionsAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir AuthGroupPermissionsAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/AuthGroupPermissions/add", newAuthGroupPermissions);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen AuthGroupPermissions'un geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthGroupPermissionsUpdateDTO modeli oluşturun

            var updateAuthGroupPermissions = new AuthGroupPermissionsUpdateDTO
            {
                
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/AuthGroupPermissions/update", updateAuthGroupPermissions);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen AuthGroupPermissions'un geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir AuthGroupPermissions ID'si belirleyin

            var authGroupPermissionsIdToDelete = 1; // Silinecek AuthGroupPermissions'un ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/AuthGroupPermissions/delete/{authGroupPermissionsIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen AuthGroupPermissions'un geri döndürülen içeriğini kontrol edin
        }
    }
}
