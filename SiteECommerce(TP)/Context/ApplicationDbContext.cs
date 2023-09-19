using Microsoft.EntityFrameworkCore;

namespace SiteECommerce_TP_.Context
{
    public class ApplicationDbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }
    }
}
