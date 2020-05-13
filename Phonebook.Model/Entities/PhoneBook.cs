using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Model.Entities
{
    public class PhoneBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PhoneBookEntry> Entries { get; set; }

        public PhoneBook()
        {
            Entries = new List<PhoneBookEntry>();
        }
    }
}
