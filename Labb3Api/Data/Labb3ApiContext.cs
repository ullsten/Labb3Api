using System.ComponentModel;
using Labb3Api.Models;
using Microsoft.EntityFrameworkCore;
using Labb3ApiWeb.Models;

namespace Labb3ApiWeb.Data
{
    public class Labb3ApiContext : DbContext
    {
        public Labb3ApiContext(DbContextOptions<Labb3ApiContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<Interest> Interests { get; set; } = default!;
        public DbSet<Link> Links { get; set; } = default!;
    }
}
