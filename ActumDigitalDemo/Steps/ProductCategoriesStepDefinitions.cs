using System;
using TechTalk.SpecFlow;

namespace ActumDigitalDemo.Steps
{
    [Binding]
    public class ProductCategoriesStepDefinitions
    {
        [Given(@"user is on shop homepage")]
        public void GivenUserIsOnShopHomepage()
        {
            throw new PendingStepException();
        }

        [When(@"user navigates to '([^']*)' category")]
        public void WhenUserNavigatesToCategory(string phones)
        {
            throw new PendingStepException();
        }

        [Then(@"user can see '([^']*)'")]
        public void ThenUserCanSee(string phones)
        {
            throw new PendingStepException();
        }

        [Then(@"user can see images")]
        public void ThenUserCanSeeImages()
        {
            throw new PendingStepException();
        }
    }
}
