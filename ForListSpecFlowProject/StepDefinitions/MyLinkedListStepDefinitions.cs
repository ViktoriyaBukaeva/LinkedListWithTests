using System;
using TechTalk.SpecFlow;

namespace ForListSpecFlowProject.StepDefinitions
{
    [Binding]
    public class MyLinkedListStepDefinitions
    {
        [Given(@"Create List:")]
        public void GivenCreateList(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"add (.*) to list")]
        public void WhenAddToList(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"List must be")]
        public void ThenListMustBe(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"Create empty list")]
        public void GivenCreateEmptyList()
        {
            throw new PendingStepException();
        }
    }
}
