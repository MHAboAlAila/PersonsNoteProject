using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.Commands
{
    public record DeleteAddressCommand : IRequest<bool>
    {
        public int PersonId { get; init; }
        public int AddressId { get; init; }

        public DeleteAddressCommand(int personId, int addressId)
        {
            PersonId = personId;
            AddressId = addressId;
        }
    }
}
