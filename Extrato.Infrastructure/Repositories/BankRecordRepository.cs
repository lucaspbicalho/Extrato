using Extrato.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrato.Infrastructure.Repositories
{
    public class BankRecordRepository : IBankRecordRepository
    {
        private readonly FakeContext _context;
        public List<BankRecord> Listar()
        {
            return _context.BankRecords
                 .ToList();
        }
    }
}
