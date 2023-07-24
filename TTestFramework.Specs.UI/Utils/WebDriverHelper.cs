using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TTestFramework.Specs.UI.Utils
{
    public static class WebDriverHelper
    {
        public static T WaitUntil<T>(IWebDriver webDriver,
            Func<T> getResult,
            Func<T, bool> isResultAccepted = null,
            int waitInSeconds = 5,
            bool ignoreNoSuchElement = true) where T : class
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitInSeconds));
            isResultAccepted ??= (e) => e != default;

            if (ignoreNoSuchElement)
            {
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            }

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
