using GameWebApi2.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class CharItemsController : ControllerBase
{
    private readonly ICharItemsRepository _charItemsRepository;
    private readonly IMapper _mapper;

    public CharItemsController(ICharItemsRepository CharItemsRepository, IMapper mapper)
    {
        _charItemsRepository = CharItemsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _charItemsRepository.GetAll();

        return Ok(_mapper.Map<List<CharItemsViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_charItemsRepository.Get(x => x.id == id));
    }

    [HttpPost]
    public IActionResult Add(CharItemsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<CharItems>(model);
        var result = _charItemsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(CharItemsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<CharItems>(model);
        var result = _charItemsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _charItemsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
