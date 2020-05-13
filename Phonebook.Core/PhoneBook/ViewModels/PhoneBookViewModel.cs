using AutoMapper;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.PhoneBook.ViewModels
{
    public class PhoneBookViewModel : IMapFrom<Phonebook.Model.Entities.PhoneBook>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(Phonebook.Model.Entities.PhoneBook), GetType());
        }
    }
}
