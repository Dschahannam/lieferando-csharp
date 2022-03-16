using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Lieferando.Clients.Requests
{
    public class TakeawaySlugResponse
    {
        public partial class Brands
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("branchName")]
            public string BranchName { get; set; }

            [JsonProperty("chainId")]
            public string ChainId { get; set; }

            [JsonProperty("description")]
            public object[] Description { get; set; }

            [JsonProperty("slogan")]
            public string Slogan { get; set; }

            [JsonProperty("logoUrl")]
            public Uri LogoUrl { get; set; }

            [JsonProperty("headerImageUrl")]
            public Uri HeaderImageUrl { get; set; }
        }

        public partial class Colophons
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("branchName")]
            public string BranchName { get; set; }

            [JsonProperty("restaurantName")]
            public string RestaurantName { get; set; }

            [JsonProperty("streetName")]
            public string StreetName { get; set; }

            [JsonProperty("streetNumber")]
            public string StreetNumber { get; set; }

            [JsonProperty("postalCode")]
            public string PostalCode { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("legalEntity")]
            public string LegalEntity { get; set; }

            [JsonProperty("legalRepresentativeName")]
            public string LegalRepresentativeName { get; set; }

            [JsonProperty("legalName")]
            public string LegalName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("fax")]
            public string Fax { get; set; }

            [JsonProperty("chamberOfCommerce")]
            public ChamberOfCommerce[] ChamberOfCommerce { get; set; }

            [JsonProperty("vatNumber")]
            public object VatNumber { get; set; }

            [JsonProperty("disputeResolutionLink")]
            public Uri DisputeResolutionLink { get; set; }

            [JsonProperty("textual_representation")]
            public string[] TextualRepresentation { get; set; }
        }

        public partial class ChamberOfCommerce
        {
            [JsonProperty("issuer")]
            public string Issuer { get; set; }

            [JsonProperty("number")]
            public string Number { get; set; }
        }

        public partial class Deliverys
        {
            [JsonProperty("times")]
            public Dictionary<string, Time[]> Times { get; set; }

            [JsonProperty("isOpenForOrder")]
            public bool IsOpenForOrder { get; set; }

            [JsonProperty("isOpenForPreorder")]
            public bool IsOpenForPreorder { get; set; }

            [JsonProperty("isScooberRestaurant")]
            public bool IsScooberRestaurant { get; set; }

            [JsonProperty("durationRange")]
            public DurationRange DurationRange { get; set; }
        }

        public partial class DurationRange
        {
            [JsonProperty("min")]
            public long Min { get; set; }

            [JsonProperty("max")]
            public long Max { get; set; }
        }

        public partial class Time
        {
            [JsonProperty("start")]
            public long Start { get; set; }

            [JsonProperty("end")]
            public long End { get; set; }

            [JsonProperty("formattedStart")]
            public string FormattedStart { get; set; }

            [JsonProperty("formattedEnd")]
            public string FormattedEnd { get; set; }
        }

        public partial class Locations
        {
            [JsonProperty("streetName")]
            public string StreetName { get; set; }

            [JsonProperty("streetNumber")]
            public string StreetNumber { get; set; }

            [JsonProperty("postalCode")]
            public string PostalCode { get; set; }

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

        public partial class Menus
        {
            [JsonProperty("currency")]
            public Currency Currency { get; set; }

            [JsonProperty("categories")]
            public Category[] Categories { get; set; }

            [JsonProperty("optionGroups")]
            public Dictionary<string, OptionGroup> OptionGroups { get; set; }

            [JsonProperty("options")]
            public Dictionary<string, Option> Options { get; set; }

            [JsonProperty("products")]
            public Dictionary<string, Products> Products { get; set; }

            [JsonProperty("popularProductIds")]
            public string[] PopularProductIds { get; set; }

            [JsonProperty("discounts")]
            public object[] Discounts { get; set; }

            [JsonProperty("autoAddedProducts")]
            public AutoAddedProducts AutoAddedProducts { get; set; }
        }

        public partial class AutoAddedProducts
        {
        }

        public partial class Category
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string[] Description { get; set; }

            [JsonProperty("imageUrl")]
            public Uri ImageUrl { get; set; }

            [JsonProperty("timeRestrictions")]
            public AutoAddedProducts TimeRestrictions { get; set; }

            [JsonProperty("productIds")]
            public string[] ProductIds { get; set; }
        }

        public partial class Currency
        {
            [JsonProperty("denominator")]
            public long Denominator { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }
        }

        public partial class OptionGroup
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("isTypeMulti")]
            public bool IsTypeMulti { get; set; }

            [JsonProperty("isRequired")]
            public bool IsRequired { get; set; }

            [JsonProperty("minChoices")]
            public long MinChoices { get; set; }

            [JsonProperty("maxChoices")]
            public long MaxChoices { get; set; }

            [JsonProperty("optionIds")]
            public string[] OptionIds { get; set; }
        }

        public partial class Option
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("minAmount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinAmount { get; set; }

            [JsonProperty("maxAmount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxAmount { get; set; }

            [JsonProperty("prices")]
            public Prices Prices { get; set; }

            [JsonProperty("metric")]
            public Metric Metric { get; set; }

            [JsonProperty("priceUnit")]
            public object PriceUnit { get; set; }

            [JsonProperty("pricePerUnitPickup")]
            public object PricePerUnitPickup { get; set; }

            [JsonProperty("pricePerUnitDelivery")]
            public object PricePerUnitDelivery { get; set; }

            [JsonProperty("alcoholVolume")]
            public object AlcoholVolume { get; set; }

            [JsonProperty("caffeineAmount")]
            public object CaffeineAmount { get; set; }

            [JsonProperty("isSoldOut")]
            public bool IsSoldOut { get; set; }

            [JsonProperty("isExcludedFromMov")]
            public bool IsExcludedFromMov { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("optionGroupIds", NullValueHandling = NullValueHandling.Ignore)]
            public string[] OptionGroupIds { get; set; }

            [JsonProperty("shippingTypes", NullValueHandling = NullValueHandling.Ignore)]
            public ShippingType[] ShippingTypes { get; set; }
        }

        public partial class Metric
        {
            [JsonProperty("unit")]
            public string? Unit { get; set; }

            [JsonProperty("quantity")]
            public long? Quantity { get; set; }
        }

        public partial class Prices
        {
            [JsonProperty("delivery")]
            public long Delivery { get; set; }

            [JsonProperty("pickup")]
            public long Pickup { get; set; }

            [JsonProperty("deposit")]
            public long? Deposit { get; set; }
        }

        public partial class Products
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string[] Description { get; set; }

            [JsonProperty("imageUrl")]
            public object ImageUrl { get; set; }

            [JsonProperty("variants")]
            public Option[] Variants { get; set; }
        }

        public partial class The30_Rn7P7N51
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description")]
            public string[] Description { get; set; }

            [JsonProperty("imageUrl")]
            public Uri ImageUrl { get; set; }

            [JsonProperty("variants")]
            public Variant[] Variants { get; set; }
        }

        public partial class Variant
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public object Name { get; set; }

            [JsonProperty("optionGroupIds")]
            public object[] OptionGroupIds { get; set; }

            [JsonProperty("shippingTypes")]
            public ShippingType[] ShippingTypes { get; set; }

            [JsonProperty("prices")]
            public Prices Prices { get; set; }

            [JsonProperty("metric")]
            public Metric Metric { get; set; }

            [JsonProperty("priceUnit")]
            public string PriceUnit { get; set; }

            [JsonProperty("pricePerUnitPickup")]
            public long PricePerUnitPickup { get; set; }

            [JsonProperty("pricePerUnitDelivery")]
            public long PricePerUnitDelivery { get; set; }

            [JsonProperty("alcoholVolume")]
            public object AlcoholVolume { get; set; }

            [JsonProperty("caffeineAmount")]
            public string CaffeineAmount { get; set; }

            [JsonProperty("isSoldOut")]
            public bool IsSoldOut { get; set; }

            [JsonProperty("isExcludedFromMov")]
            public bool IsExcludedFromMov { get; set; }
        }

        public partial class Payments
        {
            [JsonProperty("methods")]
            public string[] Methods { get; set; }

            [JsonProperty("fees")]
            public AutoAddedProducts Fees { get; set; }

            [JsonProperty("messages")]
            public Messages Messages { get; set; }

            [JsonProperty("issuers")]
            public AutoAddedProducts Issuers { get; set; }
        }

        public partial class Messages
        {
            [JsonProperty("onlinePayment")]
            public string[] OnlinePayment { get; set; }

            [JsonProperty("offlinePayment")]
            public string[] OfflinePayment { get; set; }
        }

        public partial class Pickups
        {
            [JsonProperty("times")]
            public Dictionary<string, Time[]> Times { get; set; }

            [JsonProperty("isOpenForOrder")]
            public bool IsOpenForOrder { get; set; }

            [JsonProperty("isOpenForPreorder")]
            public bool IsOpenForPreorder { get; set; }
        }

        public partial class Ratings
        {
            [JsonProperty("votes")]
            public long Votes { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public partial class Summarys
        {
            [JsonProperty("title")]
            public object Title { get; set; }

            [JsonProperty("content")]
            public object Content { get; set; }
        }

        public partial class Supports
        {
            [JsonProperty("delivery")]
            public bool Delivery { get; set; }

            [JsonProperty("pickup")]
            public bool Pickup { get; set; }

            [JsonProperty("stampCards")]
            public bool StampCards { get; set; }

            [JsonProperty("vouchers")]
            public bool Vouchers { get; set; }

            [JsonProperty("productRemarks")]
            public bool ProductRemarks { get; set; }

            [JsonProperty("onlinePayments")]
            public bool OnlinePayments { get; set; }

            [JsonProperty("tipping")]
            public bool Tipping { get; set; }
        }

        public enum Unit { Ml };

        public enum ShippingType { Delivery, Pickup };

        public enum PriceUnit { Liter };


        [JsonProperty("brand")]
        public Brands Brand { get; set; }

        [JsonProperty("rating")]
        public Ratings Rating { get; set; }

        [JsonProperty("location")]
        public Locations Location { get; set; }

        [JsonProperty("restaurantId")]
        public string RestaurantId { get; set; }

        [JsonProperty("colophon")]
        public Colophons Colophon { get; set; }

        [JsonProperty("summary")]
        public Summarys Summary { get; set; }

        [JsonProperty("delivery")]
        public Deliverys Delivery { get; set; }

        [JsonProperty("exceptionalStatus")]
        public object ExceptionalStatus { get; set; }

        [JsonProperty("menu")]
        public Menus Menu { get; set; }

        [JsonProperty("pickup")]
        public Pickups Pickup { get; set; }

        [JsonProperty("supports")]
        public Supports Support { get; set; }

        [JsonProperty("primarySlug")]
        public string PrimarySlug { get; set; }

        [JsonProperty("minisiteUrl")]
        public object MinisiteUrl { get; set; }

        [JsonProperty("restaurantHygieneRatingId")]
        public object RestaurantHygieneRatingId { get; set; }

        [JsonProperty("restaurantPhoneNumber")]
        public string RestaurantPhoneNumber { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isTestRestaurant")]
        public bool IsTestRestaurant { get; set; }

        [JsonProperty("payment")]
        public Payments Payment { get; set; }
    }
}
