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

            WriteLine("\n{0,-10}{1,-20}{2,-20}{3,-20}{4,-30}{5,-30}", "Year", "Team", "QB", "Coach", "MVP", "Point Difference");
            record = reader.ReadLine();
            while(record != null)
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

        }//End of Main Method
    }//End of Program Class
}
