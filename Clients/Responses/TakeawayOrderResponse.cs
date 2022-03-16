using Newtonsoft.Json;
using System;

namespace Lieferando.Clients.Requests
{
    public partial class TakeawayOrderResponse
    {
        public partial class AuthenticationData
        {
            [JsonProperty("authToken")]
            public string AuthToken { get; set; }

            [JsonProperty("refreshToken")]
            public string RefreshToken { get; set; }
        }

        [JsonProperty("foodTracking")]
        public Uri FoodTracking { get; set; }

        [JsonProperty("scooberTracking")]
        public Uri ScooberTracking { get; set; }

        [JsonProperty("paymentId")]
        public object PaymentId { get; set; }

        [JsonProperty("paymentPageUrl")]
        public object PaymentPageUrl { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("customerHash")]
        public string CustomerHash { get; set; }

        [JsonProperty("orderInformation")]
        public string OrderInformation { get; set; }

        [JsonProperty("authentication")]
        public AuthenticationData Authentication { get; set; }
    }
}
