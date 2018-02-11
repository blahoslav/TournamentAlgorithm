using System;
using System.Collections.Generic;

namespace RatajPartBConsoleProjectNETCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questions 1 and 3");
            List<Player> listOfPlayers = new List<Player>();
            listOfPlayers.Add(new Player("Anezka"));
            listOfPlayers.Add(new Player("Blahoslav"));
            listOfPlayers.Add(new Player("Cyril"));
            listOfPlayers.Add(new Player("Daniel"));
            listOfPlayers.Add(new Player("Emanuela"));
            listOfPlayers.Add(new Player("Filip"));
            listOfPlayers.Add(new Player("Gabriela"));
            listOfPlayers.Add(new Player("Hana"));
            listOfPlayers.Add(new Player("Chvalimira"));
            listOfPlayers.Add(new Player("Ivos"));
            listOfPlayers.Add(new Player("Jiri"));
            listOfPlayers.Add(new Player("Katerina"));
            listOfPlayers.Add(new Player("Lucie"));
            listOfPlayers.Add(new Player("Monika"));
            listOfPlayers.Add(new Player("Natalie"));
            listOfPlayers.Add(new Player("Oldriska"));
            listOfPlayers.Add(new Player("Petr"));
            listOfPlayers.Add(new Player("Tomas"));
            listOfPlayers.Add(new Player("Urban"));
            listOfPlayers.Add(new Player("Veronika"));
            int numberOfPlayers = listOfPlayers.Count;
            Console.WriteLine("List of players registered to the competition:");
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine(listOfPlayers[i].Name);
            }
            List<Player> startingPlayersInRound = new List<Player>();
            List<Player> startingPlayersInAllTheRounds = new List<Player>();
            for (int i = 0; i < (numberOfPlayers/2); i++)
            {
                startingPlayersInRound.Add(listOfPlayers[i]);
                startingPlayersInAllTheRounds.Add(listOfPlayers[i]);
            }
            List<Player> rivalPlayersInRound = new List<Player>();
            List<Player> rivalPlayersInAllTheRounds = new List<Player>();
            int counter = 0;
            for (int i = (numberOfPlayers / 2); i < numberOfPlayers; i++)
            {
                rivalPlayersInRound.Add(listOfPlayers[i]);
                rivalPlayersInAllTheRounds.Add(listOfPlayers[numberOfPlayers - 1 - counter]);
                counter++;
            }
            CombinatoricsCalculator combinatoricsCalculator = new CombinatoricsCalculator();
            int totalNumberOfMatches = combinatoricsCalculator.CalculateNumberOfUniqueMatches(numberOfPlayers, 2);
            Console.WriteLine("Number of matches: " + totalNumberOfMatches);
            Console.WriteLine("Number of rounds: " + (numberOfPlayers - 1));
            List<Player> playersThatBecomeRival = new List<Player>();
            List<Player> playersThatBecomeTheFirst = new List<Player>();
            for (int i = 0; i < (numberOfPlayers - 2); i++)
            {
                List<Player> playersToMove = new List<Player>();
                for (int k = 1; k < (startingPlayersInRound.Count - 1); k++)
                {    
                        playersToMove.Add(startingPlayersInRound[k + 1]);              
                        if (k == 1)
                        {
                            playersThatBecomeRival.Add(startingPlayersInRound[(startingPlayersInRound.Count - 1)]);
                            playersThatBecomeTheFirst.Add(rivalPlayersInRound[(startingPlayersInRound.Count - 1)]);
                            startingPlayersInRound[k + 1] = startingPlayersInRound[k];
                            startingPlayersInRound[k] = playersThatBecomeTheFirst[(playersThatBecomeTheFirst.Count - 1)];

                        }
                        else
                        {
                            startingPlayersInRound[k + 1] = playersToMove[playersToMove.Count - 2];
                        }     
                }
                for (int k = 0; k < (rivalPlayersInRound.Count - 1); k++)
                {
                    playersToMove.Add(rivalPlayersInRound[k + 1]);
                    if (k == 0)
                    {
                        rivalPlayersInRound[k + 1] = rivalPlayersInRound[k];
                        rivalPlayersInRound[0] = playersThatBecomeRival[(playersThatBecomeRival.Count - 1)];
                    }
                    else
                    {
                        rivalPlayersInRound[k + 1] = playersToMove[playersToMove.Count - 2];
                    }
                }
                for (int k = 0; k < startingPlayersInRound.Count; k++)
                {
                    startingPlayersInAllTheRounds.Add(startingPlayersInRound[k]);
                    rivalPlayersInAllTheRounds.Add(rivalPlayersInRound[startingPlayersInRound.Count - 1 - k]);
                }
            }
            for (int i = 0; i < totalNumberOfMatches; i++)
            {
                if (startingPlayersInAllTheRounds[i].Name == "Anezka")
                {
                    startingPlayersInAllTheRounds.Add(startingPlayersInAllTheRounds[i]);
                    rivalPlayersInAllTheRounds.Add(rivalPlayersInAllTheRounds[i]);
                }
                else
                {
                    Player playerToBeSwaped = rivalPlayersInAllTheRounds[i];
                    rivalPlayersInAllTheRounds.Add(startingPlayersInAllTheRounds[i]);
                    startingPlayersInAllTheRounds.Add(playerToBeSwaped);
                }
            }         
            // Question 2
            Saver saver = new Saver();
            saver.SaveAllTheRoundsIntoTheFile(startingPlayersInAllTheRounds, rivalPlayersInAllTheRounds, numberOfPlayers);
            Console.ReadLine();
        }
    }
}
