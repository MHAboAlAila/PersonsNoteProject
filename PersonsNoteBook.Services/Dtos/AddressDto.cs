using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.Dtos
{
    public record AddressDto
    {
        public int Id { get; init; }
        public string Country { get; init; }
        public string PoBox { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Apartment { get; init; }
        public bool Primary { get; init; }
    }
}
