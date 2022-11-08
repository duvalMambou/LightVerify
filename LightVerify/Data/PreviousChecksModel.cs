using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightVerify.Data
{
    public class PreviousChecksModel
    {
        private const string HTTP_GET_STATUS_URL = "https://localhost:7079/api/ArduinoResponse";
        private const string HTTP_POST_STATUS_URL = "#########################################";


        private static HttpClient _httpClient = new HttpClient(); // curl


        public async Task<string> GetPreviousChecks()
        {
            dynamic data = string.Empty;

            HttpResponseMessage response = await _httpClient.GetAsync(HTTP_GET_STATUS_URL);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }

    }

}
