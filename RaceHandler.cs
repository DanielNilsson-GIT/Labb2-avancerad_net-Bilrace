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
        public static double raceDistance { get; } = 500;

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
                        if (!winners.Contains(raceCar))
                        {
                            winners.Add(raceCar);

                        }
                        raceBegun = false;
                        if (winners.Count == 4)
                        {

                            raceOver = true;
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
            Console.WriteLine("“That was intense! Here is the result:”");
            Console.WriteLine($"“In 4th place…{result[3].name}”\r\n “In 3rd place…{result[2].name}”\r\n “In 2nd place…{result[1].name}”\r\n“And your winner is…{result[0].name}!”");
            Console.ReadKey();

        }

    }
}
