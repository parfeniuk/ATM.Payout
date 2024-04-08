using ATM.Payout.Combinations.Helpers;

namespace ATM.Payout.UIConsole.Runners
{
    public class PayoutRunner
    {
        public void Run()
        {
            int[] amounts = [30, 50, 60, 80, 140, 230, 370, 610 ,980];
            int[] denominations = [ 10, 50, 100 ];

            foreach (var amount in amounts)
            {
                var combinations = PayoutCombinationsSolver.GetPayoutCombinations(denominations, amount);
                
                Console.WriteLine($"Possible {combinations.Count} payout combination(s) for {amount} EUR:");
                
                foreach (var combination in combinations)
                {
                    var groupedCombination = combination
                        .GroupBy(x => x)
                        .Select(x => new { Denomination = x.Key, Count = x.Count() });
                    
                    Console.WriteLine(string.Join(", ", groupedCombination.Select(x => $"{x.Count} x {x.Denomination}")));
                }
            }

            Console.ReadLine();
        }
    }
}
