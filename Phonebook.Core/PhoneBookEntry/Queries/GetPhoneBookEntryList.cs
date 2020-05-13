using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phonebook.Core.Contracts;
using Phonebook.Core.Dto;
using Phonebook.Core.PhoneBookEntry.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBookEntry.Queries
{
    public class GetPhoneBookEntryList : IRequest<PhoneBookEntryListViewModel>
    {
        public class GetPhoneBookListHandler : IRequestHandler<GetPhoneBookEntryList, PhoneBookEntryListViewModel>
        {

            private readonly IPhoneBookContext _phoneBookContext;
            private readonly IMapper _mapper;

            public GetPhoneBookListHandler(IPhoneBookContext phoneBookContext, IMapper mapper)
            {
                _phoneBookContext = phoneBookContext;
                _mapper = mapper;

            }

            public async Task<PhoneBookEntryListViewModel> Handle(GetPhoneBookEntryList request, CancellationToken cancellationToken)
            {
                var entries = await _phoneBookContext.PhoneBookEntries
                    .ProjectTo<PhoneBookEntryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var viewModel = new PhoneBookEntryListViewModel
                {
                    Entries = entries
                };

                return viewModel;
            }

            
        }
    }
}
