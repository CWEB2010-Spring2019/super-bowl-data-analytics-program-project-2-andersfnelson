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
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            

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


                Writer1(ref write, ref listOfSuperBowls);
                write.WriteLine("query2");
                write.WriteLine("\n");
                Writer2(ref write, ref listOfSuperBowls);
                
                write.WriteLine("query 3");
                //Writer3(ref write, ref listOfSuperBowls);
                write.Close();
                OutputFile.Close();
            }
            else
            {
                Console.WriteLine("Sorry, can't find file to read from.");
            }


            

            
                                
        }

        /*public static IEnumerable<SuperBowl> getHighScores(List<SuperBowl> listOfSuperBowls)
        {
            var getHighScores=
                from score in listOfSuperBowls
                where score > 40
                orderby score.Winn

            return getHighScores;
        }*/


        static void ObjectCreator(string adjustedFilePath, ref List<SuperBowl> listOfSuperBowls)
        {
            
            string[] arrayOfValues;
            FileStream InputFile = new FileStream(adjustedFilePath, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(InputFile);
            while (!read.EndOfStream)
            {
                try
                {
                    arrayOfValues = read.ReadLine().Split(',');
                    listOfSuperBowls.Add(new SuperBowl(arrayOfValues[0], arrayOfValues[1], Int32.Parse(arrayOfValues[2]), arrayOfValues[3], arrayOfValues[4],
                        arrayOfValues[5], Int32.Parse(arrayOfValues[6]), arrayOfValues[7], arrayOfValues[8], arrayOfValues[9], Int32.Parse(arrayOfValues[10]), arrayOfValues[11], arrayOfValues[12], arrayOfValues[13], arrayOfValues[14]));

                    Console.WriteLine(arrayOfValues[13]);
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
            
            write.WriteLine("All super bowl winners");
            write.WriteLine();
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
                             group superBowl by superBowl.City into cityGroup
                             where cityGroup.Count() > 2
                             orderby cityGroup.Key
                             select cityGroup;

            foreach (SuperBowl superBowl in groupQuery) {
                write.WriteLine(superBowl.City);
            }
        }
    }
}
