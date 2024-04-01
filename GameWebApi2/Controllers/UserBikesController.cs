namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserBikesController : ControllerBase
{
    private readonly IUserBikesRepository _userBikesRepository;
    private readonly IMapper _mapper;

    public UserBikesController(IUserBikesRepository userBikesRepository, IMapper mapper)
    {
        _userBikesRepository = userBikesRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userBikesRepository.GetAll(x => x.body, x => x.saddle, x => x.handlebar, x => x.indicator, x => x.loginUser, x => x.wheel);
        // modele ilişkili verileri dahil etmiş oldum , yani başka tablodan aldığı değerleri getirmiş ve o değere atadık 
        return Ok(_mapper.Map<List<UserBikesViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userBikesRepository.Get(x => x.id == id, x => x.body, x => x.saddle, x => x.handlebar, x => x.indicator, x => x.loginUser, x => x.wheel));
    }

    [HttpPost("add")]
    public IActionResult Add(UserBikesAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserBikes>(model);
        var result = _userBikesRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UserBikesUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserBikes>(model);
        var result = _userBikesRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userBikesRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
