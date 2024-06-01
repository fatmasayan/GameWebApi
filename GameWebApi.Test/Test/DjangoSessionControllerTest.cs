using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class DjangoSessionControllerTest
{
    private readonly HttpClient _client;

    public DjangoSessionControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin

    }

    [Fact]
    public async Task GetAll_Returns_AllDjangoSessions()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/DjangoSession/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var djangoSessions = await response.Content.ReadFromJsonAsync<IEnumerable<DjangoSessionViewModel>>();
        Assert.NotNull(djangoSessions); // DjangoSession listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir DjangoSessionAddDTO modeli oluşturun

        var newDjangoSession = new DjangoSessionAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir DjangoSessionAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/DjangoSession/add", newDjangoSession);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen DjangoSession'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir DjangoSessionUpdateDTO modeli oluşturun

        var updateDjangoSession = new DjangoSessionUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir DjangoSessionUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/DjangoSession/update", updateDjangoSession);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen DjangoSession'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir DjangoSession session_key belirleyin

        var djangoSessionKeyToDelete = "test_session_key"; // Silinecek DjangoSession'ın session_key'ini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/DjangoSession/delete/{djangoSessionKeyToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen DjangoSession'ın geri döndürülen içeriğini kontrol edin
    }
}
