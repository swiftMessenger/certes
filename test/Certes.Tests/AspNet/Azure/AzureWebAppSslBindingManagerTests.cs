﻿using Certes.AspNet.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Certes.AspNet.Azure
{
    public class AzureWebAppSslBindingManagerTests
    {
        [Fact]
        public async Task CanGetHostNames()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("certes-dev")
                .AddEnvironmentVariables()
                .Build();
            
            var services = new ServiceCollection();
            services.AddOptions();
            services.Configure<ServicePrincipalOptions>(config.GetSection("certes:azure:servicePrincipal"));
            services.Configure<WebAppOptions>(config.GetSection("certes:azure:webApp"));

            services.AddTransient<IClientCredentialProvider, ServicePrincipalCredentialProvider>();
            services.AddTransient<ISslBindingManager, WebAppSslBindingManager>();

            var serviceProvider = services.BuildServiceProvider();
            
            var mgr = serviceProvider.GetRequiredService<ISslBindingManager>();
            Assert.IsType<WebAppSslBindingManager>(mgr);
            await mgr.GetHostNames();
        }
    }
}