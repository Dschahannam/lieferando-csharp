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
using System.Threading;
using Lieferando.Managers;
using Lieferando.Clients.Requests;
using System.Linq;
using System.Net;

namespace Lieferando.Clients
{
    public sealed class TakeawayHttpApiClientHandler : HttpClientHandler
    {
        public TakeawayHttpApiClientHandler()
        {
            UseProxy = true;

            Proxies = new Dictionary<int, TakeawayProxy>()
            {
                {1, new TakeawayProxy("159.69.137.249", 80) }
            };
        }

        public int TargetProxyIndex { get; set; }
        public Dictionary<int, TakeawayProxy> Proxies { get; set; } = new Dictionary<int, TakeawayProxy>();

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessageResult = await base.SendAsync(request, cancellationToken);

            if (request.Headers.TryGetValues("FinishedTour", out IEnumerable<string> finishedTourValues))
            {
                bool finishedTour = Convert.ToBoolean(finishedTourValues.FirstOrDefault());
                // DO PROXY ROTATION
                if (finishedTour)
                {
                    if (TargetProxyIndex >= Proxies.Count) TargetProxyIndex = 1;
                    else TargetProxyIndex++;

                    if (Proxies.TryGetValue(TargetProxyIndex, out TakeawayProxy takeawayProxy))
                    {
                        Proxy = new WebProxy(takeawayProxy.Host, takeawayProxy.Port);
                        Console.WriteLine("Rotated proxy", finishedTour);
                    }
                }
            }

            return httpResponseMessageResult;
        }
    }

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
        public bool FinishedTour { get; set; } = false;

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

            apiRequest.Headers.Add("FinishedTour", FinishedTour.ToString());

            HttpResponseMessage apiResponse = await Client.SendAsync(apiRequest);

            if (FinishedTour) FinishedTour = false;

            return await apiResponse.Content.ReadAsStringAsync();
        }
    }
}
