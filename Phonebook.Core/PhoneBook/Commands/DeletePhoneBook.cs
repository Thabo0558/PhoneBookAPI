using MediatR;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBook.Commands
{
    public class DeletePhoneBook : IRequest
    {
        public int Id { get; set; }

        public class DeletePhoneBookHandler : IRequestHandler<DeletePhoneBook>
        {
            private IPhoneBookContext _phoneBookContext;

            public DeletePhoneBookHandler(IPhoneBookContext phoneBookContext)
            {
                _phoneBookContext = phoneBookContext;
            }

            public async Task<Unit> Handle(DeletePhoneBook request, CancellationToken cancellationToken)
            {
                var phoneBookEntity = await _phoneBookContext.Phonebooks.FindAsync(request.Id);

                if (phoneBookEntity == null)
                {
                    throw new Exception($"Entity \"{nameof(Phonebook)}\" {request.Id} was not found.");
                }

                _phoneBookContext.Phonebooks.Remove(phoneBookEntity);

                await _phoneBookContext.SavePhonebookChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
