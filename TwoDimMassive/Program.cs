using System;

namespace TwoDimMassive
{
    class Program
    {
        //Функция, выводящая интерфейс и массив
        static void PrintInterface(double[,] mas, int n)
        {
            Console.WriteLine("\r\nМатрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("| {0,5} |", mas[i, j]);
                }
                Console.Write("\r\n");
            }
            Console.WriteLine("Введите команду:\r\n1)Вывести сумму элементов в тех столбцах, которые не содержат отрицательных элементов.\r\n2)Вывести минимум среди сумм модулей элементов диагоналей, параллельных побочной диагонали матрицы.\r\n3)Выход.");
        }
        //Функция, проверяющая ввод на целое число
        static int InputIntNumber(string input)
        {
            int num;
            if (int.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                Console.Write("Ошибка! Была введена строка или дробное число. Попробуйте ещё раз.\r\nВвод: ");
                return InputIntNumber(Console.ReadLine());
            }
        }
        //Функция, проверяющая ввод на вещественное число
        static double InputDoubleNumber(string input)
        {
            double num;
            if (double.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                Console.Write("Ошибка! Была введена строка. Попробуйте ещё раз.\r\nВвод: ");
                return InputDoubleNumber(Console.ReadLine());
            }
        }
        //Функция, проверяющая содержит ли указанный столбец отрицаетльные элементы
        static bool HasNegative(double[,] mas, int n, int k)
        {
            for (int i = 0; i < n; i++)
            {
                if (mas[i, k] < 0)
                {
                    return true;
                }
            }
            return false;
        }
        //Функция, возвращающая суммы элементов в столбцах, которые не содержат отрицательных чисел
        static void PrintSumsOfPosCol(double[,] mas, int n)
        {
            double sum;
            Console.WriteLine("Список сумм:");
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                if (!HasNegative(mas,n,i))
                {
                    for (int j = 0; j < n; j++)
                    {
                        sum += mas[j, i];
                    }
                    Console.WriteLine("Столбец №{0,2}: {1:0.00}", i + 1, sum);
                }
            }
        }
        //Функция находящая минимум среди сумм модулей элементов диагоналей, параллельных побочной диагонали матрицы
        static void PrintMinSumOfDiag(double[,] mas, int n)
        {
            double sum, min;
            double[] sums = new double[2*n-1];
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = i; j >= 0; j--)
                {
                    sum += Math.Abs(mas[i - j, j]);
                }
                sums[i] = sum; 
            }
            for (int i = n; i < 2*n-1; i++)
            {
                sum = 0;
                for (int j = i - n + 1; j < n; j++)
                {
                    sum += Math.Abs(mas[i-j, j]);
                }
                sums[i] = sum;
            }
            min = sums[0]; Console.Write("Все суммы: {0:0.00} ",sums[0]);
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] < min)
                {
                    min = sums[i];
                }
                Console.Write("{0:0.00} ", sums[i]);
            }
            Console.WriteLine("\r\nНайденный минимум составляет: {0:0.00}", min);
        }

        static void Main(string[] args)
        {
            bool flag = true;
            int n, com;
            Random rnd = new Random();
            Console.Write("Укажите размерность квадратной матрицы: ");
            n = InputIntNumber(Console.ReadLine());
            double[,] mas = new double[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i,j] = Math.Round(rnd.NextDouble()*10-5, 2);
                }
            }
            while (flag)
            {
                PrintInterface(mas,n);
                Console.Write("Введите команду: ");
                com = InputIntNumber(Console.ReadLine());
                switch (com)
                {
                    case 1:
                        PrintSumsOfPosCol(mas, n);
                        break;
                    case 2:
                        PrintMinSumOfDiag(mas, n);
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка! Отсутствует команда под введённым номером. Попробуйте ещё раз.");
                        break;
                }
            }
        }
    }
}
