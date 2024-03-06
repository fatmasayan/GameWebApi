using GameWebApi2.Authentication;
using GameWebApi2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class DjangoMigrationsController : ControllerBase
{
    private readonly IDjangoMigrationsRepository _djangoMigrationsRepository;
    private readonly IMapper _mapper;

    public DjangoMigrationsController(IDjangoMigrationsRepository DjangoMigrationsRepository, IMapper mapper)
    {
        _djangoMigrationsRepository = DjangoMigrationsRepository;
        _mapper = mapper;
    }

    [HttpGet]
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

    [HttpPost]
    public IActionResult Add(DjangoMigrationsAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoMigrations>(model);
        var result = _djangoMigrationsRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(DjangoMigrationsUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoMigrations>(model);
        var result = _djangoMigrationsRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _djangoMigrationsRepository.Delete(x => x.id == id);

        return Ok(result);
    }
}
