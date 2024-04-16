namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BikePartsController : ControllerBase
{
    private readonly IBikePartsRepository _bikePartsRepository; //an object was created from the class of database operations.
    private readonly IMapper _mapper; //object for use in mapping operations.

    public BikePartsController(IBikePartsRepository BikePartsRepository, IMapper mapper)
    {
        _bikePartsRepository = BikePartsRepository;
        _mapper = mapper;
    }

    [HttpGet("getList")] // listing operation.
    public IActionResult GetAll()
    {
        var resultList = _bikePartsRepository.GetAll(); //The method written in the Repository class was used.

        return Ok(_mapper.Map<List<BikePartsViewModel>>(resultList));
        //A view model was created for the properties that we don't want to appear in the list like id, the returned list was converted to view model type.
    }

    [HttpGet("getSingle/{id}")] //Listing with filter, to get the item of the desired id value in the list.
    public IActionResult Get(int id)
    {
        return Ok(_bikePartsRepository.Get(x => x.id == id)); // returns the object with the typed id.
    }

    // Endpoint used to add to a list-table.
    [HttpPost("add")]
    public IActionResult Add(BikePartsAddDTO model) //DTO is defined for values that are not to be accessed-changed such as id in the add operation, only variable values to be received from the user are received.
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<BikeParts>(model); //Converting the object of type Dto to Achievement class object: mapping
        //I can't do insertion without conversion because DTO doesn't have access to all values in the table.
        var result = _bikePartsRepository.Add(dataModel); //Adding process was done.

        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(BikePartsUpdateDTO model) //Models in the form of updateDTO have been defined in the update operation. In update operations, the item is accessed with id and updated accordingly.
    {
        // updated by making changes
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<BikeParts>(model); // convert the dto object to Achievement class object 
        var result = _bikePartsRepository.Update(dataModel);  //update process done
        // We send the "_achievementRepository" object to the Repository class, it is an object generated from the AchievementRepository class and is processed by accessing the methods created in the Generic Repository.
        return Ok(result);
    }

    [HttpDelete("delete/{id}")] // get an id from the user
    public IActionResult Delete(int id)
    {
        var result = _bikePartsRepository.Delete(x => x.id == id); // deletion is done according to id

        return Ok(result);
    }
}
