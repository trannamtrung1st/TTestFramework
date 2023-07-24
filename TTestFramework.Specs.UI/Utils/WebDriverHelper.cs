using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TTestFramework.Specs.UI.Utils
{
    public static class WebDriverHelper
    {
        public static T WaitUntil<T>(IWebDriver webDriver,
            Func<T> getResult,
            Func<T, bool> isResultAccepted,
            int waitInSeconds = 5) where T : class
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
    }
}
