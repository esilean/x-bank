using ZupBank.Application.Helpers;
using ZupBank.Data.Data.Models;
using ZupBank.Domain.Entities;
using ZupBank.Domain.Enums;
using System.Collections.Generic;

namespace ZupBank.Data.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public static class PersonModelMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static PersonModel ToModel(Person person)
        {
            if (person == null)
                return null;

            return new PersonModel
            {
                Id = person.Id,
                Name = person.Name,
                Gender = EnumHelper.GetDescription(person.Gender),
                BirthdayMonth = EnumHelper.GetDescription(person.BirthdayMonth)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Person ToDomain(PersonModel model)
        {
            if (model == null)
                return null;

            return Person.CreatePerson(model.Id,
                                       model.Name,
                                       EnumHelper.GetValueFromEnumMember<Gender>(model.Gender),
                                       EnumHelper.GetValueFromEnumMember<BirthdayMonth>(model.BirthdayMonth));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personsModel"></param>
        /// <returns></returns>
        public static IEnumerable<Person> ToDomainList(IEnumerable<PersonModel> personsModel)
        {
            var persons = new List<Person>();

            foreach (var p in personsModel)
                persons.Add(ToDomain(p));

            return persons;
        }
    }
}
