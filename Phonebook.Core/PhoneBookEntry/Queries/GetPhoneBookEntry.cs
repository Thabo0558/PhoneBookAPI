using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phonebook.Core.Contracts;
using Phonebook.Core.PhoneBookEntry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBookEntry.Queries
{
    public class GetPhoneBookEntry : IRequest<PhoneBookEntryViewModel>
    {
        public long Id { get; set; }

        public class GetPhoneBookEntryQueryHandler : IRequestHandler<GetPhoneBookEntry, PhoneBookEntryViewModel>
        {

            private readonly IPhoneBookContext _phoneBookContext;
            private readonly IMapper _mapper;

            public GetPhoneBookEntryQueryHandler(IPhoneBookContext phoneBookContext, IMapper mapper)
            {
                _phoneBookContext = phoneBookContext;
                _mapper = mapper;
            }
            public async Task<PhoneBookEntryViewModel> Handle(GetPhoneBookEntry request, CancellationToken cancellationToken)
            {
                var viewModel = await _phoneBookContext.PhoneBookEntries
                       .Where(t => t.Id == request.Id)
                     .ProjectTo<PhoneBookEntryViewModel>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);

                if (viewModel == null)
                {
                    throw new Exception($"Entity \"{nameof(PhoneBookEntry)}\" {request.Id} was not found.");
                }

                return viewModel;
            }
        }
    }
}
