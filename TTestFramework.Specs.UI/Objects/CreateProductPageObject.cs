using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TTestFramework.Specs.UI.Utils;

namespace TTestFramework.Specs.UI.Objects
{
    public class CreateProductPageObject
    {
        private readonly Uri _baseUrl;
        private readonly Uri _url;
        private readonly IWebDriver _webDriver;

        public CreateProductPageObject(
            IWebDriver webDriver,
            IConfiguration configuration)
        {
            _webDriver = webDriver;
            _baseUrl = new Uri(configuration["WebClientUrl"]);
            _url = new Uri(_baseUrl, "/products/create");
        }

        private IWebElement FormElement => _webDriver.FindElement(By.Id("form-create-product"));
        private IWebElement NameInput => FormElement.FindElement(By.ClassName("input-name"));
        private IWebElement PriceInput => FormElement.FindElement(By.CssSelector(".input-price input"));
        private IWebElement BtnSubmit => FormElement.FindElement(By.ClassName("btn-submit"));
        private IWebElement SuccessModal => _webDriver.FindElement(By.ClassName("ant-message-success"));

        public void EnterName(string name)
        {
            NameInput.Clear();
            NameInput.SendKeys(name);
        }

        public void EnterPrice(decimal number)
        {
            PriceInput.Clear();
            PriceInput.SendKeys(number.ToString());
        }

        public void ClickSubmit()
        {
            BtnSubmit.Click();
        }

        public void EnsurePageOpenAndFresh()
        {
            if (_webDriver.Url != _url.AbsoluteUri)
            {
                _webDriver.Url = _url.AbsoluteUri;
            }
            else
            {
                _webDriver.Navigate().Refresh();
            }
        }

        public bool IsBtnSubmitEnabled() => BtnSubmit.Enabled;

        public bool FormHasErrorMessage(string message)
        {
            var errorElements = FormElement.FindElements(By.ClassName("ant-form-item-explain-error"));

            var hasExpectedError = errorElements.Any(e => e.Text?.Trim() == message);

            return hasExpectedError;
        }

        public bool HasSuccessMessage(string message)
        {
            var successModal = WebDriverHelper.WaitUntil(_webDriver, () => SuccessModal, result => result != null);

            return successModal.Text?.Trim() == message;
        }

        public IWebElement WaitForFormVisible()
        {
            return WebDriverHelper.WaitUntil(_webDriver,
                () => NameInput, (e) => e?.Displayed == true);
        }
    }
}
