
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;

    public PurchaseController(IPurchaseRepository PurchaseRepository, IMapper mapper)
    {
        _purchaseRepository = PurchaseRepository;
        _mapper = mapper;
    }

    [HttpGet]
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

    [HttpPost]
    public IActionResult Add(PurchaseAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Purchase>(model);
        var result = _purchaseRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(PurchaseUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Purchase>(model);
        var result = _purchaseRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _purchaseRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
