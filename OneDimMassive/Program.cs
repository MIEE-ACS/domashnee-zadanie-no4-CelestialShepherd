using System;

namespace OneDimMassive
{
    class Program
    {
        //Функция, выводящая интерфейс и массив
        static void PrintInterface(double[] mas)
        {
            Console.Write("Массив: [|");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(" {0:0.00} |", mas[i]);
            }
            Console.Write("]");
            Console.WriteLine("\r\nВведите команду:\r\n1)Вывести максимальный элемент массива.\r\n2)Сумму элементов массива, расположенных до последнего положительного элемента.\r\n3)Сжать массив, удалив из него элементы, модуль которых входит в введённый интервал.\r\n4)Выход.");
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
        //Функция, проверяющая ввод на положительное число
        static int InputPosNumber(int input)
        {
            if (input > 0)
            {
                return input;
            }
            else
            {
                Console.Write("Некорректный ввод. Вы ввели отрицательное число или 0.\r\nВвод: ");
                return InputPosNumber(InputIntNumber(Console.ReadLine()));
            }
        }
        //Функция, находящая максимальный элемент массива
        static void FindMax(double[] mas)
        {
            double max = mas[0];
            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                }
            }
            Console.WriteLine($"Максимальный элемент: {max}");
        }
        //Функция, выводящая сумму элементов массива, расположенных до последнего положительного элемента
        static void PrintSumBeforeLastPositive(double[] mas)
        {
            double sum = 0;
            int lastPosInd = -1;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0)
                {
                    lastPosInd = i;
                }
            }
            for (int i = 0; i < lastPosInd; i++)
            {
                sum += mas[i];
            }
            Console.WriteLine($"Искомая сумма: {sum}");
        }
        //Функция, сжимающая массив, удаляя из него элементы, модуль которых входит в введённый интервал.
        static void SqueezeMas(double[] mas)
        {
            double a, b;
            Console.WriteLine("Введите промежуток");
            Console.Write("Левая граница(а): ");
            a = InputDoubleNumber(Console.ReadLine());
            Console.Write("Правая граница(b, причём a < b): ");
            do
            {
                b = InputDoubleNumber(Console.ReadLine());
                if (a >= b)
                {
                    Console.WriteLine("Ошибка! Левая граница промежутка больше правой. Повторите ввод.");
                    b = a - 1;
                }
            } while (a >= b);
            for (int i = 0; i < mas.Length; i++)
            {
                if (Math.Abs(mas[i]) >= a && Math.Abs(mas[i]) <= b)
                {
                    mas[i] = 0;
                }
            }
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = 0; j < mas.Length - 1 - i; j++)
                {
                    if (mas[j] == 0)
                    {
                        mas[j] = mas[j + 1];
                        mas[j + 1] = 0;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            bool flag = true;
            int n, com;
            Random rnd = new Random();
            Console.Write("Укажите размер массива: ");
            n = InputPosNumber(InputIntNumber(Console.ReadLine()));
            double[] mas = new double[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = Math.Round(rnd.NextDouble()*10 - 5,2);
            }
            while (flag)
            {
                PrintInterface(mas);
                Console.Write("Введите команду: ");
                com = InputIntNumber(Console.ReadLine());
                switch (com)
                {
                    case 1:
                        FindMax(mas);
                        break;
                    case 2:
                        PrintSumBeforeLastPositive(mas);
                        break;
                    case 3:
                        SqueezeMas(mas);
                        break;
                    case 4:
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
