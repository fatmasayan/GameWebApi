using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test;

public class UserInventoryControllerTest
{
    private readonly HttpClient _client;
    public UserInventoryControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserInventories()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserInventory/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userInventories = await response.Content.ReadFromJsonAsync<IEnumerable<UserInventoryViewModel>>();
        Assert.NotNull(userInventories); // Kullanıcı envanteri listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserInventoryAddDTO modeli oluşturun

        var newUserInventory = new UserInventoryAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserInventoryAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserInventory/add", newUserInventory);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcı envanterinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserInventoryUpdateDTO modeli oluşturun

        var updateUserInventory = new UserInventoryUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserInventoryUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserInventory/update", updateUserInventory);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcı envanterinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcı envanteri ID belirleyin

        var userInventoryIdToDelete = 1; // Silinecek kullanıcı envanteri ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserInventory/delete/{userInventoryIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcı envanterinin geri döndürülen içeriğini kontrol edin
    }
}
