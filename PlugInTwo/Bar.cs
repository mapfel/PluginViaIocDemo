using System;
using Contracts;

namespace PlugInTwo
{
    public class Bar : IBar
    {
        public string DoBar(string s)
        {
            var _ = $"Bar.DoBar({s})";
            Console.WriteLine(_);
            return _;
        }
    }
}