using Lieferando.Utilities;
using Lieferando.Clients;
using Lieferando.Clients.Requests;
using Lieferando.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lieferando.Services
{
    public sealed class OrderService : IHostedService
    {
        private readonly Logger _logger;
        private readonly Hash _hash;
        private readonly IConfiguration _config;
        private readonly TakeawayHttpApiClient _takeawayHttpApiClient;
        private readonly TakeawayRequestManager _takeawayRequestManager;

        private int CURRENT_LOOPS = 0;
        private const int MAX_LOOPS = 15;

        public OrderService(IServiceProvider services, Logger logger, Hash hash,
                            TakeawayHttpApiClient takeawayHttpApiClient, TakeawayRequestManager takeawayRequestManager)
        {
            _logger = logger;
            _hash = hash;
            _takeawayHttpApiClient = takeawayHttpApiClient;
            _takeawayRequestManager = takeawayRequestManager;
            _config = services.GetRequiredService<IConfiguration>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Console("Order", $"Run order service...");

            _logger.Console("Order", $"Enter address: ");
            var targetAddress = Console.ReadLine();

            _logger.Console("Order", $"Enter name: ");
            var targetName = Console.ReadLine();

            try
            {
                TakeawayGecoderResponse takeawayGeocoderResponse = await _takeawayRequestManager.Get<TakeawayGeocoderRequest>().Request(targetAddress);
                if (takeawayGeocoderResponse.Addresses.Count > 1)
                {
                    _logger.Console("Order", "Please specify the address as accurately as possible.");
                    return;
                }

                TakeawayGecoderResponse.Address takeawayGeocoderAddress = takeawayGeocoderResponse.Addresses.First();
                if (takeawayGeocoderAddress == null) return;

                TakeawayRestaurantsResponse takeawayRestaurantsResponse = await _takeawayRequestManager.Get<TakeawayRestaurantsRequest>().Request(takeawayGeocoderAddress.DeliveryAreaId, takeawayGeocoderAddress.TakeawayPostalCode, takeawayGeocoderAddress.Lat, takeawayGeocoderAddress.Lng, "0", "true");
                if (takeawayRestaurantsResponse.Restaurants.Count < 1)
                {
                    _logger.Console("Order", "Sorry, but in this city are no restaurants available.");
                    return;
                }

                foreach (var takeawayRestaurant in takeawayRestaurantsResponse.Restaurants.Values.Where(restaurant => restaurant.ShippingInfo.Delivery.IsOpenForOrder))
                {
                    if (CURRENT_LOOPS <= MAX_LOOPS) CURRENT_LOOPS++;
                    //else return;

                        if (takeawayRestaurant == null)
                        {
                            _logger.Console("Order", "Sorry, but in this city are no restaurants opened.");
                            return;
                        }

                        TakeawaySlugResponse takeawaySlugResponse = await _takeawayRequestManager.Get<TakeawaySlugRequest>().Request(takeawayRestaurant.PrimarySlug);
                        if (takeawaySlugResponse == null)
                        {
                            _logger.Console("Order", "Sorry, but error.");
                            return;
                        }

                        _logger.Console("Order", $"Target Restaurant: {takeawaySlugResponse.Brand.Name}, {takeawayRestaurant.Location.City}, {takeawayRestaurant.Location.Country}");

                        var targetProductToOrder = takeawaySlugResponse.Menu.Products.Values.FirstOrDefault(product => product.Name.Contains("Salat"));
                        if (targetProductToOrder == null)
                        {
                            _logger.Console("Order", "Sorry, this restaurant does not have Salad.");

                            targetProductToOrder = takeawaySlugResponse.Menu.Products.Values.FirstOrDefault(product => product.Name.Contains("Cola"));
                            if (targetProductToOrder == null)
                            {
                                _logger.Console("Order", "Sorry, this restaurant does not have Cola.");
                                return;
                            }
                        }

                        TakeawayOrderData takeawayOrderRequest = new TakeawayOrderData
                        {
                            Address = new TakeawayOrderData.OrderAddress(takeawayGeocoderAddress.City, "", takeawayGeocoderAddress.Lat, takeawayGeocoderAddress.Lng, takeawayGeocoderAddress.TakeawayPostalCode, takeawayGeocoderAddress.Street, takeawayGeocoderAddress.StreetNumber),
                            CartItems = new TakeawayOrderData.CartItem[] { new TakeawayOrderData.CartItem("", targetProductToOrder.Variants.First().Id, new object[] { }, 10) },
                            CookieConsents = new TakeawayOrderData.CookieConsent[] { new TakeawayOrderData.CookieConsent() },
                            DeliveryAreaId = takeawayGeocoderAddress.DeliveryAreaId,
                            DeliveryMethod = Enum.GetName(typeof(TakeawaySlugResponse.ShippingType), TakeawaySlugResponse.ShippingType.Delivery).ToUpper(),
                            DeliveryTime = "",
                            Email = $"{Guid.NewGuid().ToString("n").Substring(0, 8)}@gmx.de",
                            ExactAmount = 5000,
                            Name = targetName,
                            Newsletter = false,
                            PaymentInformation = "",
                            PaymentMethod = Enum.GetName(typeof(TakeawayRestaurantsResponse.PaymentMethod), TakeawayRestaurantsResponse.PaymentMethod.Cash).ToLower(),
                            Phone = new Random().Next(01765958755, 01767958755).ToString(),
                            PlaceId = takeawayGeocoderAddress.PlaceId,
                            RecurringPayment = "NOT_USE",
                            Remarks = ".",
                            RestaurantId = takeawayRestaurant.Id,
                            Restrictions = new object[] { },
                            ReturnUrl = $"payment-status/{takeawayRestaurant.PrimarySlug}/{takeawayRestaurant.Id}",
                            TakeawayPay = new object { },
                            VoucherCode = ""
                        };

                        string takeawayOrderResponseString = await _takeawayRequestManager.Get<TakeawayOrderRequest>().Request(takeawayOrderRequest);

                        try
                        {
                            TakeawayOrderResponse takeawayOrderResponse = JsonConvert.DeserializeObject<TakeawayOrderResponse>(takeawayOrderResponseString);
                            if (takeawayOrderResponse == null)
                            {
                                _logger.Console("Order", "Ordner couldnt be completed.");
                                return;
                            }

                            _logger.Console("Order", $"Placed order: {takeawayOrderResponse.FoodTracking.AbsoluteUri}");
                        }
                        catch 
                        {
                            _logger.Console("Order", "Ordner couldnt be completed.");
                        }
                }
            }
            catch (Exception ex)
            {
                _logger.Console("Order", ex.ToString());
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Console("Order", "Stop order service...");

            return Task.CompletedTask;
        }
    }
}
