using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace PersonsNoteBook.Infrastructure.Models
{
    [Table("Persons", Schema = "NoteBook")]
    public class PersonModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter First Name.")]
        [StringLength(150, ErrorMessage = "{0} length can't be more than {1}")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name.")]
        [StringLength(150, ErrorMessage = "{0} length can't be more than {1}")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public ICollection<AddressModel> Addresses { get; set; } = new List<AddressModel>();

        [Required(ErrorMessage = "Please determine person active state.")]
        
        private bool _active;
        public bool Active { 
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
    }
}
