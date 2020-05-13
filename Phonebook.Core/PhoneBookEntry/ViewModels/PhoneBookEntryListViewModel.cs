using AutoMapper;
using Phonebook.Core.Contracts;
using Phonebook.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.PhoneBookEntry.ViewModels
{
    public class PhoneBookEntryListViewModel : IMapFrom<Phonebook.Model.Entities.PhoneBookEntry>
    {
        public IList<PhoneBookEntryDto> Entries { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(Phonebook.Model.Entities.PhoneBookEntry), GetType());
        }
    }
}
