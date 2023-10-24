using AutoMapper;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.Mapper
{
    public class PersonDtoProfile : Profile
    {
        public PersonDtoProfile()
        {
            CreateMap<PersonDto, PersonEntity>();
            CreateMap<AddressDto, AddressEntity>();

            CreateMap<PersonEntity, PersonDto>();
            CreateMap<AddressEntity, AddressDto>();
        }

    }
}
