namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class UserInventoryController : ControllerBase
{
    private readonly IUserInventoryRepository _userInventoryRepository;
    private readonly IMapper _mapper;

    public UserInventoryController(IUserInventoryRepository UserInventoryRepository, IMapper mapper)
    {
        _userInventoryRepository = UserInventoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _userInventoryRepository.GetAll(includes: x => x.loginUser);

        return Ok(_mapper.Map<List<UserInventoryViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_userInventoryRepository.Get(x => x.id == id, includes: x => x.loginUser));
    }

    [HttpPost]
    public IActionResult Add(UserInventoryAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserInventory>(model);
        var result = _userInventoryRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(UserInventoryUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<UserInventory>(model);
        var result = _userInventoryRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _userInventoryRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
