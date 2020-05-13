using MediatR;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBookEntry.Commands
{
    public class DeletePhoneBookEntry : IRequest
    {
        public int Id { get; set; }

        public class DeletePhoneBookEntryHandler : IRequestHandler<DeletePhoneBookEntry>
        {
            private IPhoneBookContext _phoneBookContext;

            public DeletePhoneBookEntryHandler(IPhoneBookContext phoneBookContext)
            {
                _phoneBookContext = phoneBookContext;
            }

            public async Task<Unit> Handle(DeletePhoneBookEntry request, CancellationToken cancellationToken)
            {
                var entryEntity = await _phoneBookContext.PhoneBookEntries.FindAsync(request.Id);

                if (entryEntity == null)
                {
                    throw new Exception($"Entity \"{nameof(PhoneBookEntry)}\" {request.Id} was not found.");
                }

                _phoneBookContext.PhoneBookEntries.Remove(entryEntity);

                await _phoneBookContext.SavePhonebookChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
