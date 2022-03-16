using Lieferando.Interfaces;
using Lieferando.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lieferando.Clients.Requests
{

    public sealed class TakeawayGeocoderRequest : TakeawayRequest
    {
        private readonly TakeawayHttpApiClient _takeawayHttpApiClient;

        public TakeawayGeocoderRequest(TakeawayHttpApiClient takeawayHttpApiClient)
        {
            _takeawayHttpApiClient = takeawayHttpApiClient;
        }

        public override string Name => "LocationGecoder";

        public override string Endpoint => "location/geocoder";

        public async Task<TakeawayGecoderResponse> Request(string addressString)
        {
            var requestParameters = new Dictionary<string, string>
            {
                { "addressString", addressString }
            };

            _takeawayHttpApiClient.Params = requestParameters;

            return JsonConvert.DeserializeObject<TakeawayGecoderResponse>(await _takeawayHttpApiClient.Request(HttpMethod.Get, this));
        }
    }
}
