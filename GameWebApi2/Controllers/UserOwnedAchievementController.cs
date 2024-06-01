namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserOwnedAchievementController : ControllerBase
{
    private readonly IUserOwnedAchievementRepository _userOwnedAchievementRepository;
    private readonly IMapper _mapper;

    public UserOwnedAchievementController(IUserOwnedAchievementRepository userOwnedAchievementRepository, IMapper mapper)
    {
        _userOwnedAchievementRepository = userOwnedAchievementRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userOwnedAchievementRepository.GetAll( x => x.achievement, x => x.loginUser);

        return Ok(_mapper.Map<List<UserOwnedAchievementViewModel>>(resultList));
    }

    

    // filterlı listeleme oldu 
    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        var result = _userOwnedAchievementRepository.Get(x => x.id == id, y => y.achievement, z => z.loginUser);
        return Ok(_mapper.Map<UserOwnedAchievementViewModel>(result));
    }

    [HttpPost("add")]
    public IActionResult Add(UserOwnedAchievementAddDTO model) 
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserOwnedAchievement>(model); 
        var result = _userOwnedAchievementRepository.Add(dataModel); 

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UserOwnedAchievementUpdateDTO model) 
    {                                                      
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserOwnedAchievement>(model);
        var result = _userOwnedAchievementRepository.Update(dataModel); 
        
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userOwnedAchievementRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
