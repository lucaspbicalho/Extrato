using Extrato.Domain.Entites;
using Extrato.Domain.ViewModel;
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
            return _bankRecordRepository.GetAll();
        }

        public List<BankRecordFormatedViewModel> Listar(FiltroDiasExtrato date)
        {
            var bankRecords = _bankRecordRepository.GetAll(date)
                .Select(s => new BankRecordFormatedViewModel { Data = s.Data.ToString("dd/MM"), Tipo = s.Tipo, Valor = s.Valor })
                .ToList();
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
