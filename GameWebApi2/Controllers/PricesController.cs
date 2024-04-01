namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PricesController : ControllerBase
{
    private readonly IPricesRepository _pricesRepository;
    private readonly IMapper _mapper;

    public PricesController(IPricesRepository PricesRepository, IMapper mapper)
    {
        _pricesRepository = PricesRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _pricesRepository.GetAll();

        return Ok(_mapper.Map<List<PricesViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_pricesRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(PricesAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Prices>(model);
        var result = _pricesRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(PricesUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Prices>(model);
        var result = _pricesRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _pricesRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
