namespace TTestFramework.Specs.UI.StepDefinitions
{
    [Binding]
    public class CreateProductStepDefinitions
    {
        [Given(@"the name is empty string")]
        public void GivenTheNameIsEmptyString()
        {
            throw new PendingStepException();
        }

        [Given(@"the unit price is (.*)")]
        public void GivenTheUnitPriceIs(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"user clicks on submit")]
        public void WhenUserClicksOnSubmit()
        {
            throw new PendingStepException();
        }

        [Then(@"the button should be disabled")]
        public void ThenTheButtonShouldBeDisabled()
        {
            throw new PendingStepException();
        }

        [Then(@"an error message displays with content ""([^""]*)""")]
        public void ThenAnErrorMessageDisplaysWithContent(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"the name is ""([^""]*)""")]
        public void GivenTheNameIs(string television)
        {
            throw new PendingStepException();
        }

        [Then(@"the a success message displays with content ""([^""]*)""")]
        public void ThenTheASuccessMessageDisplaysWithContent(string p0)
        {
            throw new PendingStepException();
        }
    }
}
