using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class UserOwendGarageControllerTest
{
    private readonly HttpClient _client;
    public UserOwendGarageControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserOwnedGarages()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserOwendGarage/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userOwnedGarages = await response.Content.ReadFromJsonAsync<IEnumerable<UserOwendGarageViewModel>>();
        Assert.NotNull(userOwnedGarages); // Kullanıcının sahip olduğu garajlar listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserOwendGarageAddDTO modeli oluşturun

        var newUserOwnedGarage = new UserOwendGarageAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserOwendGarageAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserOwendGarage/add", newUserOwnedGarage);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcıya ait garajın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserOwendGarageUpdateDTO modeli oluşturun

        var updateUserOwnedGarage = new UserOwendGarageUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserOwendGarageUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserOwendGarage/update", updateUserOwnedGarage);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcıya ait garajın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcıya ait garaj ID belirleyin

        var userOwnedGarageIdToDelete = 1; // Silinecek kullanıcıya ait garajın ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserOwendGarage/delete/{userOwnedGarageIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcıya ait garajın geri döndürülen içeriğini kontrol edin
    }
}
