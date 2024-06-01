using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class UserCharControllerTest
{

    private readonly HttpClient _client;
    public UserCharControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserChars()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserChar/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userChars = await response.Content.ReadFromJsonAsync<IEnumerable<UserCharViewModel>>();
        Assert.NotNull(userChars); // Kullanıcı karakterleri listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserCharAddDTO modeli oluşturun

        var newUserChar = new UserCharAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserCharAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserChar/add", newUserChar);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcı karakterinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserCharUpdateDTO modeli oluşturun

        var updateUserChar = new UserCharUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserCharUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserChar/update", updateUserChar);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcı karakterinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcı karakteri ID belirleyin

        var userCharIdToDelete = 1; // Silinecek kullanıcı karakteri ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserChar/delete/{userCharIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcı karakterinin geri döndürülen içeriğini kontrol edin
    }
}
