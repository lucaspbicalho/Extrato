using Extrato.Domain.Entites;

namespace Extrato.Infrastructure.Repositories
{
    public interface IBankRecordRepository
    {
        public List<BankRecord> GetAll();
        public List<BankRecord> GetAll(FiltroDiasExtrato date);
        public BankRecord GetById(Guid id);
        public void Save(BankRecord recordVM);
    }
}
