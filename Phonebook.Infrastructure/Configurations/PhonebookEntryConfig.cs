using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Infrastructure.Configurations
{
    public class PhonebookEntryConfig : IEntityTypeConfiguration<PhoneBookEntry>
    {
        public void Configure(EntityTypeBuilder<PhoneBookEntry> entityBuilder)
        {
            entityBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            entityBuilder.Property(p => p.PhoneNumber)
                .IsRequired();                
        }
    }
}
