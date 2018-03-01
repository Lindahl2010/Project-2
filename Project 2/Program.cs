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
            string userInput;

            readInData();

        }//End of Main Method

        public static void readInData()//Reads in data from the designated project 2 .csv file
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
            catch (Exception i)
            {
                WriteLine(i.Message);
            }

            //Writes the data to the text file using queries
            writeData(superbowls);
            ReadLine();

        }

        public static void writeData(List<SBList> superbowls)
        {

            FileStream file = new FileStream("SuperBowl.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            int date, x, z;

            try
            {

                //Prints out all super bowl winners but is not correctly ordering by date
                var SBWinners =
                    from team in superbowls
                    select new { team.date, team.winner, team.QBWinner, team.coachWinner, team.MVP, team.ptDiff };

                writer.WriteLine("Super Bowl Winners");
                writer.WriteLine("\n");
                writer.WriteLine("\n{0,-5}{1,-25}{2,-30}{3,-20}{4,-30}{5,-30}", "Year", "Team", "QB", "Coach", "MVP", "Point Diff");
                writer.WriteLine("\n");

                foreach (var team in SBWinners)
                {
                    date = team.date.Length;
                    x = date - 2;
                    writer.WriteLine("\n{0,-5}{1,-25}{2,-30}{3,-20}{4,-30}{5,-30}", team.date.Remove(0,x), team.winner, team.QBWinner, team.coachWinner, team.MVP, team.ptDiff);
                }
                writer.WriteLine("\n");

                //Prints the top five attended super bowls ordered by attendance
                var topFive =
                    from team in superbowls
                    where team.attendance > 100000
                    orderby team.attendance descending
                    select new { team.date, team.winner, team.loser, team.city, team.state, team.stadium };

                writer.WriteLine("Top Five Attended Super Bowl's");
                writer.WriteLine("\n");
                writer.WriteLine("\n{0,-3}{1,-10}{2,-25}{3,-25}{4,-15}{5,-15}{6,-25}","#", "Year", "Winning Team", "Losing Team", "City", "State", "Stadium");
                writer.WriteLine("\n");

                z = 0;
                foreach(var team in topFive)
                {
                    date = team.date.Length;
                    x = date - 2;
                    z += 1;
                    writer.WriteLine("\n{0,-3}{1,-10}{2,-25}{3,-25}{4,-15}{5,-15}{6,-25}", z + ")", team.date.Remove(0,x), team.winner, team.loser, team.city, team.state, team.stadium);
                }
                writer.WriteLine("\n");

                //Figure out how to find which state has hosted the most Super Bowl's 
                var host =
                    from team in superbowls
                    select new { team.city, team.state, team.stadium };

                var group = superbowls.GroupBy(superbowl => superbowl.state).Where(superbowl => superbowl.Count() > 12).Select(superbowl => superbowl.Key);

                writer.WriteLine("State that hosted the Most Super Bowls");
                writer.WriteLine("\n");
                writer.WriteLine("\n{0,-15}{1,-30}{2,-30}", "City", "State", "Stadium");
                writer.WriteLine("\n");

                foreach (var state in group)
                {
                    writer.WriteLine("{0,-15}", state);
                }
                writer.WriteLine("\n");

                //Figure out how to find items repeated more than once 
                var MVP1 =
                    from team in superbowls
                    where team.date != null
                    select new { team.MVP, team.winner, team.loser };

                var MVP = superbowls.GroupBy(superbowl => superbowl.MVP).Where(superbowl => superbowl.Count() > 1).Select(superbowl => superbowl.Key);

                writer.WriteLine("Players to receive MVP 2 or more times");
                writer.WriteLine("\n");
                writer.WriteLine("\n{0,-20}{1,-30}{2,-30}", "MVP", "Winning Team", "Losing Team");
                writer.WriteLine("\n");

                foreach (var dupName in MVP)
                {
                    writer.WriteLine("{0,-20}", dupName);
                }
                writer.WriteLine("\n");

                writer.WriteLine("Coach's that lost the most Super Bowl's");
                writer.WriteLine("\n");
                writer.WriteLine("Name");
                writer.WriteLine("\n");

                var lost = superbowls.GroupBy(superbowl => superbowl.coachLoser).Where(superbowl => superbowl.Count() == 4).Select(superbowl => superbowl.Key);

                foreach (var coach in lost)
                {
                    writer.WriteLine(coach);
                }
                writer.WriteLine("\n");

                writer.WriteLine("Coach to win the most Super Bowl's");
                writer.WriteLine("\n");
                writer.WriteLine("Name");
                writer.WriteLine("\n");

                var won = superbowls.GroupBy(superbowl => superbowl.coachWinner).Where(superbowl => superbowl.Count() > 4).Select(superbowl => superbowl.Key);

                foreach(var coach in won)
                {
                    writer.WriteLine(coach);
                }
                writer.WriteLine("\n");

                writer.WriteLine("Team(s) to win the most Super Bowl's");
                writer.WriteLine("\n");
                writer.WriteLine("Team");
                writer.WriteLine("\n");

                var winner = superbowls.GroupBy(superbowl => superbowl.winner).Where(superbowl => superbowl.Count() > 5).Select(superbowl => superbowl.Key);

                foreach(var wins in winner)
                {
                    writer.WriteLine(wins);
                }
                writer.WriteLine("\n");

                writer.WriteLine("Team(s) to lose the most Super Bowl's");
                writer.WriteLine("\n");
                writer.WriteLine("Team");
                writer.WriteLine("\n");

                var loser = superbowls.GroupBy(superbowl => superbowl.loser).Where(superbowl => superbowl.Count() > 4).Select(superbowl => superbowl.Key);

                foreach(var losses in loser)
                {
                    writer.WriteLine(losses);
                }
                writer.WriteLine("\n");

                var points =
                    from team in superbowls
                    where team.ptDiff > 40
                    select new { team.ptDiff, team.SB, team.winner, team.loser };

                writer.WriteLine("Superbowl with the greatest point difference");
                writer.WriteLine("\n");
                writer.WriteLine("{0,-15}{1,-15}{2,-30}{3,-30}", "Super Bowl", "Pt. Diff.", "Winning Team", "Losing Team");
                writer.WriteLine("\n");

                foreach(var team in points)
                {
                    writer.WriteLine("{0,-15}{1,-15}{2,-30}{3,-30}", team.SB, team.ptDiff.ToString(), team.winner, team.loser);
                }
                writer.WriteLine("\n");

                var avg =
                    from team in superbowls
                    where team.attendance > 0
                    select new { team.attendance };

                writer.WriteLine("Average attendance of Super Bowl's");
                writer.WriteLine("\n");
                writer.WriteLine("Attendance");
                writer.WriteLine("\n");

                foreach(var team in superbowls)
                {

                }
            }
            catch (Exception i)
            {
                WriteLine(i.Message);
            }

            writer.Close();
            file.Close();

        }
    }//End of Program Class
}
