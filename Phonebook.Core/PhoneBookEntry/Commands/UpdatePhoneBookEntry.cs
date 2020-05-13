using MediatR;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBookEntry.Commands
{
    public class UpdatePhoneBookEntry : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhonebookId { get; set; }

        public class UpdatePhoneBookEntryHandler : IRequestHandler<UpdatePhoneBookEntry>
        {
            private readonly IPhoneBookContext _phoneBookContext;

            public UpdatePhoneBookEntryHandler(IPhoneBookContext phoneBookContext)
            {
                _phoneBookContext = phoneBookContext;
            }

            public async Task<Unit> Handle(UpdatePhoneBookEntry request, CancellationToken cancellationToken)
            {
                var entryEntity = await _phoneBookContext.PhoneBookEntries.FindAsync(request.Id);

                if (entryEntity == null)
                {
                    throw new Exception($"Entity \"{nameof(PhoneBookEntry)}\" {request.Id} was not found.");
                }

                entryEntity.Name = request.Name;
                entryEntity.PhoneBookId = request.PhonebookId;
                entryEntity.PhoneNumber = request.PhoneNumber;


                await _phoneBookContext.SavePhonebookChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
