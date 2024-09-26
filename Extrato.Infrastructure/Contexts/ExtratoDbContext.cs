using Extrato.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Extrato.Infrastructure
{
    public class ExtratoDbContext : DbContext, IContext
    {
        public ExtratoDbContext(DbContextOptions<ExtratoDbContext> options) : base(options)
        {
        }

        public DbSet<BankRecord> BankRecords { get; set; }
    }
}
