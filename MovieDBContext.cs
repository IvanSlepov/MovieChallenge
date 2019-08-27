using System.Data.Entity;
using System.Diagnostics;


namespace WebApplication1
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("MovieContext")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.Genre> Genre { get; set; }

        public DbSet<Models.User> Users { get; set; }

        public DbSet<Models.Rent> Rents { get; set; }
    }
}