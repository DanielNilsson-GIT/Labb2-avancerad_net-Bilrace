using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_avancerad_net_Bilrace
{
    internal class ThemeSong
    {
        //Funkar ej/används ej
       public static void Note(int freq, int duration)
        {
            if (freq == 0)
                Thread.Sleep(duration);
            else
                Console.Beep(freq, duration);
        }

        public static void Play()
        {
            // William Tell Overture (förenklad "galopp"-del)

            int q = 150; // baseline tempo

            Note(659, q); Note(659, q); Note(659, q);
            Note(659, q); Note(659, q); Note(659, q);

            Note(659, q); Note(784, q); Note(523, q); Note(587, q);
            Note(659, q);

            Note(0, q);

            Note(659, q); Note(784, q); Note(523, q); Note(587, q);
            Note(659, q);

            Note(0, q);

            // snabb galoppsektion
            Note(659, q / 2);
            Note(659, q / 2);
            Note(659, q / 2);
            Note(659, q / 2);

            Note(659, q);
            Note(587, q);
            Note(659, q);
            Note(784, q);

            Note(880, q);
            Note(784, q);
            Note(659, q);
            Note(587, q);
            Note(523, q);

            Console.WriteLine("🎵 Done!");
        }
    }
}
