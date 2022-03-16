using Lieferando.Interfaces;
using Lieferando.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lieferando.Clients.Requests
{
    public sealed class TakeawayRestaurantsRequest : TakeawayRequest
    {
        private readonly TakeawayHttpApiClient _takeawayHttpApiClient;

        public TakeawayRestaurantsRequest(TakeawayHttpApiClient takeawayHttpApiClient)
        {
            _takeawayHttpApiClient = takeawayHttpApiClient;
        }

        public override string Name => "RestaurantList";

        public override string Endpoint => "restaurants";

        public async Task<TakeawayRestaurantsResponse> Request(string deliveryAreaId, string postalCode, string latitude, string langtitude, string limit, string isAccurate)
        {
            var requestParameters = new Dictionary<string, string>
            {
                { "deliveryAreaId", deliveryAreaId },
                { "postalCode", postalCode },
                { "lat", latitude },
                { "lng", langtitude },
                { "limit", limit },
                { "isAccurate", isAccurate }
            };

            _takeawayHttpApiClient.Params = requestParameters;

            return JsonConvert.DeserializeObject<TakeawayRestaurantsResponse>(await _takeawayHttpApiClient.Request(HttpMethod.Get, this));
        }
    }
}
