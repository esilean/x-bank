using System.Threading.Tasks;
using ZupBank.Application.Dtos;
using ZupBank.Application.Mappers;
using ZupBank.Application.UseCases.Gateways;
using ZupBank.Domain.Core.Notifications;
using ZupBank.Domain.Repositories;

namespace ZupBank.Application.UseCases
{
    public class AddPersonUseCase : IAddPersonUseCase
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPersonRepository _personRepository;

        public AddPersonUseCase(NotificationContext notificationContext,
                                IPersonRepository personRepository)
        {
            _notificationContext = notificationContext;
            _personRepository = personRepository;
        }

        public async Task Add(PersonDto personDto)
        {
            var person = PersonMapper.ToDomain(personDto);
            if (person.Invalid)
            {
                _notificationContext.AddNotifications(person.ValidationResult);
                return;
            }

            await _personRepository.Add(person);
        }
    }
}
