using GameWebApi2.Authentication;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class GarageController : ControllerBase
{
    private readonly IGarageRepository _garageRepository;
    private readonly IMapper _mapper;

    public GarageController(IGarageRepository garageRepository, IMapper mapper)
    {
        _garageRepository = garageRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _garageRepository.GetAll();

        return Ok(_mapper.Map<List<GarageViewModel>>(resultList));
    }

    
    [HttpGet("{keyword}")] 
    public IActionResult GetAll(string keyword)
    {
        return Ok(_garageRepository.GetAll(x => x.garageName.Contains(keyword)));
    }

    
    [HttpGet("getSingle/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_garageRepository.Get(x => x.id == id)); 
    }

    [HttpPost]
    public IActionResult Add(GarageAddDTO model) 
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Garage>(model); 
        var result = _garageRepository.Add(dataModel); 

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(GarageUpdateDTO model) 
    {                                                      
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<Garage>(model); 
        var result = _garageRepository.Update(dataModel); 
        
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _garageRepository.Delete(x => x.id == id);  

        return Ok(result);
    }

}
