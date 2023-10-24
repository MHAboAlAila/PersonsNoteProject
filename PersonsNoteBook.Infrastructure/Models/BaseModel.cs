using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Infrastructure.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdateAt { get; set; }
    }
}
