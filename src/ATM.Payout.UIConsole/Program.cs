using ATM.Payout.UIConsole.Runners;

namespace ATM.Payout.UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var runner = new PayoutRunner();
            runner.Run();
        }
    }
}
