using webapp_travel_agency.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace webapp_travel_agency
{
    public class SmartBoxContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<SmartBox>? smartBoxes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-travel_agency;Integrated Security=True");
        }
    }
}
