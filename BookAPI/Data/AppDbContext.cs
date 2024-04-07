using Microsoft.EntityFrameworkCore;
using BookAPI.Books.Model;

namespace BookAPI.Data
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public virtual DbSet<Book> Books { get; set; }
        }
}
