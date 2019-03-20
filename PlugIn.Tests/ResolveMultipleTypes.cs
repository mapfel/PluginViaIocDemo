using Castle.MicroKernel.Registration;
using Contracts;
using Xunit;

namespace PlugIn.Tests
{
    /// <summary>
    /// Example how an IoC container can find all types implementing a specific interface.
    /// </summary>
    public class ResolveMultipleTypes : IocTestBase
    {
        public ResolveMultipleTypes() : base()
        {
            Container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<ISomething>().WithService.AllInterfaces());
        }


        [Fact]
        public void Resolve_all_ISomething_Should_Return_Two_Classes()
        {
            var list = Container.ResolveAll<ISomething>();
            Assert.Equal(2, list.Length);
        }
    }
}