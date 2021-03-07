using System.Collections.Generic;
using ZupBank.Application.Dtos;
using ZupBank.Domain.Entities;

namespace ZupBank.Application.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public static class PersonMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        public static Person ToDomain(PersonDto personDto)
        {
            if (personDto == null)
                return null;

            return Person.CreatePerson(personDto.Id,
                                       personDto.Name,
                                       personDto.Gender,
                                       personDto.BirthdayMonth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personsDto"></param>
        /// <returns></returns>
        public static IEnumerable<Person> ToDomainList(IEnumerable<PersonDto> personsDto)
        {
            var persons = new List<Person>();

            foreach (var p in personsDto)
                persons.Add(ToDomain(p));

            return persons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static PersonDto ToDto(Person person)
        {
            if (person == null)
                return null;

            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Gender = person.Gender,
                BirthdayMonth = person.BirthdayMonth,
                Posts = PostMapper.ToDtoList(person.Posts),
                TranCodeAccess = new TranCodeAccessDto
                {
                    User = person.TranCodeAccess.User,
                    Pass = person.TranCodeAccess.Pass,
                    Domain = person.TranCodeAccess.Domain
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public static IEnumerable<PersonDto> ToDtoList(IEnumerable<Person> persons)
        {
            var personsDto = new List<PersonDto>();

            foreach (var p in persons)
                personsDto.Add(ToDto(p));

            return personsDto;
        }

    }
}
