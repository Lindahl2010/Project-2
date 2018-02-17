using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            string record;
            string[] info;

        }
    }
}
