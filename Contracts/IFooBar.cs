namespace Contracts
{
    public interface IFooBar : IFoo, IBar
    {
        string DoFooBar(string s);
    }
}