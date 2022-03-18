using Lieferando.Services;
using Lieferando.Utilities;
using Lieferando.Clients;
using Lieferando.Extensions;
using Lieferando.Managers;
using Lieferando.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Lieferando
{
    public sealed class Startup
    {
        private readonly IConfiguration _config;
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        public void InitializeServices(IServiceCollection services)
        {
            services.AddSingleton<Logger>();
            services.AddSingleton<Hash>();

            services.AddSingleton<TakeawayRequestManager>();
            services.AddSingleton<TakeawayHttpApiClientHandler>();

            services.BindAllClassesFrom<TakeawayRequest>(ServiceCollectionExtensions.ServiceType.REQUEST);

            services.AddSingleton(_config);

            services.AddHttpClient<TakeawayHttpApiClient>(client =>
            {
                client.BaseAddress = new Uri(_config["URL"]);
                client.DefaultRequestHeaders.Add("User-Agent", $"{_config["AppName"]}/{_config["AppVersion"]}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var clientHeaders in _config.GetSection("ClientHeaders").GetChildren())
                    client.DefaultRequestHeaders.Add(clientHeaders.Key, clientHeaders.Value);
            }).ConfigurePrimaryHttpMessageHandler<TakeawayHttpApiClientHandler>();

            services.AddHostedService<OrderService>();
        }
    }
}
