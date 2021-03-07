using System.Collections.Generic;
using System.Threading.Tasks;
using ZupBank.Application.Dtos;
using ZupBank.Application.Mappers;
using ZupBank.Application.Services;
using ZupBank.Application.UseCases.Gateways;
using ZupBank.Domain.Entities;
using ZupBank.Domain.Repositories;

namespace ZupBank.Application.UseCases
{
    public class GetPersonUseCase : IGetPersonUseCase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPostService _postService;

        public GetPersonUseCase(IPersonRepository personRepository,
                                IPostService postService)
        {
            _personRepository = personRepository;
            _postService = postService;
        }

        public async Task<PersonDto> Get(int id)
        {
            var person = await _personRepository.Get(id);

            var posts = await _postService.GetPosts();
            person.AddPosts(posts);

            return PersonMapper.ToDto(person);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var persons = await _personRepository.GetAll();

            var posts = await _postService.GetPosts();
            foreach (var person in persons)
            {
                person.AddPosts(posts);
                person.AddTranCodeAccess(new TranCodeAccess(person.Name, person.Id.ToString(), "Domain"));
            }

            return PersonMapper.ToDtoList(persons);
        }
    }
}
