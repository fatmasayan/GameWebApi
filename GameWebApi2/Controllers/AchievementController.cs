

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class AchievementController : ControllerBase
{
    private readonly IAchievementRepository _achievementRepository;
    private readonly IMapper _mapper;
   
    public AchievementController(IAchievementRepository achievementRepository, IMapper mapper)
    {
        _achievementRepository = achievementRepository;
        _mapper = mapper;
    }///

    [HttpGet]// listeleme işlemi buruda herhangi bir mapping işlemi yapmaya gerek yok
    public IActionResult GetAll()
    {
        var resultList = _achievementRepository.GetAll();

        return Ok(_mapper.Map<List<AchievementViewModel>>(resultList));
    }

    // filterli listeleme oldu  (viewmodelli örnek) - Contains:içermek
    [HttpGet("{keyword}")] //get al içinde tanımladığımız değişken için getirme işlemi yapar
    public IActionResult GetAll(string keyword)
    {
        return Ok(_achievementRepository.GetAll(x => x.achievementName.Contains(keyword)));
    }

    // filterlı listeleme oldu 
    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_achievementRepository.Get(x => x.id == id)); //yazılan id'deki nesneyi getirir
    }

    [HttpPost]
    public IActionResult Add(AchievementAddDTO model) //ekle işleminde id gibi erişilmesi istemediğimiz değerler için DTO tanımlayıp sadece alınacak olan değişken değerlerini alıyoruz
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Achievement>(model); //dto olarak gelen nesneyi Achievement sınıf nesenesine dönüştürme işlemi : mapping
        //dönüştürme işlemi yapmadan ekleme yapamam çünkü tablodaki tüm değerlere erişim yok dto da
        var result = _achievementRepository.Add(dataModel); //ekleme islemi yapıldı

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(AchievementUpdateDTO model) //Güncelleme işlemi model dto olarak alıyoruz id ve değiştirmemek için belirlli özellikler üzerinde 
    {                                               //değişlikler yapılarak güncelleme  yapılan        
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Achievement>(model); // dto nesnesini Achievement sınıf nesnesine dönüştürüyoruz 
        var result = _achievementRepository.Update(dataModel); //güncelleme işlemi yapıldı
        //Repositoryya gönderiyoruz _achievementRepository AchievementRepo dan üretilen bir nesne ve Generic repoda oluşturlan metodlara erişerek işlem yapılır
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _achievementRepository.Delete(x => x.id == id);  //id göre silme işlemi yapılır

        return Ok(result);
    }
}
