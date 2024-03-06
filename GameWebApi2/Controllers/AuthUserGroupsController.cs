using GameWebApi2.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class AuthUserGroupsController : ControllerBase
{
    private readonly IAuthUserGroupsRepository _authUserGroupsRepository;
    private readonly IMapper _mapper;

    public AuthUserGroupsController(IAuthUserGroupsRepository AuthUserGroupsRepository, IMapper mapper)
    {
        _authUserGroupsRepository = AuthUserGroupsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _authUserGroupsRepository.GetAll(x => x.user, x => x.group);

        return Ok(_mapper.Map<List<AuthUserGroupsViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_authUserGroupsRepository.Get(x => x.id == id, x => x.user, x => x.group));
    }

    [HttpPost]
    public IActionResult Add(AuthUserGroupsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthUserGroups>(model);
        var result = _authUserGroupsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(AuthUserGroupsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthUserGroups>(model);
        var result = _authUserGroupsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _authUserGroupsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
