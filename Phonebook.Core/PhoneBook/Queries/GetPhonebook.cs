using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phonebook.Core.Contracts;
using Phonebook.Core.PhoneBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.PhoneBook.Queries
{
    public class GetPhoneBook : IRequest<PhoneBookViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class GetPhoneBookHandler : IRequestHandler<GetPhoneBook, PhoneBookViewModel>
        {

            private readonly IPhoneBookContext _phoneBookContext;
            private readonly IMapper _mapper;

            public GetPhoneBookHandler(IPhoneBookContext phoneBookContex, IMapper mapper)
            {
                _phoneBookContext = phoneBookContex;
                _mapper = mapper;
            }
            public async Task<PhoneBookViewModel> Handle(GetPhoneBook request, CancellationToken cancellationToken)
            {
                var viewModel = await _phoneBookContext.Phonebooks
                       .Where(v => v.Id == request.Id)
                     .ProjectTo<PhoneBookViewModel>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(cancellationToken);

                if (viewModel == null)
                {
                    throw new Exception($"Entity \"{nameof(Phonebook)}\" {request.Id} was not found.");
                }

                return viewModel;
            }
        }
    }
}
