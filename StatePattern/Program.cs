using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Father father = new Father();
            
            for (int i = 0; i < 10; i++)
            {
                
                
                

                int mark = rand.Next(1,11);
                if (mark<=5)
                {
                    Console.WriteLine($"Оценка = {mark}." + new string('-', 15));
                    father.FindOut(Mark.Bad);
                
                }
                else
                {
                    Console.WriteLine($"Оценка = {mark}." + new string('-', 15));
                    father.FindOut(Mark.Good);
                }
                
                
                Console.WriteLine(new string('-',26));
            }
        }
    }
}
