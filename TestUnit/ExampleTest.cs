using Challenge1;
using Challenge1.Service;
using NUnit.Framework;

namespace Test
{
    public class ExampleTests
    {
        private DI service;

        [SetUp]
        public void Setup()
        {
            service = new DI(new Service());
        }

        [Test]
        public void Test1()
        {
            //Assert
            var cores = 7;
            var x = "(1, 6), (2, 2), (3, 4)";
            var y = "(1, 2)";
            //Attr
            //ProgramResult c1 = new ProgramResult(new Service());
            var result = service.Run(cores, x, y);

            Assert.AreEqual("(3,1)", result);

        }

        [Test]
        public void Test2()
        {

            var cores = 10;
            var x = "(1, 5), (2, 7), (3, 10), (4, 3)";
            var y = "(1, 5), (2, 4), (3, 3), (4, 2)";

            var result = service.Run(cores, x, y);

            Assert.AreEqual("(1,1),(2,3)", result);

        }

        [Test]
        public void Test3()
        {

            var cores = 20;
            var x = "(1, 9), (2, 15), (3, 8)";
            var y = "(1, 11), (2, 8), (3, 12)";

            var result = service.Run(cores, x, y);

            Assert.AreEqual("(1,1),(3,3)", result);

        }

        [Test]
        public void Test4()
        {

            var cores = 20;
            var x = "(1, 7), (2, 14), (3, 8)";
            var y = "(1, 14), (2, 5), (3, 10)";

            var result = service.Run(cores, x, y);

            Assert.AreEqual("(2,2)", result);

        }
    }
}