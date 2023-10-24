using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersonsNoteBook.Infrastructure
{
    public class DBContextDesignFactory : IDesignTimeDbContextFactory<DBContextClass>
    {
        public DBContextClass CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContextClass>();
            var connectionString = "Server=MHASANLAPTOP;Database=DemoDB;Trusted_Connection=True;Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
            return new DBContextClass(optionsBuilder.Options);
        }
    }
}
