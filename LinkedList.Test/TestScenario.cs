using NUnit.Framework;
using System.Collections;

namespace LinkdList.Test
{    
    [SetUpFixture] 
    //Это атрибут, который помечает класс, содержащий методы
    //одноразовой настройки или демонтажа для всех тестовых устройств
    //в данном пространстве имен.
    [TestFixture(4)]
    [TestFixture(5)]
    [TestFixture(5, "string")]
    //Для работы своей вызывает конструкторы класса.
    //То есть он тоже самое, что TestCase, но для всего класса целиком!!!!!
    [TestFixtureSource(typeof(TestTest))]    //
    //все это позволяет писать тесты на интерфейсах
    //(то есть передавать значения для определенного интерфейса)
    //Например тест интерфейса машина будет в себя включать все значения этого
    //интерфейса и методы, при этом, нам плевать что за тачка,
    //потому что любая тачка должна обладать этими свойствами, определенными в интерфейсе
    //При этом в конструктор мы захерачим switch или [TestFixtureSource(typeof(TestTest))],
    //который в переменнную типа интерфейса будет класть конкретную реализацию класса
    //Если говорить о конкретном примере в этом классе,
    //то тесты у нас не на конкретный лист, а на интерфейс листа

    public class TestScenario
    {
        LnkdList<int> _list;
        int a;
        public TestScenario(int value)
        {
            a = value;
        }
        public TestScenario(int value, string Q)
        {
            a = value;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //Настройки, для подключения к серваку.
            //Выполняется каждый раз перед тем, как будут запущены все методы тестового сценария.
            //The One Time SetUp method in a SetUpFixture is executed once before any of the fixtures contained in its namespace.
            //Срабатывает 1 раз, когда тесты запускаются
            // ПРИМЕР Тесты высоконагруженных систем - классический сценарий использования:
            // - поднять сервисы, которые вообще будут общаться с системой,
            // - здесь можно создать сервер, все подключения.
        }

        [SetUp]
        public void SetUp()
        {
            //Создал объект тестируемый (клиент)
            //Метод, который запускается перед каждым тестом
            //=> ПРИМЕР - можно создать условного клиента и каждый раз получать токены.
        }

        //[Test]
        //public void Test()
        //{
        //    //пишу тесты с тестовой важной частью
        //}

        //[Test]
        //public void Test1()
        //{
        //    //пишу тесты с тестовой важной частью
        //}

        [TearDown]
        public void TearDown()
        {
            //пишу удали клиента
            //Метод, который выполняется после каждого теста.           
            //Например удаление Usera
        }
       

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //че-то уберу потому что создал лишнего
            //Выполняется один раз после того, как все методы будут выполнены.
            //The OneTimeTearDown method is executed once after all
            //the fixtures have completed execution.
            //Выполняется один раз после того, как в этом классе пройдены все тесты
        }

        

    }
    public class TestTest : IEnumerable
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
