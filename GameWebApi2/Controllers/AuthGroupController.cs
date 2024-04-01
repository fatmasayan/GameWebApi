namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthGroupController : ControllerBase
{
    private readonly IAuthGroupRepository _authGroupRepository;
    private readonly IMapper _mapper;

    public AuthGroupController(IAuthGroupRepository AuthGroupRepository, IMapper mapper)
    {
        _authGroupRepository = AuthGroupRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _authGroupRepository.GetAll();

        return Ok(_mapper.Map<List<AuthGroupViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_authGroupRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(AuthGroupAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthGroup>(model);
        var result = _authGroupRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(AuthGroupUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthGroup>(model);
        var result = _authGroupRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _authGroupRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
