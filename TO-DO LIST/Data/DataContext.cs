using Microsoft.EntityFrameworkCore;

namespace TO_DO_LIST.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<TO_DO_LIST.Models.TaskItem> Tasks { get; set; }
    }
}
