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
    public class PhoneBookEntryRepository : PhoneBookContext, IPhoneBookContext
    {
        public DbSet<PhoneBookEntry> PhoneBookEntries { get; set; }

        public PhoneBookEntryRepository()
        {

        }

        public async Task<int> SavePhonebookChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
