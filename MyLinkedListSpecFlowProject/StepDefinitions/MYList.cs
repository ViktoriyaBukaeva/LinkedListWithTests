using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace MyLinkedListSpecFlowProject.StepDefinitions
{
    [Binding]
    public class MYList
    {
        [Given(@"Create list:")]
        public void GivenCreateList(Table table)
        {
            List<int> list = new List<int>();
            foreach (string q in table.Header)
            {
                foreach (var a in table.Rows)
                {
                    list.Add(Convert.ToInt32(a[q]));
                }
            }
            ScenarioContext.Current["BaseList"] = list;
        }

        [Given(@"Create empty list")]
        public void GivenCreateEmptyList()
        {
            ScenarioContext.Current["BaseList"] = new List<int>(); //здесь пустой лист, поэтому конвертация не нужна
        }

        [When(@"Add (.*) to list")]
        public void WhenAddToList(int number)
        {
            List<int> list = (List<int>)ScenarioContext.Current["BaseList"];
            list.Add(number);
        }        

        [Then(@"List mast be:")]
        public void ThenListMastBe(Table table)
        {
            List<int> expected = table.Rows[0]["Numbers"]
                .Split(',')
                .Select(str => Convert.ToInt32(str))
                .ToList();

            List<int> actual = (List<int>)ScenarioContext.Current["BaseList"];

            Assert.AreEqual(expected, actual);
        }        
    }
}
