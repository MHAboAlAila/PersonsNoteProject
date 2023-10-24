using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Infrastructure.Models
{
    [Table("Logging", Schema = "NoteBook")]
    public class LoggingModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Log Info.")]
        [StringLength(500, ErrorMessage = "{0} length can't be more than {1}")]
        [Display(Name = "Logging Info")]
        public string LogInfo { get; set; }
    }
}
