using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_avancerad_net_Bilrace
{
    //Gör de olika "status-texterna" till variabler. 
    //Gör varje hinder till threadsleep. 
    internal class Problems
    {
        //Händelse	Sannolikhet	Effekt
        //Slut på bensin	1/50	Behöver tanka, stannar 15 sekunder
        //Punktering	2/50	Behöver byta däck, stannar 10 sekunder
        //Fågel på vindrutan	5/50	Behöver tvätta vindrutan, stannar 5 sekunder
        //Motorfel	10/50	Hastigheten på bilen sänks med 1 km/h

        static bool outOfGas = false;
        static bool flatTire = false;
        static bool birdOnWindShield = false;
        static bool motorFailure = false;
       
        

        
        public static int ProbabilityCalculator()
        {
            Random raceEvent = new Random();
            var diceRoll = raceEvent.Next(1,51);
            return diceRoll;
        }

   

        public static double RaceProblems(Car racecar,int roll)
        {
           
            //returnerar milisekunder eller sekunder
            if (roll == 1)
            {
                
                    Console.WriteLine($"{racecar.name} Is out of gas! Refilling...");
                return 15000;
            }
            else if (roll <= 3) // 2–3
            {
                    Console.WriteLine($"{racecar.name} got a flat! Changing tire...");
                return 10000;
            }
            else if (roll <= 8) // 4–8
            {
                    Console.WriteLine($"Splash! A bird crashed the windshield! Need to wash {racecar.name}");
                return 5000;
            }
            else if (roll <= 18) // 9–18
            {
                
                    Console.WriteLine($"{racecar.name} Got a motor error, speed lowered by 1Kmh/h");
                return (1 / 3.6);
            }
            else
            {
                return 0;
                // inget händer
            }
  

        }

      


       

    }
}
