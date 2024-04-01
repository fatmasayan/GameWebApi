namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserOwendGarageController : ControllerBase
{
    private readonly IUserOwendGarageRepository _userOwendGarageRepository;
    private readonly IMapper _mapper;

    public UserOwendGarageController(IUserOwendGarageRepository UserOwendGarageRepository, IMapper mapper)
    {
        _userOwendGarageRepository = UserOwendGarageRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _userOwendGarageRepository.GetAll(x => x.garage, x => x.loginUser);

        return Ok(_mapper.Map<List<UserOwendGarageViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userOwendGarageRepository.Get(x => x.id == id, x => x.garage, x => x.loginUser));
    }

    [HttpPost("add")]
    public IActionResult Add(UserOwendGarageAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserOwendGarage>(model);
        var result = _userOwendGarageRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(UserOwendGarageUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserOwendGarage>(model);
        var result = _userOwendGarageRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userOwendGarageRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
