using District.Models;
using Microsoft.EntityFrameworkCore;

namespace District.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<DistrictInfo> DisrictInfos { get; set; }

        public DbSet<MuncipalityInfo> MuncipalityInfos { get; set; }
        public DbSet<ToleInfo> ToleInfos { get; set; }


    }
}
