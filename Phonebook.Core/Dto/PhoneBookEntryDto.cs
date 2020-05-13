using AutoMapper;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.Dto
{
    public class PhoneBookEntryDto : IMapFrom<Phonebook.Model.Entities.PhoneBookEntry>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(Phonebook.Model.Entities.PhoneBookEntry), GetType());
        }
    }
}
