using Cremene_Mircea_Adrian_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cremene_Mircea_Adrian_Lab2.Data
{
    public class Cremene_Mircea_Adrian_Lab2Context : DbContext
    {
        public Cremene_Mircea_Adrian_Lab2Context (DbContextOptions<Cremene_Mircea_Adrian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Member> Member { get; set; } = default!;
        public DbSet<Borrowing> Borrowing { get; set; } = default!;
    }
}
