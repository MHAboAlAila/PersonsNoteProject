using AutoMapper;
using MediatR;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Core.Interfaces;
using PersonsNoteBook.Services.Dtos;
using PersonsNoteBook.Services.Exceptions;
using PersonsNoteBook.Services.Interfaces;
using System;

namespace PersonsNoteBook.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreatePerson(PersonDto person)
        {
            if (person != null)
            {
                _unitOfWork.CreateTransaction();

                try
                {
                    var entity = _mapper.Map<PersonEntity>(person);
                    await _personRepository.Add(entity);
                    _unitOfWork.Save();
                    _unitOfWork.Commit();
                    return true;
                }
                catch
                {
                    _unitOfWork.Rollback();
                    throw new Exception();
                }
            }
            return false;
        }
        public async Task<bool> UpdatePerson(PersonDto person)
        {
            if (person != null)
            {
                _unitOfWork.CreateTransaction();

                try
                {
                    var personObj = await _personRepository.GetById(person.Id);
                    if (personObj != null)
                    {
                        personObj.UpdatePerson(person.FirstName, person.LastName);

                        foreach(var address in personObj.Addresses)
                        {
                            var addressObj = await _addressRepository.GetById(address.Id);
                            addressObj.UpdateAddress(address.Country, address.PoBox, address.City, address.Street, address.Apartment);
                        }

                        _unitOfWork.Save();
                        _unitOfWork.Commit();
                        return true;
                    }
                }
                catch
                {
                    _unitOfWork.Rollback();
                    throw new Exception();
                }
            }
            return false;
        }

        public async Task<bool> PersonActivate(int PersonId, bool Activation)
        {
            if (PersonId != 0)
            {
                var personObj = await _personRepository.GetById(PersonId);
                if (personObj != null)
                {
                    _unitOfWork.CreateTransaction();

                    try
                    {
                        if (Activation)
                            personObj.ActivePerson();
                        else
                            personObj.DeActivePerson();

                        _personRepository.update(personObj);

                        _unitOfWork.Save();
                        _unitOfWork.Commit();
                        return true;
                    }
                    catch
                    {
                        _unitOfWork.Rollback();
                        throw new Exception();
                    }
                }
                return false;

            }
            return false;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersons()
        {
            var personsList = await _personRepository.GetAll();
            List<PersonDto> dtos = new List<PersonDto>();
            foreach(var person in personsList)
            {
                var dto = _mapper.Map<PersonDto>(person);
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<PersonDto> GetPersonById(int PersonId)
        {
            var person = await _personRepository.GetById(PersonId);
            if (person == null)
                throw new NotFoundException($"Person ID {PersonId} not found.");
            var dto = _mapper.Map<PersonDto>(person);
            return dto;
        }

        public Task<bool> AddAddress(int PersonId, AddressDto address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddress(int PersonId, int AddressId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePerson(int PersonId)
        {
            var person = await _personRepository.GetById(PersonId);
            if (person == null) { return false; };
            _personRepository.Delete(person);
            return true;
        }

        public Task<IEnumerable<AddressDto>> GetPersonAddresses(int PersonId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddress(int PersonId, AddressDto address)
        {
            throw new NotImplementedException();
        }
    }
}
