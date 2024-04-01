namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DjangoMigrationsController : ControllerBase
{
    private readonly IDjangoMigrationsRepository _djangoMigrationsRepository;
    private readonly IMapper _mapper;

    public DjangoMigrationsController(IDjangoMigrationsRepository DjangoMigrationsRepository, IMapper mapper)
    {
        _djangoMigrationsRepository = DjangoMigrationsRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _djangoMigrationsRepository.GetAll();

        return Ok(_mapper.Map<List<DjangoMigrationsViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_djangoMigrationsRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(DjangoMigrationsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoMigrations>(model);
        var result = _djangoMigrationsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(DjangoMigrationsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoMigrations>(model);
        var result = _djangoMigrationsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _djangoMigrationsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
