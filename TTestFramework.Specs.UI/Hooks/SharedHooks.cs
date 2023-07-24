using BoDi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TTestFramework.Specs.UI.Drivers;

namespace TTestFramework.Specs.UI.Hooks
{
    [Binding]
    public class SharedHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            testThreadContainer.BaseContainer.Resolve<BrowserDriver>();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true)
                .AddJsonFile("appsettings.Production.json", true)
                .Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            testThreadContainer.BaseContainer.RegisterInstanceAs(configuration);

            testThreadContainer.BaseContainer.RegisterInstanceAs<IServiceProvider>(serviceProvider);
        }
    }
}
