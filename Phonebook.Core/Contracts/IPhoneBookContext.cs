using Microsoft.EntityFrameworkCore;
using Phonebook.Model.Entities;
using ModelEntities = Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Core.Contracts
{
    public interface IPhoneBookContext
    {
        DbSet<ModelEntities.PhoneBookEntry> PhoneBookEntries { get; set; }
        DbSet<ModelEntities.PhoneBook> Phonebooks { get; set; }

        Task<int> SavePhonebookChangesAsync(CancellationToken cancellationToken);

    }
}
