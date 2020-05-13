using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phonebook.Core.Contracts;
using Phonebook.Core.Dto;
using Phonebook.Core.PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBook.Queries
{
    public class GetPhoneBookList : IRequest<PhoneBookListViewModel>
    {
        public class GetPhonebookListHandler : IRequestHandler<GetPhoneBookList, PhoneBookListViewModel>
        {

            private readonly IPhoneBookContext _phoneBookContext;
            private readonly IMapper _mapper;

            public GetPhonebookListHandler(IPhoneBookContext phoneBookContext, IMapper mapper)
            {
                _phoneBookContext = phoneBookContext;
                _mapper = mapper;

            }

            public async Task<PhoneBookListViewModel> Handle(GetPhoneBookList request, CancellationToken cancellationToken)
            {
                var phoneBooks = await _phoneBookContext.Phonebooks
                    .ProjectTo<PhoneBookDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var viewModel = new PhoneBookListViewModel
                {
                    PhoneBooks = phoneBooks
                };

                return viewModel;
            }
        }
    }
}
