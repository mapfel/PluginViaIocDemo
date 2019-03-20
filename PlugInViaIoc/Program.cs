using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Contracts;
using PlugInOne;
using PlugInTwo;

namespace PlugInViaIoc
{
    class Program
    {
        private SomethingTwo somethingTwo;
        private SomethingOne somethingOne;

        static void Main(string[] args)
        {
            var currDomain = AppDomain.CurrentDomain;
            //var webAppBinDir = currDomain.RelativeSearchPath;
            //var assemblyDir = (!string.IsNullOrEmpty(webAppBinDir)) ? webAppBinDir : currDomain.BaseDirectory;
            var assemblyDir = currDomain.BaseDirectory;

            var container = new WindsorContainer();
            //container.Install(
            //    FromAssembly.This(),
            //    FromAssembly.InDirectory(new AssemblyFilter(assemblyDir)));
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
