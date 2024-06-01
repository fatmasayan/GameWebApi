//namespace GameWebApi.Test;
//internal class AuthUserAndUserPermissionsControllerTest
//{
//}
using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test;

public class AuthUserAndUserPermissionsControllerFunctionalTest
{
    private readonly HttpClient _client;

    public AuthUserAndUserPermissionsControllerFunctionalTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
    }

    [Fact]
    public async Task GetAll_Returns_AllAuthUserAndUserPermissions()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/AuthUserAndUserPermissions/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var authUserAndUserPermissions = await response.Content.ReadFromJsonAsync<IEnumerable<AuthUserAndUserPermissionsViewModel>>();
        Assert.NotNull(authUserAndUserPermissions); // AuthUserAndUserPermissions listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task GetSingle_Returns_AuthUserAndUserPermissions_With_Specified_Id()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/AuthUserAndUserPermissions/getSingle/1"); // Buradaki ID'yi mevcut bir AuthUserAndUserPermissions ID'siyle değiştirin

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var authUserAndUserPermissions = await response.Content.ReadFromJsonAsync<AuthUserAndUserPermissionsViewModel>();
        Assert.NotNull(authUserAndUserPermissions); // Belirtilen ID'ye sahip AuthUserAndUserPermissions'un boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir AuthUserAndUserPermissionsAddDTO modeli oluşturun

        var newAuthUserAndUserPermissions = new AuthUserAndUserPermissionsAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir AuthUserAndUserPermissionsAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/AuthUserAndUserPermissions/add", newAuthUserAndUserPermissions);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        // Gerekirse, eklenen AuthUserAndUserPermissions'un geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir AuthUserAndUserPermissionsUpdateDTO modeli oluşturun

        var updateAuthUserAndUserPermissions = new AuthUserAndUserPermissionsUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir AuthUserAndUserPermissionsUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/AuthUserAndUserPermissions/update", updateAuthUserAndUserPermissions);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        // Gerekirse, güncellenen AuthUserAndUserPermissions'un geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir AuthUserAndUserPermissions ID'si belirleyin

        var authUserAndUserPermissionsIdToDelete = 1; // Silinecek AuthUserAndUserPermissions'un ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/AuthUserAndUserPermissions/delete/{authUserAndUserPermissionsIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        // Gerekirse, silinen AuthUserAndUserPermissions'un geri döndürülen içeriğini kontrol edin
    }
}
