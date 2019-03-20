using Castle.MicroKernel.Registration;
using Contracts;
using PlugInOne;
using Xunit;

namespace PlugIn.Tests
{
    /// <summary>
    /// Example how to get a type which implements a specific interface.
    /// </summary>
    public class ResolveSingleType : IocTestBase
    {
        public ResolveSingleType() : base()
        {
            Container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<IFoo>().WithService.AllInterfaces());
        }


        [Fact]
        public void Resolve_IFooBar_ISomething_Should_Return_FooBar()
        {
            var foo = Container.Resolve<IFoo>();
            Assert.IsType<Foo>(foo);
        }
    }
}