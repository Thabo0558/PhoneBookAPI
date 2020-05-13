using Phonebook.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.PhoneBook.ViewModels
{
    public class PhoneBookListViewModel
    {
        public IList<PhoneBookDto> PhoneBooks { get; set; }
    }
}
