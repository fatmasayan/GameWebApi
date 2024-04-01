namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;

    public PurchaseController(IPurchaseRepository PurchaseRepository, IMapper mapper)
    {
        _purchaseRepository = PurchaseRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")]
    public IActionResult GetAll()
    {
        var resultList = _purchaseRepository.GetAll(includes: x => x.loginUser);

        return Ok(_mapper.Map<List<PurchaseViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_purchaseRepository.Get(x => x.id == id, includes: x => x.loginUser));
    }

    [HttpPost("add")]
    public IActionResult Add(PurchaseAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Purchase>(model);
        var result = _purchaseRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(PurchaseUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Purchase>(model);
        var result = _purchaseRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _purchaseRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
