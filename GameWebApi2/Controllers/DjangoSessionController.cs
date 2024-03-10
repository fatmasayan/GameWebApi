﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
//[BasicAuthorization]
public class DjangoSessionController : ControllerBase
{
    private readonly IDjangoSessionRepository _djangoSessionRepository;
    private readonly IMapper _mapper;

    public DjangoSessionController(IDjangoSessionRepository DjangoSessionRepository, IMapper mapper)
    {
        _djangoSessionRepository = DjangoSessionRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var resultList = _djangoSessionRepository.GetAll();

        return Ok(_mapper.Map<List<DjangoSessionViewModel>>(resultList));
    }

    

    [HttpPost]
    public IActionResult Add(DjangoSessionUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoSession>(model);
        var result = _djangoSessionRepository.Add(dataModel);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(DjangoSessionUpdateDTO model)
    {
        if (model == null)
            return BadRequest();

        var dataModel = _mapper.Map<DjangoSession>(model);
        var result = _djangoSessionRepository.Update(dataModel);

        return Ok(result);
    }

    [HttpDelete("{session_key}")]
    public IActionResult Delete(string session_key)
    {
        var result = _djangoSessionRepository.Delete(x => x.session_key == session_key);

        return Ok(result);
    }
}
