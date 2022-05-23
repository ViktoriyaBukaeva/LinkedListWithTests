using LinkdList;
using NUnit.Framework;
using System.Collections;

namespace LinkedList.Test
{
    [TestFixtureSource(typeof(TestSource))]
    //идея в том, что нужно написать какую-то штуку,
    //куда можно добавлять testcases именно для того,
    //чтоб тестить один и тот же сценарий, но на разные тест кейсы
    //Основная идея, что тестовый сценарий - не метод, а сам класс.
    public class TestScenarioForList //Это тестовый сценарий использования методов!!!
    {
        LnkdList<int> _actual;
        TestModel _testModel;    

        public TestScenarioForList(TestModel testModel)
        {
            _testModel = testModel;
            _actual = testModel.Original;           
        }

        [Test]
        public void LnkdListIntegratedTest_Create_Read_Update_Delete()
        {
            AddTest(_testModel.AddTestValue, _testModel.AddTestExpected);
            SetIndexatorTest(_testModel.SetIndexatorTestIndex, _testModel.SetIndexatorTestValue, _testModel.SetIndexatorTestExpected);
            RemoveFirstTest(_testModel.RemoveFirstTestExpected);
            GetLenghTest(_testModel.GetLengthTestExpected);
        }
        public void GetLenghTest(int expected)
        {
            int actual = _actual.Length;
            Assert.AreEqual(expected, actual);
        }

        public void SetIndexatorTest(int index, int value, LnkdList<int> expected)
        {
            _actual[index] = value;
            Assert.AreEqual(expected, _actual);
        }

        public void AddTest(int value, LnkdList<int> expected)
        {
            _actual.Add(value);
            Assert.AreEqual(expected, _actual);
        }

        public void RemoveFirstTest(LnkdList<int> expected)
        {
            _actual.RemoveFirst();
            Assert.AreEqual(expected, _actual);
        }
    }
    public class TestModel
    {
        public LnkdList<int> Original { get; set; }
        public int AddTestValue { get; set; }
        public LnkdList<int> AddTestExpected { get; set; }

        public int SetIndexatorTestIndex { get; set; }
        public int SetIndexatorTestValue { get; set; }
        public LnkdList<int> SetIndexatorTestExpected { get; set; }

        public LnkdList<int> RemoveFirstTestExpected { get; set; }

        public int GetLengthTestExpected { get; set; }
    }
    public class TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestModel()
            {
                Original = new LnkdList<int>(new int[] { 1, 2, 3, 4, 5 }),
                AddTestValue = 6,
                AddTestExpected = new LnkdList<int>(new int[] { 1, 2, 3, 4, 5, 6 }),

                SetIndexatorTestIndex = 0,
                SetIndexatorTestValue = -5,
                SetIndexatorTestExpected = new LnkdList<int>(new int[] { -5, 2, 3, 4, 5, 6 }),

                RemoveFirstTestExpected = new LnkdList<int>(new int[] { 2, 3, 4, 5, 6 }),

                GetLengthTestExpected = 5,
            };

            yield return new TestModel()
            {
                Original = new LnkdList<int>(new int[] { 1 }),
                AddTestValue = 6,
                AddTestExpected = new LnkdList<int>(new int[] { 1, 6 }),

                SetIndexatorTestIndex = 0,
                SetIndexatorTestValue = -5,
                SetIndexatorTestExpected = new LnkdList<int>(new int[] { -5, 6 }),

                RemoveFirstTestExpected = new LnkdList<int>(new int[] { 6 }),

                GetLengthTestExpected = 1,
            };

            yield return new TestModel()
            {
                Original = new LnkdList<int>(new int[] { 1, 2, 3, 4, 5 }),
                AddTestValue = 6,
                AddTestExpected = new LnkdList<int>(new int[] { 1, 2, 3, 4, 5, 6 }),

                SetIndexatorTestIndex = 0,
                SetIndexatorTestValue = 0,
                SetIndexatorTestExpected = new LnkdList<int>(new int[] { 0, 2, 3, 4, 5, 6 }),

                RemoveFirstTestExpected = new LnkdList<int>(new int[] { 2, 3, 4, 5, 6 }),

                GetLengthTestExpected = 5,
            };
        }

    }
}
