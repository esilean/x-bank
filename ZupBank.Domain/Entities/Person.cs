using FluentValidation;
using System.Collections.Generic;
using ZupBank.Domain.Enums;

namespace ZupBank.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Person : Entity<int>
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public BirthdayMonth BirthdayMonth { get; private set; }
        public TranCodeAccess TranCodeAccess { get; private set; }
        public IEnumerable<Post> Posts { get; private set; }

        private Person(int id, string name, Gender gender, BirthdayMonth birthdayMonth)
        {
            Id = id;
            Name = name;
            Gender = gender;
            BirthdayMonth = birthdayMonth;

            Validate(this, new PersonValidator());
        }

        public static Person CreatePerson(int id, string name, Gender gender, BirthdayMonth birthdayMonth)
        {
            return new Person(id, name, gender, birthdayMonth);
        }

        public void AddPosts(IEnumerable<Post> posts)
        {
            Posts = posts;
        }

        public void AddTranCodeAccess(TranCodeAccess tranCodeAccess)
        {
            TranCodeAccess = tranCodeAccess;
        }

        internal class PersonValidator : AbstractValidator<Person>
        {
            public PersonValidator()
            {
                RuleFor(a => a.Id)
                    .NotEmpty()
                    .WithMessage("Invalid id");

                RuleFor(a => a.Name)
                    .NotEmpty()
                    .WithMessage("Invalid name");

                RuleFor(a => a.Gender)
                    .IsInEnum()
                    .WithMessage("Gender cannot be empty");

                RuleFor(a => a.BirthdayMonth)
                    .IsInEnum()
                    .WithMessage("BirthdayMonth cannot be empty");
            }
        }
    }
}
