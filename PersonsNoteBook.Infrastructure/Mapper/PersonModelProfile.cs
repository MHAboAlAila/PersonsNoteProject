using AutoMapper;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Infrastructure.Mapper
{
    public class PersonModelProfile : Profile
    {
        public PersonModelProfile()
        {
            CreateMap<PersonEntity, PersonModel>();
            CreateMap<AddressEntity, AddressModel>();

            CreateMap<PersonModel, PersonEntity>();
            CreateMap<AddressModel, AddressEntity>();
        }
    }
}
