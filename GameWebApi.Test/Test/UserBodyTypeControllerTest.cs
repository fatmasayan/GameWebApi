using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class UserBodyTypeControllerTest
{
    private readonly HttpClient _client;
    public UserBodyTypeControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllUserBodyTypes()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/UserBodyType/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var userBodyTypes = await response.Content.ReadFromJsonAsync<IEnumerable<UserBodyTypeViewModel>>();
        Assert.NotNull(userBodyTypes); // Kullanıcı vücut tipleri listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserBodyTypeAddDTO modeli oluşturun

        var newUserBodyType = new UserBodyTypeAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir UserBodyTypeAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/UserBodyType/add", newUserBodyType);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen kullanıcı vücut tipinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir UserBodyTypeUpdateDTO modeli oluşturun

        var updateUserBodyType = new UserBodyTypeUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir UserBodyTypeUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/UserBodyType/update", updateUserBodyType);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen kullanıcı vücut tipinin geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir kullanıcı vücut tipi ID belirleyin

        var userBodyTypeIdToDelete = 1; // Silinecek kullanıcı vücut tipi ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/UserBodyType/delete/{userBodyTypeIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen kullanıcı vücut tipinin geri döndürülen içeriğini kontrol edin
    }
}
