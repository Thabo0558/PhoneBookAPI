using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Phonebook.API;
using Phonebook.Core.Contracts;
using Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.Infrastructure.Context
{
    public class PhoneBookContext : DbContext, IPhoneBookContext
    {
        private readonly IOptions<AppSettings> _config;
        public DbSet<PhoneBookEntry> PhoneBookEntries { get; set; }
        public DbSet<PhoneBook> Phonebooks { get; set; }

        public PhoneBookContext()
        {
            
        }

        public PhoneBookContext(DbContextOptions options, IOptions<AppSettings> config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbOptions)
            => dbOptions.UseSqlServer(_config.Value.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }  

        public Task<int> SavePhonebookChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
