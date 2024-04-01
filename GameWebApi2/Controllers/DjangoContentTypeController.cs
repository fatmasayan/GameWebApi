namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DjangoContentTypeController : ControllerBase
{
    private readonly IDjangoContentTypeRepository _djangoContentTypeRepository;
    private readonly IMapper _mapper;

    public DjangoContentTypeController(IDjangoContentTypeRepository DjangoContentTypeRepository, IMapper mapper)
    {
        _djangoContentTypeRepository = DjangoContentTypeRepository;
        _mapper = mapper;
    }

    [HttpGet("getListe")]
    public IActionResult GetAll()
    {
        var resultList = _djangoContentTypeRepository.GetAll();

        return Ok(_mapper.Map<List<DjangoContentTypeViewModel>>(resultList));
    }

    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_djangoContentTypeRepository.Get(x => x.id == id));
    }

    [HttpPost("add")]
    public IActionResult Add(DjangoContentTypeAddDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoContentType>(model);
        var result = _djangoContentTypeRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(DjangoContentTypeUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoContentType>(model);
        var result = _djangoContentTypeRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var result = _djangoContentTypeRepository.Delete(x => x.id == id);

        return Ok(result);
    }

}
