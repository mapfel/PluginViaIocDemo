using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Contracts;
using PlugInOne;
using PlugInTwo;
using PlugInViaIoc;
using Xunit;

namespace PlugIn.Tests
{
    public abstract class IocTest
    {
        // ensure that the assemblies are copied to the active bin folder
        private SomethingTwo somethingTwo;
        private SomethingOne somethingOne;

        private IWindsorContainer _container;
        protected IWindsorContainer Container => _container ?? (_container = CreateContainer());

        protected string AssemblyDirectory
        {
            get
            {
                var currentDomain = AppDomain.CurrentDomain;
                var assemblyDir = currentDomain.BaseDirectory;
                return assemblyDir;
            }
        }

        protected IocTest()
        {
            //_container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<ISomething>().WithService.AllInterfaces());
            //_container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory)).BasedOn<IFooBar>().WithService.AllInterfaces());
        }

        //Factory Method
        private static IWindsorContainer CreateContainer()
        {
            IWindsorContainer container = new WindsorContainer();
            return container;
        }

        public class ResolveMultipleTypes : IocTest
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

        public class ResolveSingleType : IocTest
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

        public class ResolveTypeWithDependencies : IocTest
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
}