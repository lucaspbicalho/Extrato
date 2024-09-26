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
    }
}
