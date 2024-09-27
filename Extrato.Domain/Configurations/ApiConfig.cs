using System.Net;

namespace Extrato.Domain.Configurations
{
    public class ApiConfig
    {
        public Endpoints Endpoints { get; set; }
    }
    public class Endpoints
    {
        public string Url_Api_Extrato { get; set; }    
    }
}
