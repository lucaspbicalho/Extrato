using Extrato.Api.ViewModel;
using Extrato.Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrato.Infrastructure.Repositories
{
    public interface IBankRecordRepository
    {
        public List<BankRecord> Listar();
        public List<BankRecord> Listar(FiltroDiasExtrato date);
        public BankRecord GetById(Guid id);
        public void Save(BankRecordViewModel recordVM);
    }
}
