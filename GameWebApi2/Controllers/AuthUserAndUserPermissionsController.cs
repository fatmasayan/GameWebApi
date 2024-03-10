

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class AuthUserAndUserPermissionsController : ControllerBase
{
    private readonly IAuthUserAndUserPermissionsRepository _authUserAndUserPermissionsRepository;
    private readonly IMapper _mapper;

    public AuthUserAndUserPermissionsController(IAuthUserAndUserPermissionsRepository AuthUserAndUserPermissionsRepository, IMapper mapper)
    {
        _authUserAndUserPermissionsRepository = AuthUserAndUserPermissionsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _authUserAndUserPermissionsRepository.GetAll(x => x.user, x => x.permission);

        return Ok(_mapper.Map<List<AuthUserAndUserPermissionsViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_authUserAndUserPermissionsRepository.Get(x => x.id == id, x => x.user, x => x.permission));
    }

    [HttpPost]
    public IActionResult Add(AuthUserAndUserPermissionsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthUserAndUserPermissions>(model);
        var result = _authUserAndUserPermissionsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(AuthUserAndUserPermissionsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthUserAndUserPermissions>(model);
        var result = _authUserAndUserPermissionsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _authUserAndUserPermissionsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}