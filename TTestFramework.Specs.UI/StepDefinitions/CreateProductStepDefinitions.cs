using FluentAssertions;
using Microsoft.Extensions.Configuration;
using TTestFramework.Specs.UI.Drivers;
using TTestFramework.Specs.UI.Objects;

namespace TTestFramework.Specs.UI.StepDefinitions
{
    [Binding]
    public class CreateProductStepDefinitions
    {
        private readonly CreateProductPageObject _createProductPageObject;

        public CreateProductStepDefinitions(
            BrowserDriver browserDriver,
            IConfiguration configuration)
        {
            _createProductPageObject = new CreateProductPageObject(browserDriver.Current, configuration);
        }

        [Given(@"the name is empty string")]
        public void GivenTheNameIsEmptyString()
        {
            _createProductPageObject.EnterName(string.Empty);
        }

        [Given(@"the unit price is (.*)")]
        public void GivenTheUnitPriceIs(decimal unitPrice)
        {
            _createProductPageObject.EnterPrice(unitPrice);
        }

        [When(@"user clicks on submit")]
        public void WhenUserClicksOnSubmit()
        {
            _createProductPageObject.ClickSubmit();
        }

        [Then(@"the button should be disabled")]
        public void ThenTheButtonShouldBeDisabled()
        {
            var enabled = _createProductPageObject.IsBtnSubmitEnabled();

            enabled.Should().BeFalse();
        }

        [Then(@"an error message displays with content ""([^""]*)""")]
        public void ThenAnErrorMessageDisplaysWithContent(string message)
        {
            var hasError = _createProductPageObject.FormHasErrorMessage(message);

            hasError.Should().BeTrue();
        }

        [Given(@"the name is ""([^""]*)""")]
        public void GivenTheNameIs(string name)
        {
            _createProductPageObject.EnterName(name);
        }

        [Then(@"the a success message displays with content ""([^""]*)""")]
        public void ThenTheASuccessMessageDisplaysWithContent(string message)
        {
            var hasMessage = _createProductPageObject.HasSuccessMessage(message);

            hasMessage.Should().BeTrue();
        }
    }
}
