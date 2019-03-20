using System;
using Contracts;

namespace PlugInOne
{
    public class Foo : IFoo
    {
        public string DoFoo(string s)
        {
            var _ = $"Foo.DoFoo({s})";
            Console.WriteLine(_);
            return _;
        }
    }
}