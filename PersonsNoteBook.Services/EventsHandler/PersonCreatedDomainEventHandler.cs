using MediatR;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Core.Events;
using PersonsNoteBook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.EventsHandler
{
    public class PersonCreatedDomainEventHandler : INotificationHandler<PersonCreatedDomainEvent>
    {
        private ILoggingRepository _loggingRepository;
        public PersonCreatedDomainEventHandler(ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }
        public Task Handle(PersonCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var LogInfo = notification.FirstName + notification.LastName;
            var logging = new LoggingEntity(LogInfo);
            _loggingRepository.Add(logging);
            return Task.CompletedTask;
        }
    }
}
