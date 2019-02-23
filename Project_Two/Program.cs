using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Project_Two
{

    class Program
    {
        static void Main(string[] args)
        {

            //Variable declarations and setting up file path
            List<SuperBowl> listOfSuperBowls = new List<SuperBowl>();
            string filePath = Directory.GetCurrentDirectory();
            string stepBackOne = Directory.GetParent(filePath).ToString();
            string stepBackTwo = Directory.GetParent(stepBackOne).ToString();
            string stepBackThree = Directory.GetParent(stepBackTwo).ToString();
            string adjustedFilePath = $@"{stepBackThree}\Super_Bowl_Project.csv";
            string destinationFilePath = $@"{stepBackThree}\Super_Bowl_Stats.txt";



            if (File.Exists(adjustedFilePath))
            {

                ObjectCreator(adjustedFilePath, ref listOfSuperBowls);

                FileStream OutputFile = new FileStream(destinationFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter write = new StreamWriter(OutputFile);

                Console.WriteLine("Welcome, this program will output some data about superbowls " +
                    "to a text file in the project folder.  There is nothing else you need to do.");
                Writer1(ref write, ref listOfSuperBowls);
                
                write.WriteLine("\n");
                Writer2(ref write, ref listOfSuperBowls);
                
                write.WriteLine("\n");
                Writer3(ref write, ref listOfSuperBowls);
                Writer4(ref write, ref listOfSuperBowls);
                RandomFacts(ref write, ref listOfSuperBowls);
                
                write.Close();
                OutputFile.Close();
            }
            else
            {
                Console.WriteLine("Sorry, can't find file to read from.  Please make sure it is in the same folder as the" +
                    "program.cs file");
            }
     
        }

   


        static void ObjectCreator(string adjustedFilePath, ref List<SuperBowl> listOfSuperBowls)
        {
            
            string[] arrayOfValues;
            FileStream InputFile = new FileStream(adjustedFilePath, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(InputFile);
            read.ReadLine();
            while (!read.EndOfStream)
            {
                try
                {
                    arrayOfValues = read.ReadLine().Split(',');
                    listOfSuperBowls.Add(new SuperBowl(arrayOfValues[0], arrayOfValues[1], Int32.Parse(arrayOfValues[2]), arrayOfValues[3], arrayOfValues[4],
                        arrayOfValues[5], Int32.Parse(arrayOfValues[6]), arrayOfValues[7], arrayOfValues[8], arrayOfValues[9], Int32.Parse(arrayOfValues[10]), arrayOfValues[11], arrayOfValues[12], arrayOfValues[13], arrayOfValues[14]));
                    
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                

            }//End while

            //Closing files and streams
            read.Close();
            InputFile.Close();
           
        }

        static void Writer1(ref StreamWriter write, ref List<SuperBowl> listOfSuperBowls)
        {
            var SuperBowlQuery = from SuperBowl in listOfSuperBowls
                                 
                                   //Format query
                                 select SuperBowl;
            
            write.WriteLine("All super bowl winners arranged by year:\n");
            foreach (SuperBowl superBowl in SuperBowlQuery)
            {
                write.Write(superBowl.SuperBowlWinners()+"\n");
            }

        }

        // For outputting top five attended super bowls
        static void Writer2(ref StreamWriter write, ref List<SuperBowl> listOfSuperBowls)
        {
            var Query2 = from superBowl in listOfSuperBowls
                         orderby superBowl.Attendance descending

                         select superBowl;

            var Taker = Query2.Take(5);
            write.WriteLine("Top five attended Superbowls in order of attendance");
            write.WriteLine();
            foreach(var superBowl in Taker)
            {
                write.Write(superBowl.TopFiveAttended()+"\n");
            }
        }

        
        static void Writer3(ref StreamWriter write, ref List<SuperBowl> listOfSuperBowls)
        {
            var groupQuery = from superBowl in listOfSuperBowls
                             group superBowl by superBowl.State into stateGroup
                             orderby stateGroup.Count() descending
                             select new { aGroup = stateGroup.Key, Count = stateGroup.Count() };
            var Taker = groupQuery.Take(1);
            foreach (var superBowl in Taker)
            {
                write.Write($"The state that has hosted the most superbowls is {superBowl.aGroup}. They have hosted {superBowl.Count} superbowls.\n");
                
            }

            //This is crude, how to do using LINQ
            foreach(var SuperBowl in listOfSuperBowls)
            {
                if(SuperBowl.State == "Florida")
                {
                    write.Write(SuperBowl.HighestState()+"\n");
                }
            }
        }

        static void Writer4(ref StreamWriter write, ref List<SuperBowl> listOfSuperBowls)
        {

            write.WriteLine("\nPlayers that have been named MVP more than once: \n");
             var MVPQuery = from superBowl in listOfSuperBowls
                           group superBowl by superBowl.MVP into MVPGroup
                           orderby MVPGroup.Count() descending
                           where MVPGroup.Count() > 1
                           select MVPGroup;

            foreach (var mvp in MVPQuery)
            {
                write.WriteLine(mvp.Key);
                foreach (var player in mvp)
                {
                    write.WriteLine(player.MVPWriter());
                }
                write.WriteLine("\n");
            }
  
        }

        static void RandomFacts(ref StreamWriter write, ref List<SuperBowl> listOfSuperBowls)
        {
            write.WriteLine("Here are some superbowl fun facts\n\n");
            var coachQuery = from superBowl in listOfSuperBowls
                           group superBowl by superBowl.WinningCoach into CoachGroup
                           orderby CoachGroup.Count() descending
                           select CoachGroup;


            write.WriteLine("The winningist coach is " + coachQuery.First().Key + ". He has won "+ coachQuery.First().Count());

            var coachQuery2 = from superBowl in listOfSuperBowls
                              group superBowl by superBowl.LosingCoach into CoachGroup2
                              orderby CoachGroup2.Count() descending
                              select CoachGroup2;

            write.WriteLine("The coach that has lost the most superbowls is " + coachQuery2.First().Key+ ". He has lost " + coachQuery2.First().Count());

            var WinningQuery = from superBowl in listOfSuperBowls
                               group superBowl by superBowl.WinningTeamName into TeamGroup
                               orderby TeamGroup.Count() descending
                               select TeamGroup;
            write.WriteLine("The team that has won the most superbowls is " + WinningQuery.First().Key + ". they have won " + WinningQuery.First().Count());

            var LosingQuery = from superBowl in listOfSuperBowls
                               group superBowl by superBowl.LosingTeamName into TeamGroup2
                               orderby TeamGroup2.Count() descending
                               select TeamGroup2;
            write.WriteLine("The team that has won the most superbowls is " + LosingQuery.First().Key + ". they have lost " + LosingQuery.First().Count());

            double averageValue = listOfSuperBowls.Average(x => x.Attendance);

            write.WriteLine("Average attendance of all superbowls was " + averageValue.ToString("n0"));

            var PointDifferenceQuery = from superBowl in listOfSuperBowls
                                       orderby superBowl.PointDifference descending
                                       select superBowl;
            write.WriteLine($"The super bowl with the biggest point difference was Super Bowl {PointDifferenceQuery.First().SuperBowlRomanNumeral}. It had a point difference of {PointDifferenceQuery.First().PointDifference}.");
        }

        
    }
}
