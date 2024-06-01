using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace GameWebApi.Test;

//internal class AuthUserGroupsControllerTest
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
    public class AuthUserGroupsControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public AuthUserGroupsControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllAuthUserGroups()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthUserGroups/getList");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authUserGroups = await response.Content.ReadFromJsonAsync<IEnumerable<AuthUserGroupsViewModel>>();
            Assert.NotNull(authUserGroups); // AuthUserGroups listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_AuthUserGroup_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/AuthUserGroups/getSingle/1"); // Buradaki ID'yi mevcut bir AuthUserGroups ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var authUserGroup = await response.Content.ReadFromJsonAsync<AuthUserGroupsViewModel>();
            Assert.NotNull(authUserGroup); // Belirtilen ID'ye sahip AuthUserGroups'un boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthUserGroupsAddDTO modeli oluşturun

            var newAuthUserGroup = new AuthUserGroupsAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir AuthUserGroupsAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/AuthUserGroups/add", newAuthUserGroup);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen AuthUserGroups'un geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir AuthUserGroupsUpdateDTO modeli oluşturun

            var updateAuthUserGroup = new AuthUserGroupsUpdateDTO
            {
                // Buraya güncelleme işlemi için gerekli özelliklerle bir AuthUserGroupsUpdateDTO örneği oluşturun
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/AuthUserGroups/update", updateAuthUserGroup);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen AuthUserGroups'un geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir AuthUserGroups ID'si belirleyin

            var authUserGroupIdToDelete = 1; // Silinecek AuthUserGroups'un ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/AuthUserGroups/delete/{authUserGroupIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen AuthUserGroups'un geri döndürülen içeriğini kontrol edin
        }
    }
}

