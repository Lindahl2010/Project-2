using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("\n");
            SBWinners();

            Write("\n");
            topFive();

        }//End of Main Method

        public static void SBWinners()
        {
            //Declarations
            const char DELIM = ',';
            const string FILE = "Super_Bowl_Project.csv";
            FileStream file = new FileStream(FILE, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            SBList superBowl = new SBList();
            string headerLine = reader.ReadLine();
            int ptDiff;
            string record;
            string[] info;

            WriteLine("Super Bowl Winners");
            WriteLine("\n{0,-10}{1,-20}{2,-20}{3,-20}{4,-30}{5,-30}", "Year", "Team", "QB", "Coach", "MVP", "Point Difference");
            record = reader.ReadLine();
            while (record != null)
            {
                info = record.Split(DELIM);
                superBowl.date = info[0];
                superBowl.winner = info[5];
                superBowl.QBWinner = info[3];
                superBowl.coachWinner = info[4];
                superBowl.MVP = info[11];
                superBowl.winPts = Convert.ToInt32(info[6]);
                superBowl.losingPts = Convert.ToInt32(info[10]);
                ptDiff = superBowl.winPts - superBowl.losingPts;
                ptDiff.ToString();
                WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}{4,-30}{5,-30}", superBowl.date, superBowl.winner, superBowl.QBWinner, superBowl.coachWinner, superBowl.MVP, ptDiff);
                record = reader.ReadLine();
            }

            reader.Close();
            file.Close();
            ReadLine();

        }

        public static void topFive()
        {
            //Declarations
            const char DELIM = ',';
            const string FILE = "Super_Bowl_Project.csv";
            FileStream file = new FileStream(FILE, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            SBList superBowl = new SBList();
            string headerLine = reader.ReadLine();
            string record;
            string[] info;

            WriteLine("Top Five Attended Super Bowl's");
            WriteLine("\n{0,-10}{1,-20}{2,-20}{3,-20}{4,-30}{5,-30}", "Year", "Winning Team", "Losing Team", "City", "State", "Stadium");
            record = reader.ReadLine();
            while (record != null)
            {
                info = record.Split(DELIM);
                superBowl.date = info[0];
                superBowl.winner = info[5];
                superBowl.loser = info[9];
                superBowl.city = info[13];
                superBowl.state = info[14];
                superBowl.stadium = info[12];
                WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}{4,-30}{5,-30}", superBowl.date, superBowl.winner, superBowl.loser, superBowl.city, superBowl.state, superBowl.stadium);
                record = reader.ReadLine();
            }

            reader.Close();
            file.Close();
            ReadLine();

        }
    }//End of Program Class
}
