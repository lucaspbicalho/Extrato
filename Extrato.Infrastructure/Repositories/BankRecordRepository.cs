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
        public List<BankRecord> GetAll()
        {
            DateTime dateNow = DateTime.Now;
            return _context.BankRecords.ToList();
        }
        public List<BankRecord> GetAll(FiltroDiasExtrato date)
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
        public void Save(BankRecord recordVM)
        {
            _context.BankRecords.Add(recordVM);
            _context.SaveChanges();
        }
    }
}
