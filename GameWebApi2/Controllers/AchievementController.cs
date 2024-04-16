namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AchievementController : ControllerBase
{
    private readonly IAchievementRepository _achievementRepository;//vertabanı işlemlerinin yapıldığı sınıftan bir nesne oluşturuldu 
    private readonly IMapper _mapper; //mapping işlelerinde kullanılması icinbir nesne
   
    public AchievementController(IAchievementRepository achievementRepository, IMapper mapper)
    {
        _achievementRepository = achievementRepository; 
        _mapper = mapper;
    }///

    [HttpGet("getList")]// listeleme işlemi 
    public IActionResult GetAll()
    {
        var resultList = _achievementRepository.GetAll(); //Rpository sınıfda yazılan metod kullanıldı.

        return Ok(_mapper.Map<List<AchievementViewModel>>(resultList)); //listenin id gibi görünmesini istemediğimiz özellikleri için view model oluşturuldu dönen liste view modele dönüştürüldü.
    }

    // filterlı listeleme işlemei liste içinde isenen id'li öğeyi getirmek  için 
    [HttpGet("getSingle/{id}")] 
    public IActionResult Get(int id)
    {
        return Ok(_achievementRepository.Get(x => x.id == id)); //yazılan id'deki nesneyi getirir
    }

    //listeye-tabloya ekleme işlemi yapmak için kullanılan endpoint 
    [HttpPost("add")]
    public IActionResult Add(AchievementAddDTO model) //ekle işleminde id gibi erişilmesi-değiştirilmesi istenmeyen değerler için DTO tanımlayıp sadece alınacak olan değişken değerleri alınır.
    {
        if (model == null) //
            return BadRequest();

        var dataModel = _mapper.Map<Achievement>(model); //dto olarak gelen nesneyi Achievement sınıf nesenesine dönüştürme işlemi : mapping
        //dönüştürme işlemi yapmadan ekleme yapamam çünkü tablodaki tüm değerlere erişim yok dto da
        var result = _achievementRepository.Add(dataModel); //ekleme islemi yapıldı

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(AchievementUpdateDTO model) //Güncelleme işlemi içinde updateDTO şeklinde modeller tnaımlandı. Güncelleme işlemlerinde öğeye  id ile erişilir ona göre güncellenir 
    {                                               //değişlikler yapılarak güncelleme  yapılan        
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Achievement>(model); // dto nesnesini Achievement sınıf nesnesine dönüştürüyoruz 
        var result = _achievementRepository.Update(dataModel); //güncelleme işlemi yapıldı
        //Repositoryya gönderiyoruz _achievementRepository AchievementRepo dan üretilen bir nesne ve Generic yapıdaki Repositorye oluşturlan metodlara erişerek işlem yapılır
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _achievementRepository.Delete(x => x.id == id);  //id göre silme işlemi yapılır

        return Ok(result);
    }
}
