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
    public class LoggingRepository : GenericRepository<LoggingEntity, LoggingModel>, ILoggingRepository
    {
        public LoggingRepository(DBContextClass Context, IMapper mapper, IMediator mediator) : base(Context, mapper, mediator)
        {
        }
    }
}
