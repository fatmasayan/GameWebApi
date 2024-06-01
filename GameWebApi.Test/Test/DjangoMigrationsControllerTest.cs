using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test;

public class DjangoMigrationsControllerTest
{
    private readonly HttpClient _client;
    public DjangoMigrationsControllerTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
    }

    [Fact]
    public async Task GetAll_Returns_AllDjangoMigrations()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/DjangoMigrations/getList");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var djangoMigrations = await response.Content.ReadFromJsonAsync<IEnumerable<DjangoMigrationsViewModel>>();
        Assert.NotNull(djangoMigrations); // DjangoMigrations listesinin boş olmadığını kontrol edin
    }

    [Fact]
    public async Task GetSingle_Returns_DjangoMigration_With_Specified_Id()
    {
        // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

        // Act
        var response = await _client.GetAsync("api/DjangoMigrations/getSingle/1"); // Buradaki ID'yi mevcut bir DjangoMigrations ID'siyle değiştirin

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
        var djangoMigration = await response.Content.ReadFromJsonAsync<DjangoMigrationsViewModel>();
        Assert.NotNull(djangoMigration); // Belirtilen ID'ye sahip DjangoMigration'ın boş olmadığını kontrol edin
    }

    [Fact]
    public async Task Add_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir DjangoMigrationsAddDTO modeli oluşturun

        var newDjangoMigration = new DjangoMigrationsAddDTO
        {
            // Buraya ekleme işlemi için gerekli özelliklerle bir DjangoMigrationsAddDTO örneği oluşturun
        };

        // Act
        var response = await _client.PostAsJsonAsync("api/DjangoMigrations/add", newDjangoMigration);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, eklenen DjangoMigration'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Update_Returns_Success_Result()
    {
        // Arrange: Test için kullanılacak olan geçerli bir DjangoMigrationsUpdateDTO modeli oluşturun

        var updateDjangoMigration = new DjangoMigrationsUpdateDTO
        {
            // Buraya güncelleme işlemi için gerekli özelliklerle bir DjangoMigrationsUpdateDTO örneği oluşturun
        };

        // Act
        var response = await _client.PutAsJsonAsync("api/DjangoMigrations/update", updateDjangoMigration);

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, güncellenen DjangoMigration'ın geri döndürülen içeriğini kontrol edin
    }

    [Fact]
    public async Task Delete_Returns_Success_Result()
    {
        // Arrange: Silme işlemi için bir DjangoMigrations ID'si belirleyin

        var djangoMigrationIdToDelete = 1; // Silinecek DjangoMigration'ın ID'sini buraya yazın

        // Act
        var response = await _client.DeleteAsync($"api/DjangoMigrations/delete/{djangoMigrationIdToDelete}");

        // Assert
        response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
                                            // Gerekirse, silinen DjangoMigration'ın geri döndürülen içeriğini kontrol edin
    }
}
