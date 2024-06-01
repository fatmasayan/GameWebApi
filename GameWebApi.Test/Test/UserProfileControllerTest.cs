using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class UserProfileControllerTest
{
    private readonly HttpClient _client;
    public UserProfileControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserProfiles()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserProfile/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userProfiles = await response.Content.ReadFromJsonAsync<IEnumerable<UserProfileViewModel>>();
        Assert.NotNull(userProfiles); // Kullanıcı profillerinin listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserProfileAddDTO modeli oluşturun

        var newUserProfile = new UserProfileAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserProfileAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserProfile/add", newUserProfile);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcı profili ile ilgili geri döndürülen içeriği kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserProfileUpdateDTO modeli oluşturun

        var updateUserProfile = new UserProfileUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserProfileUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserProfile/update", updateUserProfile);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcı profili ile ilgili geri döndürülen içeriği kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcı profil ID belirleyin

        var userProfileIdToDelete = 1; // Silinecek kullanıcı profili ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserProfile/delete/{userProfileIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcı profili ile ilgili geri döndürülen içeriği kontrol edin
    }

}
