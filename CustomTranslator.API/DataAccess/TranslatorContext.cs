using Microsoft.EntityFrameworkCore;

namespace CustomTranslator.API.DataAccess
{
    public class TranslatorContext : DbContext
    {
        public DbSet<TranslatorHistory> TranslatorHistorys { get; set; }

        public TranslatorContext(DbContextOptions options) : base(options)
        {
        }
    }
}
