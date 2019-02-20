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
                

                var SuperBowlQuery = from SuperBowl in listOfSuperBowls
                                     where SuperBowl.Attendance > 100000
                                     orderby SuperBowl.SuperBowlNumber  //Format query
                                     select SuperBowl;
                write.WriteLine("Superbowls with attendance greater than 100000");
                foreach(SuperBowl superBowl in SuperBowlQuery)
                {
                    write.WriteLine(superBowl.ToString());
                }

                write.WriteLine("All superbowls");
                foreach(SuperBowl superBowl in listOfSuperBowls)
                {
                    write.WriteLine(superBowl.SuperBowlWinners());
                }


                write.WriteLine("query2");
                var query2 = from SuperBowl in listOfSuperBowls
                             orderby SuperBowl.Attendance descending
                             select SuperBowl;
                foreach(SuperBowl SuperBowl in query2)
                {
                    write.Write(SuperBowl.ToString());
                    write.WriteLine();
                }
                write.Close();
                OutputFile.Close();
            }
            else
            {
                Console.WriteLine("can't find file");
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
                        arrayOfValues[5], Int32.Parse(arrayOfValues[6]), arrayOfValues[7], arrayOfValues[8], arrayOfValues[9], Int32.Parse(arrayOfValues[10]), arrayOfValues[11], arrayOfValues[12], arrayOfValues[13]));


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
    }
}
