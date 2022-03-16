using Lieferando.Interfaces;
using Lieferando.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lieferando.Clients.Requests
{
    public sealed class TakeawayOrderRequest : TakeawayRequest
    {
        private readonly TakeawayHttpApiClient _takeawayHttpApiClient;

        public TakeawayOrderRequest(TakeawayHttpApiClient takeawayHttpApiClient)
        {
            _takeawayHttpApiClient = takeawayHttpApiClient;
        }

        public override string Name => "Order";

        public override string Endpoint => "checkout/place_order";

        public async Task<string> Request(TakeawayOrderData takeawayOrderData)
        {
            var requestParameters = new Dictionary<string, string> {};

            _takeawayHttpApiClient.Params = requestParameters;
            _takeawayHttpApiClient.Data = takeawayOrderData;

            return await _takeawayHttpApiClient.Request(HttpMethod.Post, this);
        }
    }
}
