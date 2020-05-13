using AutoMapper;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.PhoneBookEntry.ViewModels
{
    public class PhoneBookEntryViewModel : IMapFrom<Phonebook.Model.Entities.PhoneBookEntry>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhonebookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(Phonebook.Model.Entities.PhoneBookEntry), GetType());
        }
    }
}
