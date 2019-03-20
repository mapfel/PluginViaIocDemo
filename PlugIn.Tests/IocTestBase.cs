using System;
using Castle.Windsor;
using PlugInOne;
using PlugInTwo;

namespace PlugIn.Tests
{
    /// <summary>
    /// Base class for tests to share common properties and behaviour for later usage in individual test classes.
    /// </summary>
    public abstract class IocTestBase
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

        protected IocTestBase()
        {
            // base configurations
        }

        //Factory Method
        private static IWindsorContainer CreateContainer()
        {
            IWindsorContainer container = new WindsorContainer();
            return container;
        }
    }
}