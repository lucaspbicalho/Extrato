namespace Extrato.Domain.Entites
{
    public class BankRecord
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public TipoTransacao Tipo { get; set; }
        public decimal Valor { get; set; }


    }
}
