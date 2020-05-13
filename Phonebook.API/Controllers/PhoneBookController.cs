using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Core.PhoneBook.Commands;
using Phonebook.Core.PhoneBook.Queries;
using Phonebook.Core.PhoneBook.ViewModels;

namespace Phonebook.API.Controllers
{
    public class PhoneBookController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> CreatePhoneBook(CreatePhoneBook command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<PhoneBookListViewModel>> GetPhoneBooksList()
        {
            return await Mediator.Send(new GetPhoneBookList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneBookViewModel>> GetPhoneBook(int id)
        {
            return await Mediator.Send(new GetPhoneBook { Id = id });
        }        

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhoneBook(long id, UpdatePhoneBook command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoneBook(long id, DeletePhoneBook command)
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