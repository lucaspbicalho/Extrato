using Extrato.Api.ViewModel;
using Extrato.Domain.Entites;

namespace Extrato.Infrastructure.Repositories
{
    public class BankRecordRepository : IBankRecordRepository
    {
        private readonly ExtratoDbContext _context;

        public BankRecordRepository(ExtratoDbContext context)
        {
            _context = context;
        }
        public List<BankRecord> Listar()
        {
            DateTime dateNow = DateTime.Now;
            return _context.BankRecords.ToList();
        }
        public List<BankRecord> Listar(FiltroDiasExtrato date)
        {
            DateTime dateNow = DateTime.Now;
            return _context.BankRecords
            .Where(w => (dateNow - w.Data).TotalDays < (int)date)
                .ToList();
        }
        public BankRecord GetById(Guid id)
        {
            DateTime dateNow = DateTime.Now;
            return _context.BankRecords
                .Where(w => w.Id == id)
                .FirstOrDefault();
        }
        public void Save(BankRecordViewModel recordVM)
        {
            _context.BankRecords.Add(recordVM);
            _context.SaveChanges();
        }
    }
}
