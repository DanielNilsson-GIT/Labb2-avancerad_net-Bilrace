using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_avancerad_net_Bilrace
{
    internal class RaceHandler
    {

        public static bool raceOver = false;
        public static List<Car> winners { get; set; } = new List<Car>();
        public static double raceDistance { get; } = 5000;

        public static object lockobject = new object();
        public RaceHandler()
        {

        }



        public static void StartCar(Object car)
        {
            Car raceCar = (Car)car; //För att thread ska kunna använda metoden så måste jag tydligen använda ett "generiskt" object. därav omvandling. 

            

            bool raceBegun = true;
            RaceHandler track = new RaceHandler();
            int counter = 0;

            while (raceBegun) //Loop för att köra bilen och beta av sträckan
            {
                counter++;
                if (counter == 10)
                {
                    int diceRoll = Problems.ProbabilityCalculator();
                    double delay = Problems.RaceProblems(raceCar, diceRoll);

                    if (delay == (1 / 3.6))
                    {
                        raceCar.speed = raceCar.speed - delay;
                    }
                    else
                    {
                        Thread.Sleep((int)delay);

                    }
                    counter = 0;

                }

                if (raceCar.distance >= raceDistance)
                {
                    lock (lockobject)//lock för att endast en tråd ska ha tillgång till listan åt gången
                    {
                        
                        
                            winners.Add(raceCar);
                        if (winners[0] == raceCar)
                        {
                            Console.WriteLine($"{raceCar.name} Won the race!");
                        }
                        else
                        {
                            Console.WriteLine($"{raceCar.name} Crosses the finishline!");
                        }


                            raceBegun = false;//racebegun styr varje bil
                        if (winners.Count == 4)
                        {

                            raceOver = true; //raceOver styr hela loppet. dödar "status-update"-tråden
                            announceWinner(winners);
                        }
                    }
                    break;

                }
                raceCar.distance = raceCar.distance + (raceCar.speed / 3.6);
                Thread.Sleep(1000);
            }

        }



        public static void announceWinner(List<Car> result)
        {
            Console.WriteLine("\n");
            Console.WriteLine("“That was intense! Here is the result:”");
            Console.WriteLine($"In 4th place…{result[3].name}\nIn 3rd place…{result[2].name}\nIn 2nd place…{result[1].name}\nAnd your winner is…{result[0].name}!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

    }
}
