using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_avancerad_net_Bilrace
{
    internal class Car
    {
        private static int Counter = 0;
        int Id { get; set; } = 0;
        public double speed { get; set; }

        public string name { get; set; }

        public double distance { get; set; }

        public int trackPos { get; set; } //används ej i nuläget... tänkte ha till att rita ut grafik


        public Car()
        {
            Id = ++Counter;
            speed = 120;
            distance = 0;
            trackPos = Id + 10;


        }
    }
}
