namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DjangoAdminLogController : ControllerBase
{
    private readonly IDjangoAdminLogRepository _djangoAdminLogRepository;
    private readonly IMapper _mapper;

    public DjangoAdminLogController(IDjangoAdminLogRepository DjangoAdminLogRepository, IMapper mapper)
    {
        _djangoAdminLogRepository = DjangoAdminLogRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _djangoAdminLogRepository.GetAll(x => x.content_type, x => x.user);

        return Ok(_mapper.Map<List< DjangoAdminLogViewModel>>(resultList));
    }
    
    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_djangoAdminLogRepository.Get(x => x.id == id, x => x.content_type, x => x.user));
    }

    [HttpPost("add")]
    public IActionResult Add(DjangoAdminLogAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map< DjangoAdminLog>(model);
        var result = _djangoAdminLogRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update( DjangoAdminLogUpdateDTO model)
    {
        if (model == null)
            return BadRequest();
        
        var dataModel = _mapper.Map< DjangoAdminLog>(model);
        var result = _djangoAdminLogRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _djangoAdminLogRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
