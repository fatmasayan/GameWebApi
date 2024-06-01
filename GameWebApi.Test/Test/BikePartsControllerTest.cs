//namespace GameWebApi.Test;

//internal class BikePartsControllerTest
//{
//}

using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test;

public class BikePartsControllerFunctionalTest
{
    private readonly HttpClient _client;

    public BikePartsControllerFunctionalTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
    }

    [Fact]
    public async Task GetAll_Returns_AllBikeParts()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/BikeParts/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var bikeParts = await response.Content.ReadFromJsonAsync<IEnumerable<BikePartsViewModel>>();
        Assert.NotNull(bikeParts); // BikeParts listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task GetSingle_Returns_BikePart_With_Specified_Id()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/BikeParts/getSingle/1"); // Buradaki ID'yi mevcut bir BikePart ID'siyle değiştirin

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var bikePart = await response.Content.ReadFromJsonAsync<BikePartsViewModel>();
        Assert.NotNull(bikePart); // Belirtilen ID'ye sahip BikePart'un boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir BikePartsAddDTO modeli oluşturun

        var newBikePart = new BikePartsAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir BikePartsAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/BikeParts/add", newBikePart);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        // Gerekirse, eklenen BikePart'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir BikePartsUpdateDTO modeli oluşturun

        var updateBikePart = new BikePartsUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir BikePartsUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/BikeParts/update", updateBikePart);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        // Gerekirse, güncellenen BikePart'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir BikePart ID'si belirleyin

        var bikePartIdToDelete = 1; // Silinecek BikePart'ın ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/BikeParts/delete/{bikePartIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        // Gerekirse, silinen BikePart'ın geri döndürülen içeriğini kontrol edin
    }
}

