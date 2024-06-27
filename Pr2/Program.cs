using System;

namespace Pr2
{
    class Program
    {
        const int N = 10 + 1;

        static void Main(string[] args)
        {
            Task1();
            // Task2();
            // Task3();
            // Task4();
        }
        
        //---Task1---
        static void Task1()
        {
            int[] numbers = { 4, 6, 12 };

            Console.Write("Numbers: [ ");
            foreach (int elem in numbers)
            {
                Console.Write($"{elem} ");
            }

            Console.WriteLine("]");

            Console.Write($"Numbers that are in range of [1;{N}]: [ ");
            foreach (int elem in numbers)
            {
                if (elem >= 1 && elem <= N)
                {
                    Console.Write($"{elem} ");
                }
            }

            Console.WriteLine("]");
        }
        
        //---Task2---
        static void Task2()
        {
            int side1 = 8;
            int side2 = 7;
            int side3 = 12;

            if (IsTriangle(side1, side2, side3))
            {
                double area = Area(side1, side2, side3);
                int perimeter = Perimeter(side1, side2, side3);
                string triangleType = TriangleType(side1, side2, side3);

                Console.WriteLine($"Perimeter of triangle: {perimeter}");
                Console.WriteLine($"Area of triangle: {area}");
                Console.WriteLine($"Type of triangle: {triangleType}");
            }
            else
            {
                Console.WriteLine("Triangle doesn't exist.");
            }

           

            static bool IsTriangle(int side1, int side2, int side3)
            {
                return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
            }

            static int Perimeter(int side1, int side2, int side3)
            {
                return side1 + side2 + side3;
            }

            static double Area(int side1, int side2, int side3)
            {
                double s = (side1 + side2 + side3) / 2.0;
                return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));

            }

            static string TriangleType(int side1, int side2, int side3)
            {
                if (side1 == side2 && side2 == side3)
                {
                    return "Equilateral";
                }

                if (side1 == side2 || side1 == side3 || side2 == side3)
                {
                    return "Isosceles";
                }

                return "Scalene";
            }
        }
        
        //---Task3---
        static void Task3()
        {
            int[] x = new int[N];

            Random rng = new Random();
            
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rng.Next(0, 100);
            }

            int max = x[0];
            int min = x[0];

            foreach (int elem in x)
            {
                if (elem > max)
                {
                    max = elem;
                }

                if (elem < min)
                {
                    min = elem;
                }
            }

            Console.Write("Array: [ ");
            foreach (int elem in x)
            {
                Console.Write($"{elem} ");
            }

            Console.WriteLine("]");

            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
        
        //---Task4---
        static void Task4()
        {
            int[] x = new int[N];
            Random rng = new Random();
            
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rng.Next(-100, 100);
            }

            Console.Write("Array X: ");
            PrintArray(x);

            Console.Write("Enter M number: ");
            int m = int.Parse(Console.ReadLine());

            int ySize = 0;

            foreach (int elem in x)
            {
                if (Math.Abs(elem) > m)
                {
                    ySize++;
                }
            }

            int[] y = new int[ySize];
            int yIndex = 0;

            foreach (int elem in x)
            {
                if (Math.Abs(elem) > m)
                {
                    y[yIndex] = elem;
                    yIndex++;
                }
            }
            
            Console.Write("Array Y: ");
            PrintArray(y);
            Console.WriteLine("(Array Y contains numbers from array X which abs is greater then number M)");

            static void PrintArray(int[] arr)
            {
                Console.Write("[ ");
                foreach (int elem in arr)
                {
                    Console.Write($"{elem} ");
                }

                Console.WriteLine("]");
            }

        }

    }
}

