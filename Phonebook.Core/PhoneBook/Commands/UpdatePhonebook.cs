using MediatR;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBook.Commands
{
    public class UpdatePhoneBook : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdatePhoneBookHandler : IRequestHandler<UpdatePhoneBook>
        {
            private readonly IPhoneBookContext _phoneBookContext;

            public UpdatePhoneBookHandler(IPhoneBookContext phoneBookContext)
            {
                _phoneBookContext = phoneBookContext;
            }

            public async Task<Unit> Handle(UpdatePhoneBook request, CancellationToken cancellationToken)
            {
                var phoneBookEntity = await _phoneBookContext.Phonebooks.FindAsync(request.Id);

                if (phoneBookEntity == null)
                {
                    throw new Exception($"Entity \"{nameof(Phonebook)}\" {request.Id} was not found.");
                }

                phoneBookEntity.Name = request.Name;

                await _phoneBookContext.SavePhonebookChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
