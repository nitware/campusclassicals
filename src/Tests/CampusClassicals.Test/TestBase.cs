using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Moq;
using CampusClassicals.Core.Infrastructure;

namespace CampusClassicals.Test
{
    public class TestBase
    {
        public TestBase()
        {
        }

        [Fact]
        public void CanExecuteTest()
        {
            int a = 7;

            Assert.True(a == 7);
        }

        [Fact]
        public void CanExecuteTest2()
        {
            int a = 7;

            Assert.True(a == 7);
        }

        [Fact]
        public void CanListExecutingAssemblies()
        {
            var typeFinder = new AppTypeFinder();
            var assemblies = typeFinder.GetAssemblies();

            Assert.NotNull(assemblies);
            Assert.Equal(3, assemblies.Count);
        }

        [Fact]
        public void C()
        {
            //var mockTypeFinder = new Mock<ITypeFinder>();
            //mockTypeFinder.Setup(x => x.GetAssemblies()).Returns(new List<System.Reflection.Assembly>());
            //// mockTypeFinder.Object

            //mockTypeFinder.VerifyGet(x => x.GetAssemblies(), Times.Once);
        }






    }
}
