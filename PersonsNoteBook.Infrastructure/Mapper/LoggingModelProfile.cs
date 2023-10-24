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
    public class LoggingModelProfile : Profile
    {
        public LoggingModelProfile()
        {
            CreateMap<LoggingEntity, LoggingModel>();
            CreateMap<LoggingModel, LoggingEntity>();
        }
    }
}
