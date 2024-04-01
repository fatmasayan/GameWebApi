namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class MapController : ControllerBase
{
    private readonly IMapRepository _mapRepository;
    private readonly IMapper _mapper;

    public MapController(IMapRepository MapRepository, IMapper mapper)
    {
        _mapRepository = MapRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _mapRepository.GetAll();

        return Ok(_mapper.Map<List<MapViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_mapRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(MapAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Map>(model);
        var result = _mapRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(MapUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Map>(model);
        var result = _mapRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _mapRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
