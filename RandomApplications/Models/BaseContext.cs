using System.Data.Entity;

namespace RandomApplications.Models
{
    /// <summary>
    /// подключение к базе данных
    /// </summary>
    public class BaseContext : DbContext
    {
        /// <summary>
        /// путь по умолчанию
        /// </summary>
        public BaseContext() : base("DefaultConnection")
        {

        }

        /// <summary>
        /// таблица заявок
        /// </summary>
        public DbSet<BaseApplication> BaseApplications { get; set; }

        /// <summary>
        /// таблица истории изменений
        /// </summary>
        public DbSet<BaseHistory> BaseHistories { get; set; }
    }
}