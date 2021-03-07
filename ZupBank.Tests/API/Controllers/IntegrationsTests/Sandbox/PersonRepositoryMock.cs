using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ZupBank.Application.Dtos;
using ZupBank.Application.Mappers;
using ZupBank.Domain.Entities;
using ZupBank.Domain.Repositories;

namespace ZupBank.Tests.API.Controllers.IntegrationsTests.Sandbok
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonRepositoryMock : IPersonRepository
    {
        public Task Add(Person person)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var personsJson = File.ReadAllText(@$"API\Controllers\IntegrationsTests\Sandbox\Data\personsDto.json");

            var personsDto = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(personsJson);

            return await Task.FromResult(PersonMapper.ToDomainList(personsDto));
        }
    }
}
