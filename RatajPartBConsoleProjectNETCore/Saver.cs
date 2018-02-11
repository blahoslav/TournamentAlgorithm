using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RatajPartBConsoleProjectNETCore
{
    public class Saver
    {
        public void SaveAllTheRoundsIntoTheFile(List<Player> allTheStartingPlayers, List<Player> allTheRivalPlayers, int numberOfPlayers)
        {
            string fileName = "Round 1.txt";
            int upperLimit = 0;
            int numberOfMatchesInEachRound = numberOfPlayers / 2;
            int numberOfRounds = numberOfPlayers - 1;
            List<Player> startingPlayersToWriteIntoFile = new List<Player>();
            List<Player> rivalPlayersToWriteIntoFile = new List<Player>();
            foreach (var player in allTheStartingPlayers)
            {
                startingPlayersToWriteIntoFile.Add(player);
            }
            foreach (var player in allTheRivalPlayers)
            {
                rivalPlayersToWriteIntoFile.Add(player);
            }
            List<string> tempMemoryOfWriter = new List<string>();
            for (int i = 0; i < (numberOfRounds * 2); i++)
            {
                for (int k = 0; k < numberOfMatchesInEachRound; k++)
                {
                    tempMemoryOfWriter.Add(startingPlayersToWriteIntoFile[0].Name + " - " + rivalPlayersToWriteIntoFile[0].Name);
                    startingPlayersToWriteIntoFile.RemoveAt(0);
                    rivalPlayersToWriteIntoFile.RemoveAt(0);
                }
                Console.WriteLine("Round no. " + Convert.ToString(i + 1));
                using (StreamWriter writer = new StreamWriter("Round " + Convert.ToString(i + 1) + ".txt"))
                {
                    writer.WriteLine("Match no. " + Convert.ToString(i + 1));
                    foreach (var match in tempMemoryOfWriter)
                    {
                        writer.WriteLine(match);
                        Console.WriteLine(match);
                    }
                }
                tempMemoryOfWriter.Clear();
                Console.WriteLine();
            }
            Console.WriteLine("Files saved into the project directory.");
        }
    }
}
