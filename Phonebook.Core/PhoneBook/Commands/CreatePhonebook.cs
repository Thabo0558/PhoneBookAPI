using MediatR;
using Phonebook.Core.Contracts;
using Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBook.Commands
{
    public class CreatePhoneBook : IRequest<long>
    {
        public string Name { get; set; }

        public class CreatePhoneBookHandler : IRequestHandler<CreatePhoneBook, long>
        {
            private readonly IPhoneBookContext _phoneBookContext;

            public CreatePhoneBookHandler(IPhoneBookContext phoneBookContext)
            {
                _phoneBookContext = phoneBookContext;

            }
            public async Task<long> Handle(CreatePhoneBook request, CancellationToken cancellationToken)
            {
                var phoneBookEntity = new Phonebook.Model.Entities.PhoneBook
                {
                    Name = request.Name
                };

                _phoneBookContext.Phonebooks.Add(phoneBookEntity);

                await _phoneBookContext.SavePhonebookChangesAsync(cancellationToken);

                return phoneBookEntity.Id;

            }
            
        }

    }
}
