using Extrato.Domain.Configurations;
using Extrato.Domain.ViewModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Extrato.Services.Services
{
    public class RequestsHandlerService
    {
        private readonly IOptions<ApiConfig> _configuration;
        private readonly HttpClient _httpclient;

        public RequestsHandlerService(IOptions<ApiConfig> configuration)
        {
            _configuration = configuration;
            _httpclient = new HttpClient
            {
                BaseAddress = new Uri(_configuration.Value.Endpoints.Url_Api_Extrato)
            };
        }
        public async Task<List<BankRecordFormatedViewModel>> GetBankRecords(string queryString)
        {
            List<BankRecordFormatedViewModel> lista = new List<BankRecordFormatedViewModel>() { };
            HttpResponseMessage response = await _httpclient.GetAsync(_configuration.Value.Endpoints.Url_Api_Extrato + queryString);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<BankRecordFormatedViewModel>>(content);

            }
            return lista;
        }
        public async Task CreateBankRecords(BankRecordViewModel record)
        {
            string json = JsonConvert.SerializeObject(record);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            ByteArrayContent byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _httpclient.PostAsync(_configuration.Value.Endpoints.Url_Api_Extrato, byteContent);
        }
    }
}
