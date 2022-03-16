using Newtonsoft.Json;
using System;

namespace Lieferando.Clients.Requests
{
    public partial class TakeawayOrderData
    {
        public partial class OrderAddress
        {
            public OrderAddress(string city, string company, string lat, string lng, string postalCode, string streetName, string streetNumber)
            {
                City = city;
                Company = company;
                Lat = lat;
                Lng = lng;
                PostalCode = postalCode;
                StreetName = streetName;
                StreetNumber = streetNumber;
            }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("company")]
            public string Company { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("lat")]
            public string Lat { get; set; }

            [JsonProperty("lng")]
            public string Lng { get; set; }

            [JsonProperty("postalCode")]
            public string PostalCode { get; set; }

            [JsonProperty("streetName")]
            public string StreetName { get; set; }

            [JsonProperty("streetNumber")]
            public string StreetNumber { get; set; }
        }

        public partial class CartItem
        {
            public CartItem(string comment, string id, object[] options, long quantity)
            {
                Comment = comment;
                Id = id;
                Options = options;
                Quantity = quantity;
            }

            [JsonProperty("comment")]
            public string Comment { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("options")]
            public object[] Options { get; set; }

            [JsonProperty("quantity")]
            public long Quantity { get; set; }
        }

        public partial class CookieConsent
        {
            [JsonProperty("consentTypeId")]
            public long ConsentTypeId { get; set; } = 102;

            [JsonProperty("consentTypeName")]
            public string ConsentTypeName { get; set; } = "temporary";

            [JsonProperty("decisionAt")]
            public DateTimeOffset DecisionAt { get; set; } = DateTime.Now;

            [JsonProperty("domain")]
            public string Domain { get; set; } = "lieferando.de";

            [JsonProperty("isAccepted")]
            public bool IsAccepted { get; set; } = true;
        }

        [JsonProperty("address")]
        public OrderAddress Address { get; set; }

        [JsonProperty("cartItems")]
        public CartItem[] CartItems { get; set; }

        [JsonProperty("cookieConsent")]
        public CookieConsent[] CookieConsents { get; set; }

        [JsonProperty("deliveryAreaId")]
        public string DeliveryAreaId { get; set; }

        [JsonProperty("deliveryMethod")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("deliveryTime")]
        public string DeliveryTime { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("exactAmount")]
        public long ExactAmount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("newsletter")]
        public bool Newsletter { get; set; }

        [JsonProperty("paymentInformation")]
        public string PaymentInformation { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("placeId")]
        public string PlaceId { get; set; }

        [JsonProperty("recurringPayment")]
        public string RecurringPayment { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("restaurantId")]
        public string RestaurantId { get; set; }

        [JsonProperty("restrictions")]
        public object[] Restrictions { get; set; }

        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonProperty("takeawayPay")]
        public object TakeawayPay { get; set; }

        [JsonProperty("voucherCode")]
        public string VoucherCode { get; set; }
    }
}
