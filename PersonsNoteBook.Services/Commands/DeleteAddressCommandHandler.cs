using MediatR;
using PersonsNoteBook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.Commands
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository; 
        }

        async Task<bool> IRequestHandler<DeleteAddressCommand, bool>.Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetById(request.AddressId);
            if (address == null) { return false; };
            _addressRepository.Delete(address);
            return true;
        }
    }
}
