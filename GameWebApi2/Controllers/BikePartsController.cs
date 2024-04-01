namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BikePartsController : ControllerBase
{
    private readonly IBikePartsRepository _bikePartsRepository;
    private readonly IMapper _mapper;

    public BikePartsController(IBikePartsRepository BikePartsRepository, IMapper mapper)
    {
        _bikePartsRepository = BikePartsRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _bikePartsRepository.GetAll();

        return Ok(_mapper.Map<List<BikePartsViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_bikePartsRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(BikePartsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<BikeParts>(model);
        var result = _bikePartsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(BikePartsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<BikeParts>(model);
        var result = _bikePartsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _bikePartsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
