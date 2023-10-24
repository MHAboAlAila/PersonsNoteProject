using AutoMapper;
using MediatR;
using Microsoft.Identity.Client;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Core.Interfaces;
using PersonsNoteBook.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Infrastructure.Repositories
{
    public class PersonRepository : GenericRepository<PersonEntity, PersonModel>, IPersonRepository
    {
        public PersonRepository(DBContextClass dBContext, IMapper mapper, IMediator mediator) : base(dBContext, mapper, mediator)
        {
        }

        public bool IsPersonActive(int personId)
        {
            var person = GetById(personId);
            if (person != null)
                return person.Result.Active;
            return false;
        }
    }
}
