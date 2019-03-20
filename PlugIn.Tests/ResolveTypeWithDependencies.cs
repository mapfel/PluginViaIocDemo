using Castle.MicroKernel.Registration;
using Contracts;
using PlugInViaIoc;
using Xunit;

namespace PlugIn.Tests
{
    /// <summary>
    /// Show the capabilities of in IoC container to resolve an implementation which needs other elements in its constructor. This dependencies gets automatically resolved of the container.
    /// </summary>
    public class ResolveTypeWithDependencies : IocTestBase
    {
        public ResolveTypeWithDependencies() : base()
        {
            Container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<IFoo>().WithService.AllInterfaces());
            Container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<IBar>().WithService.AllInterfaces());
            Container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<IHost>().WithService.AllInterfaces());
        }


        [Fact]
        public void Resolve_IHost_Return_Host()
        {
            var host = Container.Resolve<IHost>();
            Assert.IsType<Host>(host);
        }

        [Fact]
        public void Calling_Host_Method_Should_Return_Correct_String()
        {
            var host = Container.Resolve<IHost>();
            var s = host.DoHost();
            Assert.Equal("Foo.DoFoo(DoFoo call from Host)   Bar.DoBar(DoBar call from Host)", s);
        }
    }
}