using System.ComponentModel.DataAnnotations;

namespace Extrato.Domain.ViewModel
{
    public class BankRecordFormatedViewModel
    {
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public string Data { get; set; }

        [Range(0, 2, ErrorMessage = "The field {0} must be greater than {0}.")]
        public TipoTransacao Tipo { get; set; }

        [Range(0.01, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {0.01}.")]
        public decimal Valor { get; set; }
    }

}
