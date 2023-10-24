using Microsoft.EntityFrameworkCore;
using PersonsNoteBook.Infrastructure.Models;

namespace PersonsNoteBook.Infrastructure
{
    public class DBContextClass : DbContext
    {
        
        public DBContextClass(DbContextOptions<DBContextClass> contextOptions) : base(contextOptions)
        {
            
        }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<LoggingModel> Logging { get; set; }
    }
}
