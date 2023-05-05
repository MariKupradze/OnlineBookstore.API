using Microsoft.EntityFrameworkCore;
using OnlineBookstore.API.Models;

namespace OnlineBookstore.API.Context
{

    public class DatabaseContext : DbContext
    {
        /*
         public DbSet<Book> Books { get; set; }
         public DbSet<Author> Authors { get; set; }

         public DatabaseContext(DbContextOptions<DatabaseContext> options)
         : base(options)
         {
             this.Database.EnsureCreated();
         }*/


        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

    }
}


