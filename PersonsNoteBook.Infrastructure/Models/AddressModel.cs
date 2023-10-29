using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Infrastructure.Models
{
    [Table("Addresses", Schema = "NoteBook")]
    public class AddressModel : BaseModel
    {
        [ForeignKey("PersonId")]
        public PersonModel Person { get; set; }

        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please enter Country")]
        [StringLength(100)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter PoBox")]
        [Display(Name = "Post Office Box")]
        public string PoBox { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Street")]
        [StringLength(100)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter Apartment")]
        [StringLength(100)]
        public string Apartment { get; set; }

        [Required(ErrorMessage ="Please chek Primary")]
        public bool Primary { get; set; }
    }
}
