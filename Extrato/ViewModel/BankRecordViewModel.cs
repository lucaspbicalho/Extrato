using Extrato.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace Extrato.Api.ViewModel
{
    public class BankRecordViewModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }

        [Range(0, 2, ErrorMessage = "The field {0} must be greater than {0}.")]
        public TipoTransacao Tipo { get; set; }

        [Range(0.01, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {0.01}.")]
        public decimal Valor { get; set; }

        public static implicit operator BankRecord(BankRecordViewModel recordVM)
        {
            return new BankRecord
            {
                Data = recordVM.Data,
                Tipo = recordVM.Tipo,
                Valor = recordVM.Valor
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
