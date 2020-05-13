using FluentValidation;
using Phonebook.Core.PhoneBook.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.PhoneBook.Validators
{
    public class CreatePhonebookValidator : AbstractValidator<CreatePhoneBook>
    {
        public CreatePhonebookValidator()
        {
            RuleFor(v => v.Name)
               .MaximumLength(100)
               .NotEmpty();
        }
    }
}
