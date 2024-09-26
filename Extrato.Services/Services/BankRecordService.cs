using Extrato.Domain.Entites;
using Extrato.Infrastructure.Repositories;

namespace Extrato.Services.Services
{
    public class BankRecordService
    {
        private readonly IBankRecordRepository _bankRecordRepository;

        public BankRecordService(IBankRecordRepository clienteRepository)
        {
            _bankRecordRepository = clienteRepository;
        }

        public List<BankRecord> Listar()
        {
            return _bankRecordRepository.Listar();
        }               
    }
}
