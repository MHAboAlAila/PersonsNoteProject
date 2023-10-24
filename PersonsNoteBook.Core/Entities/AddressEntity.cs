using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Core.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Country { get; set; }
        public string PoBox { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }

        public AddressEntity(string country, string poBox, string city, string street, string apartment)
        {
            Country = country;
            PoBox = poBox;
            City = city;
            Street = street;
            Apartment = apartment;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void UpdateAddress(string country, string poBox, string city, string street, string apartment)
        {
            Country = country;
            PoBox = poBox;
            City = city;
            Street = street;
            Apartment = apartment;
            UpdateAt = DateTime.Now;
        }
    }
}
