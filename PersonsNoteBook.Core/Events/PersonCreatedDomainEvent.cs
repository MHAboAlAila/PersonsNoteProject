using MediatR;

namespace PersonsNoteBook.Core.Events
{
    public class PersonCreatedDomainEvent : INotification
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public PersonCreatedDomainEvent(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
