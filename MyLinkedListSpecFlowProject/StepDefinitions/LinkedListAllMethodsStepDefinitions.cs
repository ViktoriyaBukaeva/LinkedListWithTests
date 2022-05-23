using LinkdList;
using System;
using TechTalk.SpecFlow;

namespace MyLinkedListSpecFlowProject.StepDefinitions
{
    [Binding]
    public class LinkedListAllMethodsStepDefinitions
    {
        [Given(@"Create Linkedlist:")]
        public void GivenCreateLinkedlist(Table table)
        {
            LnkdList<int> list = new LnkdList<int>();
            foreach (string q in table.Header)
            {
                foreach (var a in table.Rows)
                {
                    list.Add(Convert.ToInt32(a[q]));
                }
            }
            ScenarioContext.Current["BaseList"] = list;
        }

        [Given(@"Create empty Linkedlist")]
        public void GivenCreateLinkedlist()
        {
            ScenarioContext.Current["BaseList"] = new LnkdList<int>();
        }

        [When(@"Add (.*) to Linkedlist")]
        public void WhenAddToLinkedlist(int number)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.Add(number);
        }

        [When(@"Add element (.*) to the beginning")]
        public void WhenAddElementToTheBeginning(int number)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.AddFirst(number);
        }

        [When(@"Adding element by index (.*) value (.*)")]
        public void WhenAddingElementByIndexValue(int index, int value)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.AddByIndex(index, value);
        }

        [When(@"Remove first element from the Linkedlist")]
        public void WhenRemoveFirstElementFromTheLinkedlist()
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.RemoveFirst();
        }

        [When(@"Remove last element from the Linkedlist")]
        public void WhenRemoveLastElementFromTheLinkedlist()
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.RemoveLast();
        }

        [When(@"Remove element by index (.*) from the Linkedlist")]
        public void WhenRemoveElementByIndexFromTheLinkedlist(int index)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.RemoveByIndex(index);
        }

        [When(@"Remove (.*) elements from the end Linkedlist")]
        public void WhenRemoveElementsFromTheEndLinkedlist(int elements)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.RemoveEndNElem(elements);
        }

        [When(@"Remove (.*) element from the start Linkedlist")]
        public void WhenRemoveElementFromTheStartLinkedlist(int element)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.RemoveStart_N_Elem(element);
        }

        [When(@"Remove (.*) elements ByIndex (.*) from the Linkedlist")]
        public void WhenRemoveElementsByIndexFromTheLinkedlist(int elements, int index)
        {
            LnkdList<int> list = (LnkdList<int>)ScenarioContext.Current["BaseList"];
            list.Remove_N_ElemByIndex(index, elements);
        }

        [Then(@"Linkedlist must be (.*), (.*)")]
        public void ThenLinkedlistMustBe(int a, int b)
        {
            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(a);
            expected.Add(b);

            LnkdList<int> actual = (LnkdList<int>)ScenarioContext.Current["BaseList"];

            Assert.AreEqual(expected, actual);
        }

        [Then(@"Linkedlist must be:")]
        public void ThenLinkedlistMastBe(Table table)
        {
            List<int> expected = table.Rows[0]["Numbers"]
              .Split(',')
              .Select(str => Convert.ToInt32(str))
              .ToList();

            LnkdList<int> actual = (LnkdList<int>)ScenarioContext.Current["BaseList"];

            Assert.AreEqual(expected, actual);
        }

        [Then(@"Linkedlist must be null")]
        public void ThenLinkedlistMustBeNull()
        {
            LnkdList<int> expected = new LnkdList<int>();

            LnkdList<int> actual = (LnkdList<int>)ScenarioContext.Current["BaseList"];

            Assert.AreEqual(expected, actual);
        }
    }
}
