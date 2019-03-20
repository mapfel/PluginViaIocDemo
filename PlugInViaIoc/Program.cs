using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Contracts;
using PlugInOne;
using PlugInTwo;

namespace PlugInViaIoc
{
    internal class Program
    {
        // ensure that the assemblies are copied to the active bin folder
        private SomethingTwo somethingTwo;
        private SomethingOne somethingOne;

        static void Main()
        {
            var currentDomain = AppDomain.CurrentDomain;
            var assemblyDir = currentDomain.BaseDirectory;

            var container = new WindsorContainer();
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(assemblyDir)).BasedOn<ISomething>().WithService.AllInterfaces());
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(assemblyDir)).BasedOn<IFooBar>().WithService.AllInterfaces());

            var list = container.ResolveAll<ISomething>();

            foreach (var something in list)
            {
                Console.WriteLine(something.ToString());
            }

            Console.ReadLine();
        }
    }
}
