using System.Configuration;
using System.Data.Entity;

namespace RandomApplications.Models
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("DefaultConnection")
        {

        }

        public DbSet<BaseApplication> BaseApplications { get; set; }

        public DbSet<BaseHistory> BaseHistories { get; set; }
    }
}