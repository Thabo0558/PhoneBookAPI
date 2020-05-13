using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Core.PhoneBookEntry.Commands;
using Phonebook.Core.PhoneBookEntry.Queries;
using Phonebook.Core.PhoneBookEntry.ViewModels;

namespace Phonebook.API.Controllers
{
    public class PhonebookEntryController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> CreatePhoneBookEntry(CreatePhoneBookEntry command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneBookEntryViewModel>> GetPhoneBookEntry(long id)
        {
            return await Mediator.Send(new GetPhoneBookEntry { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult<PhoneBookEntryListViewModel>> GetPhoneBookEntries()
        {
            return await Mediator.Send(new GetPhoneBookEntryList());
        }              

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhoneBookEntry(long id, UpdatePhoneBookEntry command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoneBookEntry(long id, DeletePhoneBookEntry command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}