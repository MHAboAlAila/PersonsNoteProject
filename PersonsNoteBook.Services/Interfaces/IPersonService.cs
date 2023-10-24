using PersonsNoteBook.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.Interfaces
{
    public interface IPersonService
    {
        Task<bool> CreatePerson(PersonDto person);
        Task<bool> UpdatePerson(PersonDto person);
        Task<bool> PersonActivate(int PersonId, bool Activation);
        Task<bool> DeletePerson(int PersonId);
        Task<PersonDto> GetPersonById(int PersonId);
        Task<IEnumerable<PersonDto>> GetAllPersons();
        Task<bool> AddAddress(int PersonId, AddressDto address);
        Task<bool> UpdateAddress(int PersonId, AddressDto address);
        Task<bool> DeleteAddress(int PersonId, int AddressId);
        Task<IEnumerable<AddressDto>> GetPersonAddresses(int PersonId);
    }
}
