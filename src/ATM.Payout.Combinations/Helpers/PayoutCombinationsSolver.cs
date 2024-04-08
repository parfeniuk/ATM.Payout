namespace ATM.Payout.Combinations.Helpers
{
    public static class PayoutCombinationsSolver
    {
        public static List<List<int>> GetPayoutCombinations(int[] denominations, int amount)
        {
            var result = new List<List<int>>();
            GetPayoutCombinations(denominations, amount, 0, [], result);
            return result;
        }

        private static void GetPayoutCombinations(int[] denominations, int amount, int index, List<int> currentCombination, List<List<int>> result)
        {
            // Base case
            // If amount is zero, we have found a valid combination (amount decremented by denominations recursively)
            if (amount == 0)
            {
                result.Add([..currentCombination]);
                return;
            }

            // If the amount is negative or we have reached the end of the denominations array, we return
            if (amount < 0 || index == denominations.Length)
            {
                return;
            }

            // Add the current denomination to the current combination
            currentCombination.Add(denominations[index]);
            
            // Use the current denomination and move to the next one with the same amount
            GetPayoutCombinations(denominations, amount - denominations[index], index, currentCombination, result);

            // Backtrack - clean the last denomination from the current combination array in order to try the next denomination
            currentCombination.RemoveAt(currentCombination.Count - 1);
            
            // Move to the next denonimation
            GetPayoutCombinations(denominations, amount, index + 1, currentCombination, result);
        }
    }
}
