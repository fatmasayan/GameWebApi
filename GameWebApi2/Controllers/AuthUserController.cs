namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthUserController : ControllerBase
{
    private readonly IAuthUserRepository _authUserRepository;
    private readonly IMapper _mapper;

    public AuthUserController(IAuthUserRepository authUserRepository, IMapper mapper)
    {
        _authUserRepository = authUserRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _authUserRepository.GetAll();

        return Ok(_mapper.Map<List<AuthUserViewModel>>(resultList));
    }
 
    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_authUserRepository.Get(x => x.id == id)); 
    }

    [HttpPost("add")]
    public IActionResult Add(AuthUserAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthUser>(model); 
        var result = _authUserRepository.Add(dataModel); 

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(AuthUserUpdateDTO model)  
    {                                                      
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<AuthUser>(model);
        var result = _authUserRepository.Update(dataModel);
        
        return Ok(result);
    }
    
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _authUserRepository.Delete(x => x.id == id); 

        return Ok(result);
    }
}
