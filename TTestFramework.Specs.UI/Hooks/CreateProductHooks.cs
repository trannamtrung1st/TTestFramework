using Microsoft.Extensions.Configuration;
using TTestFramework.Specs.UI.Drivers;
using TTestFramework.Specs.UI.Objects;

namespace TTestFramework.Specs.UI.Hooks
{
    [Binding]
    public class CreateProductHooks
    {
        [BeforeScenario("CreateProduct")]
        public static void BeforeScenario(BrowserDriver browserDriver, IConfiguration configuration)
        {
            var pageObject = new CreateProductPageObject(browserDriver.Current, configuration);

            pageObject.EnsurePageOpenAndFresh();
        }
    }
}
