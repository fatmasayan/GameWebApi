using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test;
public class UserBikesControllerTest
{
    private readonly HttpClient _client;
    public UserBikesControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserBikes()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserBikes/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userBikes = await response.Content.ReadFromJsonAsync<IEnumerable<UserBikesViewModel>>();
        Assert.NotNull(userBikes); // Kullanıcı bisikleti listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserBikesAddDTO modeli oluşturun

        var newUserBike = new UserBikesAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserBikesAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserBikes/add", newUserBike);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcı bisikletinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserBikesUpdateDTO modeli oluşturun

        var updateUserBike = new UserBikesUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserBikesUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserBikes/update", updateUserBike);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcı bisikletinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcı bisikleti ID belirleyin

        var userBikeIdToDelete = 1; // Silinecek kullanıcı bisikleti ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserBikes/delete/{userBikeIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcı bisikletinin geri döndürülen içeriğini kontrol edin
    }
}

