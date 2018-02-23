using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class SBList
    {
        public string date { get; set; }
        public string SB { get; set; }
        public int attendance { get; set; }
        public string QBWinner { get; set; }
        public string coachWinner { get; set; }
        public string winner { get; set; }
        public int winPts { get; set; }
        public string QBLoser { get; set; }
        public string coachLoser { get; set; }
        public string loser { get; set; }
        public int losingPts { get; set; }
        public string MVP { get; set; }
        public string stadium { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int ptDiff { get; set; }

        public SBList()
        {

        }

        public SBList(string date, string SB, int attendance, string QBWinner, string coachWinner, string winner, int winPts, string QBLoser, string coachLoser, string loser, int losingPts, string MVP, string stadium, string city, string state)
        {
            this.date = date;
            this.SB = SB;
            this.attendance = attendance;
            this.QBWinner = QBWinner;
            this.coachWinner = coachWinner;
            this.winner = winner;
            this.winPts = winPts;
            this.QBLoser = QBLoser;
            this.coachLoser = coachLoser;
            this.loser = loser;
            this.losingPts = losingPts;
            this.MVP = MVP;
            this.stadium = stadium;
            this.city = city;
            this.state = state;
            ptDiff = winPts - losingPts;
            ptDiff.ToString();
        }
    }
}
