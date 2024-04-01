namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserOwendMapController : ControllerBase
{
    private readonly IUserOwendMapRepository _userOwendMapRepository;
    private readonly IMapper _mapper;

    public UserOwendMapController(IUserOwendMapRepository userOwendMapRepository, IMapper mapper)
    {
        _userOwendMapRepository = userOwendMapRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userOwendMapRepository.GetAll(x => x.loginUser, x => x.map);

        return Ok(_mapper.Map<List< UserOwendMapViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userOwendMapRepository.Get(x => x.id == id, x => x.loginUser, x => x.map));
    }

    [HttpPost("add")]
    public IActionResult Add( UserOwendMapAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map< UserOwendMap>(model);
        var result = _userOwendMapRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update( UserOwendMapUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map< UserOwendMap>(model);
        var result = _userOwendMapRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userOwendMapRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
