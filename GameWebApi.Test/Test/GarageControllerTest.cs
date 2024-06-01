using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameWebApi.Test;

public class GarageControllerTest
{
    private readonly HttpClient _client;
    public GarageControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099");
    }

    [Fact]
    public async Task GetAll_Returns_AllGarages()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/Garage/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var garages = await response.Content.ReadFromJsonAsync<IEnumerable<GarageViewModel>>();
        Assert.NotNull(garages); // Garaj listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir GarageAddDTO modeli oluşturun

        var newGarage = new GarageAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir GarageAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/Garage/add", newGarage);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen Garaj'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir GarageUpdateDTO modeli oluşturun

        var updateGarage = new GarageUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir GarageUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/Garage/update", updateGarage);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen Garaj'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir Garaj ID belirleyin

        var garageIdToDelete = 1; // Silinecek Garaj'ın ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/Garage/delete/{garageIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen Garaj'ın geri döndürülen içeriğini kontrol edin
    }
}
