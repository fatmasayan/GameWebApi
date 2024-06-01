using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class UserOwnedAchievementControllerTest
{
    private readonly HttpClient _client;
    public UserOwnedAchievementControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserOwnedAchievements()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserOwnedAchievement/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userOwnedAchievements = await response.Content.ReadFromJsonAsync<IEnumerable<UserOwnedAchievementViewModel>>();
        Assert.NotNull(userOwnedAchievements); // Kullanıcının sahip olduğu başarımların listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserOwnedAchievementAddDTO modeli oluşturun

        var newUserOwnedAchievement = new UserOwnedAchievementAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserOwnedAchievementAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserOwnedAchievement/add", newUserOwnedAchievement);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcıya ait başarının geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserOwnedAchievementUpdateDTO modeli oluşturun

        var updateUserOwnedAchievement = new UserOwnedAchievementUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserOwnedAchievementUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserOwnedAchievement/update", updateUserOwnedAchievement);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcıya ait başarının geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcıya ait başarı ID belirleyin

        var userOwnedAchievementIdToDelete = 1; // Silinecek kullanıcıya ait başarının ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserOwnedAchievement/delete/{userOwnedAchievementIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcıya ait başarının geri döndürülen içeriğini kontrol edin
    }
}
