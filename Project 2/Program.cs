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
            readInData();

        }//End of Main Method

        public static void SBWinners(List<SBList> superbowls)
        {

            var SBQuery =
                from team in superbowls
                where team.attendance > 0 
                orderby team.date
                select new { team.date, team.winner, team.QBWinner, team.coachWinner, team.MVP, team.ptDiff };

            
            WriteLine("Super Bowl Winners");
            WriteLine("\n{0,-15}{1,-30}{2,-30}{3,-20}{4,-30}{5,-30}", "Year", "Team", "QB", "Coach", "MVP", "Point Diff");
            foreach (var team in SBQuery)
            {
                WriteLine("{0,-15}{1,-30}{2,-30}{3,-20}{4,-30}{5,-30}", team.date, team.winner, team.QBWinner, team.coachWinner, team.MVP, team.ptDiff);
            }
        }

        public static void topFive(List<SBList> superbowls)
        {
            var SBQuery =
                from team in superbowls
                where team.attendance > 0
                orderby team.attendance descending
                select new { team.date, team.winner, team.loser, team.city, team.state, team.stadium };

            WriteLine("Top Five Attended Super Bowl's");
            WriteLine("\n{0,-15}{1,-30}{2,-30}{3,-20}{4,-30}{5,-30}", "Year", "Winning Team", "Losing Team", "City", "State", "Stadium");
            foreach (var team in SBQuery)
            {
                WriteLine("{0,-15}{1,-30}{2,-30}{3,-20}{4,-30}{5,-30}", team.date, team.winner, team.loser, team.city, team.state, team.stadium);
            }
        }

        public static void host(List<SBList> superbowls)
        {
            //Figure out how to find which state has hosted the most Super Bowl's 
            var SBQuery =
                from team in superbowls
                where team.attendance > 103700
                orderby team.SB
                select new { team.city, team.state, team.stadium };

            WriteLine("State that hosted the Most Super Bowls");
            WriteLine("\n{0,-15}{1,-30}{2,-30}", "City", "State", "Stadium");
            foreach(var team in SBQuery)
            {
                WriteLine("\n{0,-15}{1,-30}{2,-30}", team.city, team.state, team.stadium);
            }
        }

        public static void MVP(List<SBList> superbowls)
        {
            //Figure out how to find items repeated more than once 
            var SBQuery =
                from team in superbowls
                where team.date != null
                orderby team.SB
                select new { team.MVP, team.winner, team.loser };

            WriteLine("Players to receive MVP 2 or more times");
            WriteLine("\n{0,-15}{1,-30}{2,-30}", "MVP", "Winning Team", "Losing Team");
            foreach(var team in SBQuery)
            {
                WriteLine("\n{0,-15}{1,-30}{2,-30}", team.MVP, team.winner, team.loser);
            }
        }



        public static void readInData()
        {
            //Declarations
            const char DELIM = ',';
            const string FILE = "Super_Bowl_Project.csv";
            List<SBList> superbowls = new List<SBList>();
            SBList listSuperBowls;
            string[] info;


            try
            {
                FileStream file = new FileStream(FILE, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    info = reader.ReadLine().Split(DELIM);
                    listSuperBowls = new SBList(info[0], info[1], Convert.ToInt32(info[2]), info[3], info[4], info[5], Convert.ToInt32(info[6]), info[7], info[8], info[9], Convert.ToInt32(info[10]), info[11], info[12], info[13], info[14]);
                    superbowls.Add(listSuperBowls);
                }

                reader.Close();
                file.Close();

            }
            catch(Exception i)
            {
                WriteLine(i.Message);
            }
            
            SBWinners(superbowls);
            ReadLine();
            topFive(superbowls);
            ReadLine();

        }

        public static void Top()
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
            WriteLine("\n{0,-15}{1,-30}{2,-30}{3,-20}{4,-30}{5,-30}", "Year", "Winning Team", "Losing Team", "City", "State", "Stadium");
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
                WriteLine("{0,-15}{1,-30}{2,-30}{3,-20}{4,-30}{5,-30}", superBowl.date, superBowl.winner, superBowl.loser, superBowl.city, superBowl.state, superBowl.stadium);
                record = reader.ReadLine();
            }

            reader.Close();
            file.Close();
            ReadLine();

        }
    }//End of Program Class
}
