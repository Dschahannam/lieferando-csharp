using Lieferando.Utilities;
using Lieferando.Interfaces;
using Lieferando.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lieferando.Clients
{
    public sealed class TakeawayHttpApiClient : IHttpTemplatedClient, IHashable
    {
        private readonly IConfiguration Configuration;

        public TakeawayHttpApiClient(HttpClient client, IConfiguration configuration)
        {
            Configuration = configuration;
            Client = client;
        }

        public HttpClient Client { get; }
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
        public object Data { get; set; }

        public string GetHashString()
        {
            string hashString = string.Empty;

            foreach (string valueParam in Params.Values)
                hashString += valueParam;

            hashString += Configuration["Password"];

            return hashString;
        }

        public Dictionary<string, string> GetStandardParameters()
        {
            Dictionary<string, string> headerParameters = new Dictionary<string, string>()
            {
                { "language", "de" },
                { "version", "5.7" },
                { "systemVersion", "24" },
                { "appVersion", "4.15.3.2" }
            };

            return headerParameters;
        }

        public async Task<string> Request(HttpMethod httpMethod, TakeawayRequest takeawayRequest)
        {
            var apiRequest = new HttpRequestMessage(httpMethod, $"/api/v29/{takeawayRequest.Endpoint}?{await new FormUrlEncodedContent(Params).ReadAsStringAsync()}");
            
            if (httpMethod == HttpMethod.Post)
                apiRequest.Content = new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json");

            HttpResponseMessage apiResponse = await Client.SendAsync(apiRequest);

            return await apiResponse.Content.ReadAsStringAsync();
        }
    }
}
