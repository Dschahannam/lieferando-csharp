using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Lieferando.Clients.Requests
{
    public class TakeawayRestaurantsResponse
    {
        public partial class Aggregate
        {
            [JsonProperty("cuisines")]
            public Dictionary<string, string[]> Cuisines { get; set; }

            [JsonProperty("shipping")]
            public Shipping Shipping { get; set; }

            [JsonProperty("paymentMethods")]
            public PaymentMethods PaymentMethods { get; set; }

            [JsonProperty("topRank")]
            public string[] TopRank { get; set; }
        }

        public partial class PaymentMethods
        {
            [JsonProperty("sofort")]
            public string[] Sofort { get; set; }

            [JsonProperty("cash")]
            public string[] Cash { get; set; }

            [JsonProperty("paypal")]
            public string[] Paypal { get; set; }

            [JsonProperty("creditcard")]
            public string[] Creditcard { get; set; }

            [JsonProperty("giropay")]
            public string[] Giropay { get; set; }

            [JsonProperty("bitpay")]
            public string[] Bitpay { get; set; }
        }

        public partial class Shipping
        {
            [JsonProperty("delivery")]
            public string[] Delivery { get; set; }

            [JsonProperty("pickup")]
            public string[] Pickup { get; set; }
        }

        public partial class Currency
        {
            [JsonProperty("denominator")]
            public long Denominator { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }
        }

        public partial class Notification
        {
            [JsonProperty("delivery")]
            public string Delivery { get; set; }

            [JsonProperty("pickup")]
            public string Pickup { get; set; }
        }

        public partial class Restaurant
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("primarySlug")]
            public string PrimarySlug { get; set; }

            [JsonProperty("indicators")]
            public Indicators Indicators { get; set; }

            [JsonProperty("priceRange")]
            public long PriceRange { get; set; }

            [JsonProperty("popularity")]
            public long Popularity { get; set; }

            [JsonProperty("brand")]
            public Brand Brand { get; set; }

            [JsonProperty("cuisineTypes")]
            public string[] CuisineTypes { get; set; }

            [JsonProperty("rating")]
            public Rating Rating { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("supports")]
            public Supports Supports { get; set; }

            [JsonProperty("shippingInfo")]
            public ShippingInfo ShippingInfo { get; set; }

            [JsonProperty("paymentMethods")]
            public string[] PaymentMethods { get; set; }
        }

        public partial class Brand
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("logoUrl")]
            public Uri LogoUrl { get; set; }

            [JsonProperty("heroImageUrl")]
            public Uri HeroImageUrl { get; set; }

            [JsonProperty("heroImageUrlType")]
            public string HeroImageUrlType { get; set; }

            [JsonProperty("branchName")]
            public string BranchName { get; set; }
        }

        public partial class Indicators
        {
            [JsonProperty("isDeliveryByScoober")]
            public bool IsDeliveryByScoober { get; set; }

            [JsonProperty("isNew")]
            public bool IsNew { get; set; }

            [JsonProperty("isTestRestaurant")]
            public bool IsTestRestaurant { get; set; }

            [JsonProperty("isSponsored")]
            public bool IsSponsored { get; set; }
        }

        public partial class Location
        {
            [JsonProperty("streetAddress")]
            public string StreetAddress { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("lat")]
            public string Lat { get; set; }

            [JsonProperty("lng")]
            public string Lng { get; set; }

            [JsonProperty("timeZone")]
            public string TimeZone { get; set; }
        }

        public partial class Rating
        {
            [JsonProperty("votes")]
            public long Votes { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public partial class ShippingInfo
        {
            [JsonProperty("delivery")]
            public Delivery Delivery { get; set; }

            [JsonProperty("pickup")]
            public Pickup Pickup { get; set; }
        }

        public partial class Delivery
        {
            [JsonProperty("isOpenForOrder")]
            public bool IsOpenForOrder { get; set; }

            [JsonProperty("isOpenForPreorder")]
            public bool IsOpenForPreorder { get; set; }

            [JsonProperty("openingTime")]
            public object OpeningTime { get; set; }

            [JsonProperty("duration")]
            public long Duration { get; set; }

            [JsonProperty("durationRange")]
            public DurationRange DurationRange { get; set; }

            [JsonProperty("deliveryFeeDefault")]
            public long DeliveryFeeDefault { get; set; }

            [JsonProperty("minOrderValue")]
            public long MinOrderValue { get; set; }

            [JsonProperty("lowestDeliveryFee")]
            public LowestDeliveryFee LowestDeliveryFee { get; set; }
        }

        public partial class DurationRange
        {
            [JsonProperty("min")]
            public long Min { get; set; }

            [JsonProperty("max")]
            public long Max { get; set; }
        }

        public partial class LowestDeliveryFee
        {
            [JsonProperty("from")]
            public long From { get; set; }

            [JsonProperty("fee")]
            public long Fee { get; set; }
        }

        public partial class Pickup
        {
            [JsonProperty("isOpenForOrder")]
            public bool IsOpenForOrder { get; set; }

            [JsonProperty("isOpenForPreorder")]
            public bool IsOpenForPreorder { get; set; }

            [JsonProperty("openingTime")]
            public object OpeningTime { get; set; }

            [JsonProperty("distance")]
            public Distance Distance { get; set; }
        }

        public partial class Distance
        {
            [JsonProperty("unit")]
            public string Unit { get; set; }

            [JsonProperty("quantity")]
            public long Quantity { get; set; }
        }

        public partial class Supports
        {
            [JsonProperty("delivery")]
            public bool Delivery { get; set; }

            [JsonProperty("pickup")]
            public bool Pickup { get; set; }

            [JsonProperty("vouchers")]
            public bool Vouchers { get; set; }

            [JsonProperty("stampCards")]
            public bool StampCards { get; set; }

            [JsonProperty("discounts")]
            public bool Discounts { get; set; }
        }

        public enum PaymentMethod { Bitpay, Cash, Creditcard, Giropay, Paypal, Sofort, PinAtHome, CreditcardAtHome };

        [JsonProperty("restaurants")]
        public Dictionary<string, Restaurant> Restaurants { get; set; }

        [JsonProperty("notification")]
        public Notification Notifications { get; set; }

        [JsonProperty("exceptionalStatus")]
        public object ExceptionalStatus { get; set; }

        [JsonProperty("currency")]
        public Currency Currencies { get; set; }

        [JsonProperty("aggregates")]
        public Aggregate Aggregates { get; set; }
    }
}
