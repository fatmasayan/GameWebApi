namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class UserOwnedAchievementController : ControllerBase
{
    private readonly IUserOwnedAchievementRepository _userOwnedAchievementRepository;
    private readonly IMapper _mapper;

    public UserOwnedAchievementController(IUserOwnedAchievementRepository userOwnedAchievementRepository, IMapper mapper)
    {
        _userOwnedAchievementRepository = userOwnedAchievementRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _userOwnedAchievementRepository.GetAll( x => x.achievement_id, x => x.loginUser_id);

        return Ok(_mapper.Map<List<UserOwnedAchievementViewModel>>(resultList));
    }

    

    // filterlı listeleme oldu 
    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userOwnedAchievementRepository.Get(x => x.id == id, x => x.achievement_id, x => x.loginUser_id));
    }

    [HttpPost]
    public IActionResult Add(UserOwnedAchievementAddDTO model) 
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserOwnedAchievement>(model); 
        var result = _userOwnedAchievementRepository.Add(dataModel); 

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(UserOwnedAchievementUpdateDTO model) 
    {                                                      
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserOwnedAchievement>(model);
        var result = _userOwnedAchievementRepository.Update(dataModel); 
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userOwnedAchievementRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
