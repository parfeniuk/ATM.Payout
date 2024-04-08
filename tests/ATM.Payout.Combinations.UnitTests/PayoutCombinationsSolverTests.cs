using ATM.Payout.Combinations.Helpers;
using Xunit;

namespace ATM.Payout.Combinations.UnitTests
{
    public class PayoutCombinationsSolverTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void GetPayoutCombinations_ShouldReturnCorrectCombinations(int[] denominations, int amount, int[][] expectedCombinations)
        {
            // Act
            var result = PayoutCombinationsSolver.GetPayoutCombinations(denominations, amount);
            
            // Assert
            Assert.Equal(expectedCombinations.Length, result.Count);

            for (int i = 0; i < expectedCombinations.Length; i++)
            {
                Assert.Equal(amount, result[i].Sum());
            }
        }
        public static TheoryData<int[], int, int[][]> TestData => new()
        {
            { denominations, 30, new int[][] { [10, 10, 10] } },
            { denominations, 50, new int[][] { [50], [10, 10, 10 ,10, 10] } },
            { denominations, 60, new int[][] { [50, 10], [10, 10, 10 ,10, 10, 10] } },
            { denominations, 80, new int[][] { [50, 10, 10, 10], [10, 10, 10 ,10, 10, 10, 10, 10] } },
            { denominations, 100, new int[][] { [50, 10, 10, 10, 10, 10], [10, 10, 10 ,10, 10, 10, 10, 10, 10, 10], [50, 50], [100] } },
            { denominations, 140, new int[][] { [50, 10, 10, 10, 10, 10, 10, 10, 10, 10], [10, 10, 10 ,10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10], 
                [50, 50, 10, 10, 10, 10], [100, 10, 10, 10, 10] } },
        };

        private static readonly int[] denominations = [10, 50, 100];
    }
}
