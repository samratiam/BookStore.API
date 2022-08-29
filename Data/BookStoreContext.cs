using Microsoft.EntityFrameworkCore;
namespace BookStore.API.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base (options)
        {
        // Create the table named "Books"
        public DbSet<Books> Books { get; set;}

        // To set the database string: Approach 1
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookStoreAPI;");
            base.OnConfiguring(optionsBuilder);
        }   

        }
    }
}