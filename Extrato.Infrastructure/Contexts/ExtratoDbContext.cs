using Extrato.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Extrato.Infrastructure
{
    public class ExtratoDbContext : DbContext
    {
        public ExtratoDbContext(DbContextOptions<ExtratoDbContext> options) : base(options)
        {
        }

        public DbSet<BankRecord> BankRecords { get; set; }
    }
}
