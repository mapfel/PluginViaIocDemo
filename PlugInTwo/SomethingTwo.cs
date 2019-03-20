using System;
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
