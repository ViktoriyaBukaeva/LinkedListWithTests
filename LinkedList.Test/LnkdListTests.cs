using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkdList.Test
{
    public class LnkdListTests
    {

        [TestCase(1, 2, 3, "1 2 3 ")]
        [TestCase(0, 2, -5, "0 2 -5 ")]
        public void AddTest(int valueA, int valueB, int valueC, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);

            string actual = list.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("a", "b", "c", new string[]{ "a", "b", "c" })]        
        public void AddStringTest(string valueA, string valueB, string valueC, string[] expected)
        {
            LnkdList<string> list = new LnkdList<string>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC); 
            
            int counter = 0;
            foreach (string actual in list)
            {
                Assert.AreEqual(expected[counter], actual);
                counter++;
            }          
        }

        [TestCase(1, 2, 3, new int[] { 3, 2, 1 })]
        public void AddFirstTest(int valueA, int valueB, int valueC, int[] expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.AddFirst(valueA);
            list.AddFirst(valueB);
            list.AddFirst(valueC);

            int counter = 0;
            foreach (int actual in list)
            {
                Assert.AreEqual(expected[counter], actual);
                counter++;
            }
        }
        [TestCase("a", "b", "c", new string[] { "c", "b", "a" })]
        public void AddFirstStringTest(string valueA, string valueB, string valueC, 
            string[] expected)
        {
            LnkdList<string> list = new LnkdList<string>();
            list.AddFirst(valueA);
            list.AddFirst(valueB);
            list.AddFirst(valueC);

            int counter = 0;
            foreach (string actual in list)
            {
                Assert.AreEqual(expected[counter], actual);
                counter++;
            }
        }

        [TestCase(1, 2, 4, 2, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, 2, 4, 0, 1, new int[] { 1, 3, 2, 4 })]
        [TestCase(0, 2, 3, 0, 1, new int[] { 1, 0, 2, 3 })]
        public void AddByIndexTest( int valueA, int valueB, int valueC,
            int index, int value, int[] expected)
        {           
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);

            list.AddByIndex(index, value);
            
            int counter = 0;
            foreach (int actual in list)
            {
                Assert.AreEqual(expected[counter], actual);
                counter++;
            }
        }

        [TestCase(0, 1, new int[] { 1 })]
        public void AddByIndexTestEmptyList(int index, int value, int[] expected)
        {
            LnkdList<int> list = new LnkdList<int>();

            list.AddByIndex(index, value);

            int counter = 0;
            foreach (int actual in list)
            {
                Assert.AreEqual(expected[counter], actual);
                counter++;
            }
        }

        [TestCase(-1, 2)]
        [TestCase(5, 3)]
        public void AddByIndexNegativeTest(int index, int value)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.AddByIndex(index, value));
        }

        [TestCaseSource(typeof(RemoveFirstElement))]
        public void RemoveFirstTest(LnkdList<int> list, LnkdList <int> expected)
        {
            list.RemoveFirst();
            Assert.AreEqual(list, expected);
        }

        [TestCaseSource(typeof(RemoveLastElement))]
        public void RemoveLastTest(LnkdList<int> list, LnkdList<int> expected)
        {         
            list.RemoveLast();
            Assert.AreEqual(list, expected);
        }        

        [TestCase(1, 2, 3, 4, 5, 0, "2 3 4 5 ")]
        public void RemoveByIndexTest(int valueA, int valueB, int valueC, int valueD, int valueE, 
            int index, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);
            list.Add(valueD);
            list.Add(valueE);

            list.RemoveByIndex(index);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 0, "")]
        public void RemoveByIndexTest2(int valueA, 
         int index, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);

            list.RemoveByIndex(index);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 1, "1 3 ")]
        public void RemoveByIndexTest(int valueA, int valueB, int valueC,
           int index, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);

            list.RemoveByIndex(index);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(5)]
        public void RemoveByIndexNegativeTest(int index)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveByIndex(index));
        }

        [TestCase(1, 2, 3, 1, "1 2 ")]
        public void RemoveEndNElemTest2(int valueA, int valueB, int valueC,
            int elements, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);

            list.RemoveEndNElem(elements);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 4, 5, 2, "1 2 3 ")]
        [TestCase(1, 2, 3, 4, 5, 5, "")]
        
        public void RemoveEndNElemTest(int valueA, int valueB, int valueC, int valueD, int valueE,
            int elements, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);
            list.Add(valueD);
            list.Add(valueE);

            list.RemoveEndNElem(elements);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6)]        
        public void RemoveEndNElemNegativeTest(int elements)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveEndNElem(elements));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void RemoveEndNElemNegativeTest_Where_The_Number_is_less_than0 (int elements)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<ArgumentException>(() => list.RemoveEndNElem(elements));
        }              

        [TestCase(1, 2, 3, 4, 5, 2, "3 4 5 ")]
        public void RemoveStart_N_ElemTest(int valueA, int valueB, int valueC, int valueD, int valueE,
            int elements, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);
            list.Add(valueD);
            list.Add(valueE);

            list.RemoveStart_N_Elem(elements);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(0)]
        [TestCase(-1)]
        public void RemoveStart_0_ElemNegativeTest(int elements)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<ArgumentException>(() => list.RemoveStart_N_Elem(elements));
        }

        [TestCase(1, 2, 3, 4, 5, 6, 7, 1, 3, "1 5 6 7 ")]      
        public void Remove_N_ElemByIndexTest(int valueA, int valueB, int valueC, int valueD, int valueE,
           int valueF, int valueG, int index, int elements, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);
            list.Add(valueD);
            list.Add(valueE);
            list.Add(valueF);
            list.Add(valueG);

            list.Remove_N_ElemByIndex(index, elements);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 4, 0, 2, "3 4 ")]
        [TestCase(1, 2, 3, 4, 2, 2, "1 2 ")]
        public void Remove_N_ElemByIndexTest2(int valueA, int valueB, int valueC, int valueD, 
          int index, int elements, string expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);
            list.Add(valueD);

            list.Remove_N_ElemByIndex(index, elements);

            string actual = list.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 2)]
        [TestCase(7, 3)]
        public void Remove_N_ElemBy_Bad_IndexNegativeTest(int index, int elements)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.Remove_N_ElemByIndex(index, elements));
        }

        [TestCase(3,10)]
        [TestCase(3, 3)]
        [TestCase(0, -2)]
        public void Remove_More_ElemByIndexNegativeTest(int index, int elements)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<ArgumentException>(() => list.Remove_N_ElemByIndex(index, elements));
        }        

        [TestCase(1, 2, 3, 0, 1)]
        [TestCase(1, 2, 3, 1, 2)]
        [TestCase(1, 2, 3, 2, 3)]
        public void IndexatorTest(int valueA, int valueB, int valueC, int index, int expected)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);

            int actual = list[index];
            Assert.AreEqual(expected, actual);
        }       

        [TestCaseSource(typeof(SetIndexator))]
        public void SetIndexatorTest(int index, int value, LnkdList<int> actual, LnkdList<int> expected)
        {
            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(9)]
        public void SetIndexatorTest_WhenIndexHigherThanListLengthOrLowerThanZero_ShouldIndexOutOfrangeException(int index)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Assert.Throws<IndexOutOfRangeException>(() => list[index] = -5);//тут пишем код,котоорый передаем в метод как параметр
        }

        [TestCaseSource(typeof(SearchElementByIndex))]
        public void SearchIndexOfTest(LnkdList<int> list, int value, int expected)
        {
            int actual = list.SearchIndexOf(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Revers))]
        public void ReversTest (LnkdList<int> actual, LnkdList<int> expected)
        {
            actual.Revers();
            Assert.AreEqual(expected, actual);
        }
        

        [TestCase(1, 2, 3, 4, 5, 1, 0, "2 3 4 5 ")]
        public void SearchIndexAndRemoveTest(int valueA, int valueB, int valueC, int valueD, int valueE,
            int value, int expectedIndex, string expectedList)
        {
            LnkdList<int> list = new LnkdList<int>();
            list.Add(valueA);
            list.Add(valueB);
            list.Add(valueC);
            list.Add(valueD);
            list.Add(valueE);

            int actualIndex = list.SearchIndexAndRemove(value);
            string actualList = list.ToString();
            Assert.AreEqual(expectedIndex, actualIndex);
            Assert.AreEqual(expectedList, actualList);
        }

        [TestCaseSource(typeof(SearchAndRemoveAllElements))]
        public void SearchAndRemoveAllElementsTest(LnkdList<int> list, int value, 
            LnkdList<int> expectedList, int expectedCount)
        {
            int actual = list.SearchAndRemoveAllElements(value);

            Assert.AreEqual(actual, expectedCount);
            Assert.AreEqual(list, expectedList);
        }

        [TestCaseSource(typeof(AddListInListEnd))]
        public void AddListInListEndTest<T>(LnkdList<T> list, LnkdList<T> addList, LnkdList<T> expectedList)
        {
            list.AddListInListEnd(addList);
            Assert.AreEqual(list, expectedList);
        }

        [TestCaseSource(typeof(AddListInListFirst))]
        public void AddListInListFirstTest<T>(LnkdList<T> list, LnkdList<T> addList, 
            LnkdList<T> expectedList)
        {
            list.AddListInListFirst(addList);
            Assert.AreEqual(list, expectedList);
        }

        
        [TestCaseSource(typeof(AddListInListByIndex))]
        public void AddListInListByIndexTest(LnkdList<int> list, LnkdList<int> addList, int index, 
            LnkdList<int> expectedList)
        {
            list.AddListInListByIndex(addList, index);
            Assert.AreEqual(list, expectedList);
        }

    }

    public class GetLengthTesSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList=new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);
            int expected = 4;
            yield return new object[] { lnkdList, expected };

            lnkdList = new LnkdList<int>();
            expected = 0;
            yield return new object[] { lnkdList, expected };

            lnkdList = new LnkdList<int>();
            lnkdList.Add(4);
            expected = 1;
            yield return new object[] { lnkdList, expected };
        }
    }
    public class RemoveFirstElement : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList0 = new LnkdList<int>();
            lnkdList0.Add(1);
            lnkdList0.Add(2);
            lnkdList0.Add(3);
            lnkdList0.Add(4);
            lnkdList0.Add(5);

            LnkdList<int> expected0 = new LnkdList<int>();
            expected0.Add(2);
            expected0.Add(3);
            expected0.Add(4);
            expected0.Add(5);
            yield return new object[] { lnkdList0, expected0 };

            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);
            LnkdList<int> expected = new LnkdList<int>();            
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);            
            yield return new object[] { lnkdList, expected };

            LnkdList<int> lnkdList2 = new LnkdList<int>();
            lnkdList2.Add(1);
            LnkdList<int> expected2 = new LnkdList<int>();
            yield return new object[] { lnkdList2, expected2 };

            LnkdList<int> lnkdList3 = new LnkdList<int>();  
            LnkdList<int> expected3 = new LnkdList<int>();
            yield return new object[] { lnkdList3, expected3 };
        }
    }
    public class RemoveLastElement : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);

            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);

            yield return new object[] { lnkdList, expected };

            LnkdList<int> lnkdList2 = new LnkdList<int>();
            lnkdList2.Add(1);

            LnkdList<int> expected2 = new LnkdList<int>();


            yield return new object[] { lnkdList2, expected2 };

            LnkdList<int> lnkdList3 = new LnkdList<int>();


            LnkdList<int> expected3 = new LnkdList<int>();


            yield return new object[] { lnkdList3, expected3 };
        }
    }
    public class SearchElementByIndex : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);
            lnkdList.Add(4);

            int value = 4;
            int expected = 3;

            yield return new object[] { lnkdList, value, expected };

            LnkdList<int> lnkdList2 = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);
            lnkdList.Add(4);

            int value2 = 10;
            int expected2 = -1;

            yield return new object[] { lnkdList2, value2, expected2 };
        }
    }
    public class SetIndexator : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {            
            int index = 0;

            int value = 4;

            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);
            lnkdList.Add(4);

            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(4);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            expected.Add(4);

            yield return new object[] { index, value, lnkdList, expected };

            int index1 = 0;

            int value1 = 0;

            LnkdList<int> lnkdList1 = new LnkdList<int>();
            lnkdList1.Add(1);
            lnkdList1.Add(2);
            lnkdList1.Add(3);
            lnkdList1.Add(4);
            lnkdList1.Add(5);

            LnkdList<int> expected1 = new LnkdList<int>();
            expected1.Add(0);
            expected1.Add(2);
            expected1.Add(3);
            expected1.Add(4);
            expected1.Add(5);

            yield return new object[] { index1, value1, lnkdList1, expected1 };
        }
    }
    public class Revers : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {      
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);
            lnkdList.Add(4);

            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(4);
            expected.Add(4);
            expected.Add(3);
            expected.Add(2);
            expected.Add(1);

            yield return new object[] { lnkdList, expected };

            LnkdList<int> lnkdList2 = new LnkdList<int>();
            lnkdList2.Add(1);           

            LnkdList<int> expected2 = new LnkdList<int>();
            expected2.Add(1);

            yield return new object[] { lnkdList2, expected2 };

            LnkdList<int> lnkdList3 = new LnkdList<int>();            

            LnkdList<int> expected3 = new LnkdList<int>();          

            yield return new object[] { lnkdList3, expected3 };
        }
    }
    public class SearchAndRemoveAllElements : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {      
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(1);
            lnkdList.Add(2);

            int value = 2;

            LnkdList<int> expectedList = new LnkdList<int>();
            expectedList.Add(1);
            expectedList.Add(1);
            expectedList.Add(1);

            int expectedCount = 3;

            yield return new object[] { lnkdList, value, expectedList, expectedCount };

            LnkdList<int> lnkdList2 = new LnkdList<int>();
            lnkdList2.Add(1);
            lnkdList2.Add(2);
            lnkdList2.Add(1);            

            int value2 = 4;

            LnkdList<int> expectedList2 = new LnkdList<int>();
            expectedList2.Add(1);
            expectedList2.Add(2);
            expectedList2.Add(1);

            int expectedCount2 = 0;

            yield return new object[] { lnkdList2, value2, expectedList2, expectedCount2 };            

            LnkdList<int> lnkdList3 = new LnkdList<int>();
            lnkdList3.Add(4);
            int value3 = 4;
            LnkdList<int> expectedList3 = new LnkdList<int>();
            int expectedCount3 = 1;
            yield return new object[] { lnkdList3, value3, expectedList3, expectedCount3 };

            LnkdList<int> lnkdList4 = new LnkdList<int>();
            int value4 = 4;
            LnkdList<int> expectedList4 = new LnkdList<int>();
            int expectedCount4 = 0;
            yield return new object[] { lnkdList4, value4, expectedList4, expectedCount4 };
        }
    }
    public class AddListInListEnd : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(3);
            lnkdList.Add(4);

            LnkdList<int> addList = new LnkdList<int>();
            addList.Add(1);
            addList.Add(2);
            addList.Add(3);
            addList.Add(4);

            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);

            yield return new object[] { lnkdList, addList, expected };

            LnkdList<string> lnkdList2 = new LnkdList<string>();
            lnkdList2.Add("a");
            lnkdList2.Add("b");
            lnkdList2.Add("c");

            LnkdList<string> addList2 = new LnkdList<string>();
            addList2.Add("a");
            addList2.Add("b");                  

            LnkdList<string> expected2 = new LnkdList<string>();
            expected2.Add("a");
            expected2.Add("b");
            expected2.Add("c");
            expected2.Add("a");
            expected2.Add("b");            

            yield return new object[] { lnkdList2, addList2, expected2 };

            LnkdList<string> lnkdList3 = new LnkdList<string>();
            lnkdList3.Add("a");
            lnkdList3.Add("b");
            lnkdList3.Add("c");

            LnkdList<string> addList3 = new LnkdList<string>();           

            LnkdList<string> expected3 = new LnkdList<string>();
            expected3.Add("a");
            expected3.Add("b");
            expected3.Add("c");            

            yield return new object[] { lnkdList3, addList3, expected3 };

            LnkdList<string> lnkdList4 = new LnkdList<string>();            

            LnkdList<string> addList4 = new LnkdList<string>();

            LnkdList<string> expected4 = new LnkdList<string>();            

            yield return new object[] { lnkdList4, addList4, expected4 };
        }
    }
    public class AddListInListFirst : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(2);
            lnkdList.Add(2);
            lnkdList.Add(2);            

            LnkdList<int> addList = new LnkdList<int>();
            addList.Add(1);
            addList.Add(1);
            addList.Add(1);            

            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(1);
            expected.Add(1);
            expected.Add(1);
            expected.Add(2);
            expected.Add(2);
            expected.Add(2);            

            yield return new object[] { lnkdList, addList, expected };

            LnkdList<string> lnkdList2 = new LnkdList<string>();            
            lnkdList2.Add("a");
            lnkdList2.Add("b");
            lnkdList2.Add("c");

            LnkdList<string> addList2 = new LnkdList<string>();
            addList2.Add("a");
            addList2.Add("b");
        
            LnkdList<string> expected2 = new LnkdList<string>();
            expected2.Add("a");
            expected2.Add("b");            
            expected2.Add("a");
            expected2.Add("b");
            expected2.Add("c");

            yield return new object[] { lnkdList2, addList2, expected2 };

            LnkdList<string> lnkdList3 = new LnkdList<string>();
            lnkdList3.Add("a");
            lnkdList3.Add("b");
            lnkdList3.Add("c");

            LnkdList<string> addList3 = new LnkdList<string>();

            LnkdList<string> expected3 = new LnkdList<string>();
            expected3.Add("a");
            expected3.Add("b");
            expected3.Add("c");

            yield return new object[] { lnkdList3, addList3, expected3 };

            LnkdList<string> lnkdList4 = new LnkdList<string>();

            LnkdList<string> addList4 = new LnkdList<string>();

            LnkdList<string> expected4 = new LnkdList<string>();

            yield return new object[] { lnkdList4, addList4, expected4 };
        }
    }

    public class AddListInListByIndex : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            LnkdList<int> lnkdList = new LnkdList<int>();
            lnkdList.Add(1);
            lnkdList.Add(2);
            lnkdList.Add(6);

            LnkdList<int> addList = new LnkdList<int>();
            addList.Add(3);
            addList.Add(4);
            addList.Add(5);

            int index = 2;


            LnkdList<int> expected = new LnkdList<int>();
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            expected.Add(5);
            expected.Add(6);

            yield return new object[] { lnkdList, addList, index, expected };
        }
    }
}