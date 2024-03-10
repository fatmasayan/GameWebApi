

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class AuthtokenTokenController : ControllerBase
{
    private readonly IAuthtokenTokenRepository _authtokenTokenRepository;
    private readonly IMapper _mapper;

    public AuthtokenTokenController(IAuthtokenTokenRepository AuthtokenTokenRepository, IMapper mapper)
    {
        _authtokenTokenRepository = AuthtokenTokenRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _authtokenTokenRepository.GetAll( includes: x => x.user);

        return Ok(_mapper.Map<List<AuthtokenTokenViewModel>>(resultList));
    }

    //[HttpGet("getSingle/{id}")]
    //public IActionResult Get(int id)
    //{
    //    return Ok(_authtokenTokenRepository.Get(x => x.id == id));
    //}

    [HttpPost]
    public IActionResult Add(AuthtokenTokenAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthtokenToken>(model);
        var result = _authtokenTokenRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(AuthtokenTokenUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthtokenToken>(model);
        var result = _authtokenTokenRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{key}")]
    public IActionResult Delete(string key)
    {
        var result = _authtokenTokenRepository.Delete(x => x.key == key);

        return Ok(result);
    }
}
