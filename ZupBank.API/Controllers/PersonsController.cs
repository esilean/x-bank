using ZupBank.Application.Dtos;
using ZupBank.Application.UseCases.Gateways;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZupBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {

        private readonly ILogger<PersonsController> _logger;
        private readonly IAddPersonUseCase _addPersonUseCase;
        private readonly IGetPersonUseCase _getPersonUseCase;

        public PersonsController(ILogger<PersonsController> logger,
                                 IAddPersonUseCase addPersonUseCase,
                                 IGetPersonUseCase getPersonUseCase)
        {
            _logger = logger;
            _addPersonUseCase = addPersonUseCase;
            _getPersonUseCase = getPersonUseCase;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            _logger.LogInformation("Getting all persons");
            return await _getPersonUseCase.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<PersonDto> Get(int id)
        {
            _logger.LogInformation($"Getting by id: {id}");
            return await _getPersonUseCase.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            _logger.LogInformation($"Adding a person: {personDto.Name}");
            await _addPersonUseCase.Add(personDto);

            return Created("", personDto);
        }
    }
}
