using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class SuperBowl
    {
        public string Date { get; set; }
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

        //Default Constructor
        public SuperBowl()
        {

        }

        public SuperBowl(string Date, string SuperBowlRomanNumeral, int Attendance
            , string WinningQuarterback, string WinningCoach, string WinningTeamName, 
            int WinningTeamPoints, string LosingQuarterback, string LosingCoach, string LosingTeamName
            , int LosingTeamPoints, string MVP, string Stadium, string State)
        {
            this.Date = Date;
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

        }

        public override string ToString()
        {
            return String.Format("Date: {0} \nSuper Bowl Number: {1} \nAttendance: {2} \nWinning Quarterback: {3} \nWinning Coach: {4}\nWinning Team: {5}\n", Date, SuperBowlRomanNumeral, Attendance, WinningQuarterback, WinningCoach, WinningTeamName);
        }

        public string SuperBowlWinners()
        {
            return String.Format("Team name: {0} Year: {1} Winning Quarterback: {2} Winning Coach: {3} MVP: {4} Point Difference: {5}", WinningTeamName,
                Date, WinningQuarterback, WinningCoach, MVP, (WinningTeamPoints - LosingTeamPoints));
        }


    }
}
