using GameWebApi2.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class AuthGroupPermissionsController : ControllerBase
{
    private readonly IAuthGroupPermissionsRepository _authGroupPermissionsRepository;
    private readonly IMapper _mapper;

    public AuthGroupPermissionsController(IAuthGroupPermissionsRepository AuthGroupPermissionsRepository, IMapper mapper)
    {
        _authGroupPermissionsRepository = AuthGroupPermissionsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _authGroupPermissionsRepository.GetAll(x => x.group, x => x.permission);

        return Ok(_mapper.Map<List<AuthGroupPermissionsViewModel>>(resultList));
    }


    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_authGroupPermissionsRepository.Get(x => x.id == id, x => x.group, x => x.permission));
    }

    [HttpPost]
    public IActionResult Add(AuthGroupPermissionsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthGroupPermissions>(model);
        var result = _authGroupPermissionsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(AuthGroupPermissionsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthGroupPermissions>(model);
        var result = _authGroupPermissionsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _authGroupPermissionsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
