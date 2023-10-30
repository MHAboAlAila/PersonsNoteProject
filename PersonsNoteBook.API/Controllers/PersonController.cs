using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsNoteBook.Services.Queries;
using PersonsNoteBook.Services.Dtos;
using PersonsNoteBook.Services.Interfaces;
using PersonsNoteBook.Services.Commands;
using System;

namespace PersonsNoteBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMediator _mediator;
        public PersonController(IPersonService personService, IMediator mediator)
        {
            _personService = personService;
            _mediator = mediator;
        }

        [HttpGet("GetPersonList")]
        public async Task<IActionResult> GetPersonList()
        {
            var personList = await _personService.GetAllPersons();
            if (personList == null)
            {
                return NotFound();
            }
            return Ok(personList);
        }

        [HttpGet("GetPerson")]
        public async Task<IActionResult> GetPerson(int Id)
        {
            var person = await _personService.GetPersonById(Id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonDto person)
        {
            if (person != null)
            {
                var IsPersonCreated = await _personService.CreatePerson(person);
                if (IsPersonCreated)
                {
                    return Ok(IsPersonCreated);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int Id)
        {
            var IsPersonDeleted = await _personService.DeletePerson(Id);
            if (IsPersonDeleted)
            {
                return Ok(IsPersonDeleted);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("PersonActivation")]
        public async Task<IActionResult> PersonActivation(int Id, bool Activation)
        {
            var IsActivationHandled = await _personService.PersonActivate(Id, Activation);
            if (IsActivationHandled)
            {
                return Ok(IsActivationHandled);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("ActivatedPersons")]
        public async Task<IActionResult> GetActivatedPersons()
        {
            var persons = await _mediator.Send(new GetActivatedPersonsQuery());
            if (persons == null)
            {
                return NotFound();
            }
            return Ok(persons);
        }

        [HttpDelete("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int personId, int addressId)
        {
            await _mediator.Send(new DeleteAddressCommand(personId, addressId));
            return Ok();
        }
    }
}
