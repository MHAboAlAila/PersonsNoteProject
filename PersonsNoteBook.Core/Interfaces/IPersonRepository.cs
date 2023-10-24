using PersonsNoteBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Core.Interfaces
{
    public interface IPersonRepository : IGenericRepository<PersonEntity>
    {
        public bool IsPersonActive(int personId);
    }
}
