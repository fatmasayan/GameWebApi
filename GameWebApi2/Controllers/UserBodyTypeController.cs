namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserBodyTypeController : ControllerBase
{
    private readonly IUserBodyTypeRepository _userBodyTypeRepository;
    private readonly IMapper _mapper;

    public UserBodyTypeController(IUserBodyTypeRepository userBodyTypeRepository, IMapper mapper)
    {
        _userBodyTypeRepository = userBodyTypeRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userBodyTypeRepository.GetAll(includes:x => x.loginUser);

        return Ok(_mapper.Map<List<UserBodyTypeViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id) 
    {
        return Ok(_userBodyTypeRepository.Get(x => x.id == id, includes: x => x.loginUser));
    }

    [HttpPost("add")]
    public IActionResult Add(UserBodyTypeAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserBodyType>(model);
        var result = _userBodyTypeRepository.Add(dataModel);

        return Ok(result);
    }


    [HttpPut("update")]
    public IActionResult Update(UserBodyTypeUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserBodyType>(model);
        var result = _userBodyTypeRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userBodyTypeRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
