using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class UserOwendMapControllerTest
{
    private readonly HttpClient _client;
    public UserOwendMapControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserOwnedMaps()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserOwendMap/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userOwnedMaps = await response.Content.ReadFromJsonAsync<IEnumerable<UserOwendMapViewModel>>();
        Assert.NotNull(userOwnedMaps); // Kullanıcının sahip olduğu haritaların listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserOwendMapAddDTO modeli oluşturun

        var newUserOwnedMap = new UserOwendMapAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserOwendMapAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserOwendMap/add", newUserOwnedMap);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcıya ait haritanın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserOwendMapUpdateDTO modeli oluşturun

        var updateUserOwnedMap = new UserOwendMapUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserOwendMapUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserOwendMap/update", updateUserOwnedMap);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcıya ait haritanın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcıya ait harita ID belirleyin

        var userOwnedMapIdToDelete = 1; // Silinecek kullanıcıya ait haritanın ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserOwendMap/delete/{userOwnedMapIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcıya ait haritanın geri döndürülen içeriğini kontrol edin
    }
}
