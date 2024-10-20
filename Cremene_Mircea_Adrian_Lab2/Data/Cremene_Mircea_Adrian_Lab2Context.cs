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
        public DbSet<Cremene_Mircea_Adrian_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
