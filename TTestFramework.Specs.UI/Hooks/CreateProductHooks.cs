using Microsoft.Extensions.Configuration;
using TTestFramework.Specs.UI.Drivers;
using TTestFramework.Specs.UI.Objects;

namespace TTestFramework.Specs.UI.Hooks
{
    [Binding]
    public class CreateProductHooks
    {
        public const string Tag = "CreateProduct";

        [BeforeScenario(Tag)]
        public static void BeforeScenario(BrowserDriver browserDriver, IConfiguration configuration)
        {
            var pageObject = new CreateProductPageObject(browserDriver.Current, configuration);

            pageObject.EnsurePageOpenAndFresh();

            pageObject.WaitForFormVisible();
        }

        [AfterFeature(Tag)]
        public static void AfterFeature(BrowserDriver browserDriver)
        {
            browserDriver.Dispose();
        }
    }
}
