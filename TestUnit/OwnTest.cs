using Challenge1;
using Challenge1.Service;
using NUnit.Framework;

namespace Test
{
    public class OwnTest
    {
        private DI service;
        [SetUp]
        public void Setup()
        {
            service = new DI(new Service());
        }

        [Test]
        public void ZeroInputCore()
        {
            //Assert
            var cores = 0;
            var x = "(1, 6), (2, 2), (3, 4)";
            var y = "(1, 2)";

            var result = service.Run(cores, x, y);
            Assert.IsEmpty(result);

        }

        [Test]
        public void EmptyListforegroundInput()
        {
            //Assert
            var cores = 10;
            var x = "";
            var y = "(1, 2)";
           
            var result = service.Run(cores, x, y);
            Assert.IsEmpty(result);

        }

        [Test]
        public void EmptyListbackgroundInput()
        {
            //Assert
            var cores = 5;
            var x = "(1,0,(2,3),(3,5)";
            var y = "";
          
            var result = service.Run(cores, x, y);
            Assert.IsEmpty(result);

        }


        [Test]
        public void WithSpaceListbackgroundInput()
        {
            //Assert
            var cores = 30;
            var x = "(1, 7), (2, 14), (3, 10)";
            var y = "(1,    10),           (2,     5), (3,      23)";
            
            var result = service.Run(cores, x, y);

            Assert.AreEqual("(1,3),(2,1)", result);

        }


    }
}
