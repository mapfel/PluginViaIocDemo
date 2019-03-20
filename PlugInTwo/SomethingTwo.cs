using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace PlugInTwo
{
    public class SomethingTwo : ISomething
    {
        public void DoSomething(string parameter)
        {
            Console.WriteLine("SomethingTwo.DoSomething");
        }

        public string GetSomething(int i)
        {
            return "SomethingTwo.DoSomething";
        }
    }
}
