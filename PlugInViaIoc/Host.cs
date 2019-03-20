using System;
using Contracts;

namespace PlugInViaIoc
{
    public class Host : IHost
    {
        private readonly IFoo _foo;
        private readonly IBar _bar;

        public Host(IFoo foo, IBar bar)
        {
            _foo = foo;
            _bar = bar;
        }

        public string DoHost()
        {
            var _ = _foo.DoFoo("DoFoo call from Host");
            _ += "   ";
            _ += _bar.DoBar("DoBar call from Host");
            return _;
        }
    }
}