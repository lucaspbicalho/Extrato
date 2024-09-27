using Extrato.Domain.Entites;

namespace Extrato.Infrastructure
{
    public class FakeContext 
    {
        public List<BankRecord> BankRecords;
        public FakeContext() 
        {
            BankRecords = new List<BankRecord>() { };
        }
    }
}
