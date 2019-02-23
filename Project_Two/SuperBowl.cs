using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class SuperBowl
    {

        public DateTime Date { get; set; }
        public int Attendance { get; set; }
        public string SuperBowlRomanNumeral { get; set; }
        public int SuperBowlNumber { get; set; }
        public string City { get; set;}
        public string State { get; set; }
        public string Stadium { get; set; }
        public string WinningTeamName { get; set; }
        public string LosingTeamName { get; set; }
        public string WinningQuarterback { get; set; }
        public string LosingQuarterback { get; set; }
        public string WinningCoach { get; set; }
        public string LosingCoach { get; set; }
        public string MVP { get; set; }
        public int WinningTeamPoints { get; set; }
        public int LosingTeamPoints { get; set; }
        public int PointDifference { get; set; }

        //Default Constructor
        public SuperBowl()
        {

        }

        //Overloaded constructor
        public SuperBowl(string Date, string SuperBowlRomanNumeral, int Attendance
            , string WinningQuarterback, string WinningCoach, string WinningTeamName, 
            int WinningTeamPoints, string LosingQuarterback, string LosingCoach, string LosingTeamName
            , int LosingTeamPoints, string MVP, string Stadium, string City, string State)
        {
            this.Date = Convert.ToDateTime(Date);
            this.SuperBowlRomanNumeral = SuperBowlRomanNumeral;
            this.Attendance = Attendance;
            this.WinningQuarterback = WinningQuarterback;
            this.WinningCoach = WinningCoach;
            this.WinningTeamName = WinningTeamName;
            this.WinningTeamPoints = WinningTeamPoints;
            this.LosingQuarterback = LosingQuarterback;
            this.LosingCoach = LosingCoach;
            this.LosingTeamPoints = LosingTeamPoints;
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.State = State;
            this.City = City;
            this.LosingTeamName = LosingTeamName;
            this.PointDifference = WinningTeamPoints - LosingTeamPoints;
            

        }

        
        //Is this right?
        
        
        public override string ToString()
        {
            return String.Format("Date: {0} \nSuper Bowl Number: {1} \nAttendance: {2} \nWinning Quarterback: {3} \nWinning Coach: {4}\nWinning Team: {5}\n", Date.Year, SuperBowlRomanNumeral, Attendance, WinningQuarterback, WinningCoach, WinningTeamName);
        }
        

        //To string method for first LINQ query
        public string SuperBowlWinners()
        {
            return String.Format("Team name: {0,-20}".PadRight(20) +"Year: {1, -10}".PadRight(10)+ "Winning Quarterback: {2,-30}".PadRight(30) +"Winning Coach: {3, -20}".PadRight(20)+ "MVP: {4, -25}".PadRight(25) +"Point Difference: {5, -10}".PadRight(10), WinningTeamName,
                Date.Year, WinningQuarterback, WinningCoach, MVP, (WinningTeamPoints - LosingTeamPoints));
        }

        //To string method for second query

        public string TopFiveAttended()
        {
            return String.Format("Date: {0,-20}".PadRight(20) + "Winning Team: {1, -25}".PadRight(25) + "Losing Team: {2, -20}".PadRight(20) + "City: {3, -20}".PadRight(20) + "State: {4, -20}".PadRight(20) + "Stadium: {5, -20}".PadRight(20), 
                Date, WinningTeamName, LosingTeamName, City, State, Stadium);
        }
        public string HighestState()
        {
            return String.Format("City: {0,-20}".PadRight(20) + "State: {1, -20}".PadRight(20) + "Stadium: {2, -20}".PadRight(20), City, State, Stadium);
        }

        public string MVPWriter()
        {
            return String.Format("Winning team: {0,-20} ".PadRight(20) + "Losing team: {1,-20}".PadRight(20), WinningTeamName, LosingTeamName);
        }


    }
}
