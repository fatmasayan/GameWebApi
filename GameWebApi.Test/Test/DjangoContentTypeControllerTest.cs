//namespace GameWebApi.Test;

//internal class DjangoContentTypeControllerTest
//{
//}
using GameWebApi2.DTO;
using GameWebApi2.ViewModels;
using System.Net.Http.Json;

namespace GameWebApi.Test
{
    public class DjangoContentTypeControllerFunctionalTest
    {
        private readonly HttpClient _client;

        public DjangoContentTypeControllerFunctionalTest()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5099"); // API URL'sini buraya uygun olarak değiştirin
        }

        [Fact]
        public async Task GetAll_Returns_AllDjangoContentTypes()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/DjangoContentType/getListe");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var djangoContentTypes = await response.Content.ReadFromJsonAsync<IEnumerable<DjangoContentTypeViewModel>>();
            Assert.NotNull(djangoContentTypes); // DjangoContentType listesinin boş olmadığını kontrol edin
        }

        [Fact]
        public async Task GetSingle_Returns_DjangoContentType_With_Specified_Id()
        {
            // Arrange: Herhangi bir düzenleme yapmanıza gerek yok, çünkü gerçek bir API isteği gönderiyoruz.

            // Act
            var response = await _client.GetAsync("api/DjangoContentType/getSingle/1"); // Buradaki ID'yi mevcut bir DjangoContentType ID'siyle değiştirin

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            var djangoContentType = await response.Content.ReadFromJsonAsync<DjangoContentTypeViewModel>();
            Assert.NotNull(djangoContentType); // Belirtilen ID'ye sahip DjangoContentType'ın boş olmadığını kontrol edin
        }

        [Fact]
        public async Task Add_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir DjangoContentTypeAddDTO modeli oluşturun

            var newDjangoContentType = new DjangoContentTypeAddDTO
            {
                // Buraya ekleme işlemi için gerekli özelliklerle bir DjangoContentTypeAddDTO örneği oluşturun
            };

            // Act
            var response = await _client.PostAsJsonAsync("api/DjangoContentType/add", newDjangoContentType);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, eklenen DjangoContentType'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Update_Returns_Success_Result()
        {
            // Arrange: Test için kullanılacak olan geçerli bir DjangoContentTypeUpdateDTO modeli oluşturun

            var updateDjangoContentType = new DjangoContentTypeUpdateDTO
            {
                // Buraya güncelleme işlemi için gerekli özelliklerle bir DjangoContentTypeUpdateDTO örneği oluşturun
            };

            // Act
            var response = await _client.PutAsJsonAsync("api/DjangoContentType/update", updateDjangoContentType);

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, güncellenen DjangoContentType'ın geri döndürülen içeriğini kontrol edin
        }

        [Fact]
        public async Task Delete_Returns_Success_Result()
        {
            // Arrange: Silme işlemi için bir DjangoContentType ID'si belirleyin

            var djangoContentTypeIdToDelete = 1; // Silinecek DjangoContentType'ın ID'sini buraya yazın

            // Act
            var response = await _client.DeleteAsync($"api/DjangoContentType/delete/{djangoContentTypeIdToDelete}");

            // Assert
            response.EnsureSuccessStatusCode(); // HTTP 200 OK döndüğünü kontrol edin
            // Gerekirse, silinen DjangoContentType'ın geri döndürülen içeriğini kontrol edin
        }
    }
}
