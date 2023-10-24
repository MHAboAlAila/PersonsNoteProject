using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Core.Entities
{
    public class LoggingEntity : BaseEntity
    {
        public string LogInfo { get; set; }

        public LoggingEntity(string logInfo)
        {
            LogInfo = logInfo;
        }
    }
}
