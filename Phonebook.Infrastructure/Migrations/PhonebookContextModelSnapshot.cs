using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Phonebook.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Infrastructure.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    partial class PhonebookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
               .HasAnnotation("ProductVersion", "2.2.2")
               .HasAnnotation("Relational:MaxIdentifierLength", 128)
               .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phonebook.Model.Entities.PhonebookEntry", c =>
            {
                c.Property<int>("Id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                c.Property<int>("PhoneBookId")
                    .HasColumnType("int");

                c.Property<string>("Name")
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                c.Property<string>("PhoneNumber")
                       .HasColumnType("nvarchar(20)")
                       .HasMaxLength(20)
                       .IsRequired();

                c.HasKey("Id");
                c.HasIndex("PhoneBookId");
                c.ToTable("PhonebookEntries");
            });

            modelBuilder.Entity("Phonebook.Model.Entities.PhoneBook", c =>
            {
                c.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                c.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                c.HasKey("Id");
                c.ToTable("Phonebook.Core.Contracts.IPhonebookContext.Phonebooks");
            });

            modelBuilder.Entity("Phonebook.Model.Entities.PhonebookEntry", b =>
            {
                b.HasOne("Phonebook.Model.Entities.PhoneBook", null)
                    .WithMany("PhonebookEntries")
                    .HasForeignKey("PhoneBookId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
