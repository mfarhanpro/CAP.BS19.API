using CAP.BS19.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CAP.BS19.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
    }
}