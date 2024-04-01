namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserCharController : ControllerBase
{
    private readonly IUserCharRepository _userCharRepository;
    private readonly IMapper _mapper;

    public UserCharController(IUserCharRepository userCharRepository, IMapper mapper)
    {
        _userCharRepository = userCharRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userCharRepository.GetAll(x => x.body, x => x.foot, x => x.glove, x => x.head, x => x.loginUser, x => x.leg, x => x.loginUser);

        return Ok(_mapper.Map<List<UserCharViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userCharRepository.Get(x => x.id == id, x => x.body, x => x.foot, x => x.glove, x => x.head, x => x.loginUser, x => x.leg, x => x.loginUser));
    }

    [HttpPost("add")]
    public IActionResult Add(UserCharAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserChar>(model);
        var result = _userCharRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UserCharUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserChar>(model);
        var result = _userCharRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userCharRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
