using Extrato.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace Extrato.Domain.ViewModel
{
    public class BankRecordViewModel
    {
        public DateTime Data { get; set; }

        [Range(0, 2, ErrorMessage = "O campo {0} precisa ser entre 0 e 2.")]
        public TipoTransacao Tipo { get; set; }

        [Range(0.01, Double.MaxValue, ErrorMessage = "O campo {0} precisa ser maior que {0.01}.")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }

        public static implicit operator BankRecord(BankRecordViewModel recordVM)
        {
            return new BankRecord
            {
                Id = Guid.NewGuid(),
                Data = recordVM.Data,
                Tipo = recordVM.Tipo,
                Valor = System.Math.Round(recordVM.Valor, 2)
            };
        }
        public static implicit operator BankRecordViewModel(BankRecord record)
        {
            return new BankRecordViewModel
            {
                Data = record.Data,
                Tipo = record.Tipo,
                Valor = record.Valor
            };
        }
    }

}
