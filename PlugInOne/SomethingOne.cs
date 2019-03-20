using System;
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
