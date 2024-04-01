namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthPermissionController : ControllerBase
{
    private readonly IAuthPermissionRepository _authPermissionRepository;
    private readonly IMapper _mapper;

    public AuthPermissionController(IAuthPermissionRepository AuthPermissionRepository, IMapper mapper)
    {
        _authPermissionRepository = AuthPermissionRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _authPermissionRepository.GetAll();

        return Ok(_mapper.Map<List<AuthPermissionViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_authPermissionRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(AuthPermissionAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthPermission>(model);
        var result = _authPermissionRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(AuthPermissionUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthPermission>(model);
        var result = _authPermissionRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _authPermissionRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
