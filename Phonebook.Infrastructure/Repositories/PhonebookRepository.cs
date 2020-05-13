using Microsoft.EntityFrameworkCore;
using Phonebook.Core.Contracts;
using Phonebook.Infrastructure.Context;
using Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Infrastructure.Repositories
{
    public class PhoneBookRepository : PhoneBookContext, IPhoneBookContext
    {
        public DbSet<PhoneBook> Phonebooks { get; set; }

        public PhoneBookRepository()
        {

        }

        public async Task<int> SavePhonebookChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
