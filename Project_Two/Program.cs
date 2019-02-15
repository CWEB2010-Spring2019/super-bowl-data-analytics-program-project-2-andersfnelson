using System;
using System.IO;
using System.Collections.Generic;


namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            string[] arrayOfValues;
            List<SuperBowl> listOfSuperBowls = new List<SuperBowl>();

            string filePath = Directory.GetCurrentDirectory();
            string stepBackOne = Directory.GetParent(filePath).ToString();
            string stepBackTwo = Directory.GetParent(stepBackOne).ToString();
            string stepBackThree = Directory.GetParent(stepBackTwo).ToString();
            //Console.WriteLine(stepBackThree);

            string adjustedFilePath = $@"{stepBackThree}\Super_Bowl_Project.csv";
            //Console.WriteLine(adjustedFilePath);

            if (File.Exists(adjustedFilePath))
            {
                FileStream file = new FileStream(adjustedFilePath, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(file);

                while (!read.EndOfStream)
                {
                    try
                    {
                        arrayOfValues = read.ReadLine().Split(',');
                        listOfSuperBowls.Add(new SuperBowl(arrayOfValues[0], arrayOfValues[1], Int32.Parse(arrayOfValues[2]), arrayOfValues[3], arrayOfValues[4],
                            arrayOfValues[5], Int32.Parse(arrayOfValues[6]), arrayOfValues[7], arrayOfValues[8], arrayOfValues[9], Int32.Parse(arrayOfValues[10]), arrayOfValues[11], arrayOfValues[12], arrayOfValues[13]));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                read.Close();
                file.Close();
            }
            else
            {
                Console.WriteLine("can't find file");
            }

            
            listOfSuperBowls.ForEach(i => Console.WriteLine(i.ToString()));
        }
    }
}
