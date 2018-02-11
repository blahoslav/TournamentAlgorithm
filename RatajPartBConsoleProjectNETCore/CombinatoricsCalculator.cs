using System;
using System.Collections.Generic;
using System.Text;

namespace RatajPartBConsoleProjectNETCore
{
    public class CombinatoricsCalculator
    {
        public int CalculateNumberOfUniqueMatches(int numberOfPlayers, int numberOfPlayersInMatch)
            {
            double numberOfUniqueMatches = CalculateFactorial(numberOfPlayers) / (CalculateFactorial(numberOfPlayers - numberOfPlayersInMatch)* CalculateFactorial(numberOfPlayersInMatch));
            return Convert.ToInt32(numberOfUniqueMatches);
                

            }
        private double CalculateFactorial(double numberToBeFactorised)
        {
            double result = numberToBeFactorised;
            numberToBeFactorised--;
            for (double i = numberToBeFactorised; i > 0; i--)
            {
                result *= i;
            }
            result = (numberToBeFactorised == 0) ? 1 : result;
            return result;
        }
    }
}
