using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHandler;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler myhandler = new Handler();

            String PreMessage = "Sei einmal leiwand und ";

            Console.WriteLine(PreMessage + "gib ma an Namen:");
            String Name = Console.ReadLine();

            Console.WriteLine(PreMessage + "sag ma ob er Force-User is (true/false):");
            String ForceUser = Console.ReadLine();
            Boolean isForceUser = ForceUser == "true" ? true : false;

            Console.WriteLine(PreMessage + "sag ma zu welcher Seite er gehört (light/dark/neutral):");
            String Side = Console.ReadLine();

            Console.WriteLine(PreMessage + "sag ma von welchem Planeten er is:");
            String Planet = Console.ReadLine();

            myhandler.addCharakter(Name, isForceUser, Side, Planet);


            Console.WriteLine();
            Console.WriteLine("Super hast toll gmacht, schau bekommst a Liste als Belohnung:");
            Console.WriteLine();

            List<Charakter> charaktere = myhandler.queryCharacters();

            foreach (var charakter in charaktere)
            {
                Console.WriteLine(charakter.ToString());
            }



            Console.ReadLine();
        }
    }
}
