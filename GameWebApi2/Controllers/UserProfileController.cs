namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IMapper _mapper;

    public UserProfileController(IUserProfileRepository userProfileRepository, IMapper mapper)
    {
        _userProfileRepository = userProfileRepository;
        _mapper = mapper;
    }


    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userProfileRepository.GetAll(includes: x => x.user);

        return Ok(_mapper.Map<List<UserProfileViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userProfileRepository.Get(x => x.id == id , includes: x => x.user));
    }

    [HttpPost("add")]
    public IActionResult Add(UserProfileAddDTO model) 
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserProfile>(model);

        var result = _userProfileRepository.Add(dataModel); 

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UserProfileUpdateDTO model) 
    {                                                       
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserProfile>(model); 
        var result = _userProfileRepository.Update(dataModel); 

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userProfileRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
