using Extrato.Api.ViewModel;
using Extrato.Domain.Entites;
using Extrato.Infrastructure.Repositories;
using System.Data;

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

        public IEnumerable<object> Listar(FiltroDiasExtrato date)
        {
            var bankRecords = _bankRecordRepository.Listar(date)
                .Select(s => new { s.Id, data = s.Data.ToString("dd/MM"), s.Valor });
            return bankRecords;
        }
        public BankRecord GetById(Guid id)
        {
            var bankRecord = _bankRecordRepository.GetById(id);
            return bankRecord;
        }
        public void Save(BankRecordViewModel recordVM)
        {
            _bankRecordRepository.Save(recordVM);
        }

    }
}
