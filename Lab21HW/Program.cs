using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21HW
{
    class Program
    {
        static int[,] garden;
        static int a;
        static int b;
        static object Loker = new object();

        static void Main(string[] args)
        {
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            garden = new int[a, b];

            Thread sadov1 = new Thread(Sad1);
            Thread sadov2 = new Thread(Sad2);

            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();


            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public static void Sad1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }
            }

        }
        public static void Sad2()
        {
            for (int i = b-1; i >0; i--)
            {
                for (int j = a-1; j >0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(1);
                }
            }

        }

    }
}



//    Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
//    Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
//    Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо,
//    сделав ряд, он спускается вниз. 
//    Второй садовник начинает работу с нижнего правого угла сада
//    и перемещается снизу вверх, сделав ряд, он перемещается влево. Если садовник видит, 
//    что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
//    Создать многопоточное приложение, моделирующее работу садовников.


