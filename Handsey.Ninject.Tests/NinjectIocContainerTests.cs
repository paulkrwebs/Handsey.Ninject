using Moq;
using Ninject;
using NUnit.Framework;
using System;
using System.Linq;

namespace Handsey.Ninject.Tests
{
    [TestFixture]
    public class NinjectIocContainerTests
    {
        private StandardKernel _standardKernel;
        private IIocContainer _ninjectIocContainer;

        [SetUp]
        public void SetUp()
        {
            _standardKernel = new StandardKernel();
            _ninjectIocContainer = new NinjectIocContainer(_standardKernel);
        }

        [Test]
        public void Register_TypeAndTypeAndString_TypeRegsiteredOnNinjectContainerWithName()
        {
            // Mocking StandardKernel throws an exception so need to do an intergration test here
            _ninjectIocContainer.Register(typeof(IIocContainer), typeof(MockObject), "test");

            Assert.That(_standardKernel.Get<IIocContainer>("test"), Is.Not.Null, "Type not registered");
        }

        [Test]
        public void ResolveAll_NoParams_ResolveAllCalledOnNinjectContainer()
        {
            // Mocking StandardKernel throws an exception so need to do an intergration test here
            _ninjectIocContainer.Register(typeof(IIocContainer), typeof(MockObject), "test1");
            _ninjectIocContainer.Register(typeof(IIocContainer), typeof(MockObject2), "test2");

            Assert.That(_ninjectIocContainer.ResolveAll<IIocContainer>().Count(), Is.EqualTo(2), "Type not registered");
        }

        private class MockObject : IIocContainer
        {
            public void Register(Type from, Type to)
            {
                throw new NotImplementedException();
            }

            public void Register(Type from, Type to, string name)
            {
                throw new NotImplementedException();
            }

            public TResolve[] ResolveAll<TResolve>()
            {
                throw new NotImplementedException();
            }
        }

        private class MockObject2 : IIocContainer
        {
            public void Register(Type from, Type to)
            {
                throw new NotImplementedException();
            }

            public void Register(Type from, Type to, string name)
            {
                throw new NotImplementedException();
            }

            public TResolve[] ResolveAll<TResolve>()
            {
                throw new NotImplementedException();
            }
        }
    }
}