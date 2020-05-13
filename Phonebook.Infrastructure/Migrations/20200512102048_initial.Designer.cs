using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Phonebook.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Infrastructure.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    [Migration("20200512102048_initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phonebook.Model.Entities.PhonebookEntry", c =>
            {
                c.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                c.Property<int>("PhoneBookId")
                   .HasColumnType("int");

                c.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                c.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(20)")
                    .HasMaxLength(20);

                c.HasKey("Id");

                c.HasIndex("PhoneBookId");

                c.ToTable("PhonebookEntry");
            });

            modelBuilder.Entity("Phonebook.Model.Entities.PhoneBook", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("Id");

                b.ToTable("Phonebook.Core.Contracts.IPhonebookContext.Phonebooks");
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
