using FluentValidation;
using Phonebook.Core.PhoneBookEntry.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.PhoneBookEntry.Validators
{
    public class CreatePhonebookEntryValidator : AbstractValidator<CreatePhoneBookEntry>
    {
        public CreatePhonebookEntryValidator()
        {
            RuleFor(v => v.Name)
             .MinimumLength(1)
             .MaximumLength(100)
             .NotEmpty();

            RuleFor(v => v.PhoneNumber)
               .MinimumLength(10)
               .MaximumLength(15)
               .NotEmpty();

            RuleFor(v => v.PhonebookId)
                .NotEmpty();
        }
    }
}
