using api_crud_csharp.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_crud_csharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
