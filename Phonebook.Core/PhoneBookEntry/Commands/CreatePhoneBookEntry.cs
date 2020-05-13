using MediatR;
using Phonebook.Core.Contracts;
using Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBookEntry.Commands
{
    public class CreatePhoneBookEntry : IRequest<long>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhonebookId { get; set; }

        public class CreatePhonebookEntryHandler : IRequestHandler<CreatePhoneBookEntry, long>
        {
            private readonly IPhoneBookContext _phoneBookContext;

            public CreatePhonebookEntryHandler(IPhoneBookContext phoneBookContext)
            {
                _phoneBookContext = phoneBookContext;
            }

            public async Task<long> Handle(CreatePhoneBookEntry request, CancellationToken cancellationToken)
            {
                var entryEntity = new Model.Entities.PhoneBookEntry
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    PhoneBookId = request.PhonebookId
                };

                _phoneBookContext.PhoneBookEntries.Add(entryEntity);

                await _phoneBookContext.SavePhonebookChangesAsync(cancellationToken);

                return entryEntity.Id;
            }
        }
    }
}
