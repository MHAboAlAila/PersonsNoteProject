
using MediatR;

namespace PersonsNoteBook.Core.Entities
{
    public abstract class BaseEntity
    {
        private List<INotification>? _domainEvents;
        public IReadOnlyCollection<INotification>? DomainEvents
        {
            get
            {
                if (_domainEvents != null)
                    return _domainEvents.AsReadOnly();
                return null;
            }
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public int Id { get; private set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
