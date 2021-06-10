using BS.Models;
using Microsoft.EntityFrameworkCore;

namespace BS.Data
{
    public class BSContext:DbContext
    {
        public BSContext (DbContextOptions<BSContext> opt): base(opt)
        {
        }

        public DbSet<Race> Race {get; set;}
        public DbSet<Player> Player {get; set;}
        public DbSet<Map> Map {get; set;}
        public DbSet<Match> Match {get; set;}
        public DbSet<Country> Country {get; set;}
        public DbSet<User> User {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
                .Property(user => user.Role).HasDefaultValue("Player");
        }
    }
}