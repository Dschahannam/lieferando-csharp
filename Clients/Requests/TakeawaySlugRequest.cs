using Lieferando.Interfaces;
using Lieferando.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lieferando.Clients.Requests
{
    public sealed class TakeawaySlugRequest : TakeawayRequest
    {
        private readonly TakeawayHttpApiClient _takeawayHttpApiClient;

        public TakeawaySlugRequest(TakeawayHttpApiClient takeawayHttpApiClient)
        {
            _takeawayHttpApiClient = takeawayHttpApiClient;
        }

        public override string Name => "Slug";

        public override string Endpoint => "restaurant";

        public async Task<TakeawaySlugResponse> Request(string slugName)
        {
            var requestParameters = new Dictionary<string, string>
            {
                { "slug", slugName}
            };

            _takeawayHttpApiClient.Params = requestParameters;
            _takeawayHttpApiClient.FinishedTour = true;

            return JsonConvert.DeserializeObject<TakeawaySlugResponse>(await _takeawayHttpApiClient.Request(HttpMethod.Get, this));
        }
    }
}
