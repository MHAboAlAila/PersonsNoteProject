using AutoMapper;
using MediatR;
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
    public class AddressRepository : GenericRepository<AddressEntity, AddressModel>, IAddressRepository
    {
        public AddressRepository(DBContextClass dBContext, IMapper mapper, IMediator mediator) : base(dBContext, mapper, mediator)
        {
            
        }
    }
}
