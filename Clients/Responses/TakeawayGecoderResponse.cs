using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lieferando.Clients.Requests
{
    public class TakeawayGecoderResponse
    {
        public class Address
        {
            [JsonProperty("street")]
            public string Street { get; set; }

            [JsonProperty("streetNumber")]
            public string StreetNumber { get; set; }

            [JsonProperty("postalCode")]
            public string PostalCode { get; set; }

            [JsonProperty("district")]
            public string District { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("lat")]
            public string Lat { get; set; }

            [JsonProperty("lng")]
            public string Lng { get; set; }

            [JsonProperty("placeId")]
            public string PlaceId { get; set; }

            [JsonProperty("formattedAddress")]
            public string FormattedAddress { get; set; }

            [JsonProperty("locationSlug")]
            public string LocationSlug { get; set; }

            [JsonProperty("deliveryAreaId")]
            public string DeliveryAreaId { get; set; }

            [JsonProperty("takeawayPostalCode")]
            public string TakeawayPostalCode { get; set; }
        }

        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
    }
}
