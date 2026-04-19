using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_avancerad_net_Bilrace
{
    internal class Run

    {
        public static Car raceCar1 = new Car();
        public static Car raceCar2 = new Car();
        public static Car raceCar3 = new Car();
        public static Car raceCar4 = new Car();
        public static void RunRace()
        {


            raceCar1.name = "Greased Lightning";
            raceCar2.name = "Mad Max";
            raceCar3.name = "RoadRunner";
            raceCar4.name = "Mario";


            Console.WriteLine("Welcome to .NET Grand Prix!\n Press any key to start the race!");
            Console.ReadKey();
            Console.WriteLine("3...2...1 GO!");

            //Trådar för bilar
            Thread car_one = new Thread(RaceHandler.StartCar);

            Thread car_two = new Thread(RaceHandler.StartCar);

            Thread car_three = new Thread(RaceHandler.StartCar);

            Thread car_four = new Thread(RaceHandler.StartCar);


            car_one.Start(raceCar1);
            Console.WriteLine(raceCar1.name + " is off!");
            car_two.Start(raceCar2);
            Console.WriteLine(raceCar2.name + " away!");
            car_three.Start(raceCar3);
            Console.WriteLine(raceCar3.name + " leaves a trail of dust behind!");
            car_four.Start(raceCar4);
            Console.WriteLine(raceCar4.name + "'s tires schreehes as he goes!");


            //tråd för userInput
            Thread userlistener = new Thread(StatusUpdate);
            userlistener.IsBackground = true;
            userlistener.Start();
        }
        public static void StatusUpdate()
        {
            Car[] carArray = new Car[] { raceCar1, raceCar2, raceCar3, raceCar4 };
            while (!RaceHandler.raceOver)
            {

                if (Console.KeyAvailable == true)//kollar ifall en tangent har tryckts likt console.readkey förutom att den inte pausar loopen. om en tangent är tryckt blir den true
                {
                    Console.ReadKey();//läser av tangent som trycks och tar bort den ur minnet.


                    Console.WriteLine("Current status:");
                    foreach (var car in carArray)
                    {

                        Console.WriteLine($"{car.name} " +
                            $"Distance driven: {Math.Round(car.distance)} Meters. " +
                            $"Current speed: {car.speed} Km/h");

                    }
                }
                    Thread.Sleep(50); //för att hålla nere CPU-användning. Annars körs den miljontals ggr/sekund

            }

        }

    }
}

