using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Infrastructure.Configurations
{
    public class PhonebookConfig : IEntityTypeConfiguration<PhoneBook>
    {
        public void Configure(EntityTypeBuilder<PhoneBook> entityBuilder)
        {
            entityBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
