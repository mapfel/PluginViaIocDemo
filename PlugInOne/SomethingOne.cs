using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace PlugInOne
{
    public class SomethingOne : ISomething 
    {
        public void DoSomething(string parameter)
        {
            Console.WriteLine("SomethingOne.DoSomething");
        }

        public string GetSomething(int i)
        {
            return "SomethingOne.DoSomething";
        }
    }
}
