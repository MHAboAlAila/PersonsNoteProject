using PersonsNoteBook.Core.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Core.Entities
{
    public class PersonEntity : BaseEntity
    {
        internal List<AddressEntity> _addresses = new();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<AddressEntity> Addresses => new Collection<AddressEntity>(_addresses);
        public bool Active { get; set; }

        public PersonEntity(List<AddressEntity> addresses, string firstName, string lastName)
        {
            _addresses = addresses;
            FirstName = firstName;
            LastName = lastName;
            Active = true;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;

            AddPersonCreatedDomainEvent(Id, FirstName, LastName);
        }

        public PersonEntity(string fistName, string lastName)
        {
            FirstName = fistName;
            LastName = lastName;

            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;

            AddPersonCreatedDomainEvent(Id, FirstName, LastName);
        }

        public void UpdatePerson(string fistName, string lastName)
        {
            FirstName = fistName;
            LastName = lastName;

            UpdateAt = DateTime.Now;
        }

        public void ActivePerson()
        {
            Active = true;
            UpdateAt = DateTime.Now;
        }

        public void DeActivePerson()
        {
            Active = false;
            UpdateAt = DateTime.Now;
        }

        public void AddAddress(string country, string poBox, string city, string street, string apartment, bool primary)
        {
            _addresses.Add(new AddressEntity(country, poBox, city, street, apartment, primary));
        }

        public void RemoveAddress(int id)
        {
            _addresses.RemoveAll(address => address.Id == id);
        }

        public void UpdateAddress(int id, string country, string poBox, string city, string street, string apartment, bool primary)
        {
            AddressEntity? _address = _addresses.Find(address => address.Id == id);
            if (_address != null)
            {
                _address.UpdateAddress(country, poBox, city, street, apartment, primary);
            }
        }

        private void AddPersonCreatedDomainEvent(int Id, string FirstName, string LastName)
        {
            var personCreatedDomainEvent = new PersonCreatedDomainEvent(Id, FirstName, LastName);

            this.AddDomainEvent(personCreatedDomainEvent);
        }
    }
}
