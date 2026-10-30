using System;
using System.Text;

namespace Lab1
{
    internal class Program
    {
        private static readonly Lab1Tasks tasks = new Lab1Tasks();

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Лабораторная работа №1 (чётный вариант) ===");
                Console.WriteLine("1 - Задание 1. Методы");
                Console.WriteLine("2 - Задание 2. Условия");
                Console.WriteLine("3 - Задание 3. Циклы");
                Console.WriteLine("4 - Задание 4. Массивы");
                Console.WriteLine("0 - Выход");

                int choice = ReadInt("Выберите задание: ", 0, 4);
                if (choice == 0)
                {
                    Console.WriteLine("До свидания!");
                    return;
                }

                switch (choice)
                {
                    case 1: Part1(); break;
                    case 2: Part2(); break;
                    case 3: Part3(); break;
                    case 4: Part4(); break;
                }
            }
        }

        // ------------------------------------------------------------------
        // Задание 1
        // ------------------------------------------------------------------
        private static void Part1()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 1. Методы ---");
            Console.WriteLine("2  - Сумма знаков");
            Console.WriteLine("4  - Есть ли позитив");
            Console.WriteLine("6  - Большая буква");
            Console.WriteLine("8  - Делитель");
            Console.WriteLine("10 - Многократный вызов");
            Console.WriteLine("0  - Назад");

            int n = ReadChoice(new int[] { 0, 2, 4, 6, 8, 10 });
            switch (n)
            {
                case 2:
                    {
                        int x = ReadInt("Введите число (не менее двух знаков): ");
                        Console.WriteLine("Результат: " + tasks.sumLastNums(x));
                        break;
                    }
                case 4:
                    {
                        int x = ReadInt("Введите число: ");
                        Console.WriteLine("Результат: " + tasks.isPositive(x));
                        break;
                    }
                case 6:
                    {
                        char c = ReadChar("Введите один символ: ");
                        Console.WriteLine("Результат: " + tasks.isUpperCase(c));
                        break;
                    }
                case 8:
                    {
                        int a = ReadInt("Введите a: ");
                        int b = ReadInt("Введите b: ");
                        Console.WriteLine("Результат: " + tasks.isDivisor(a, b));
                        break;
                    }
                case 10:
                    {
                        int[] nums = ReadIntArray("Введите пять чисел через пробел: ", 5);
                        tasks.lastNumSumChain(nums);
                        break;
                    }
            }
        }

        // ------------------------------------------------------------------
        // Задание 2
        // ------------------------------------------------------------------
        private static void Part2()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 2. Условия ---");
            Console.WriteLine("2  - Безопасное деление");
            Console.WriteLine("4  - Строка сравнения");
            Console.WriteLine("6  - Тройная сумма");
            Console.WriteLine("8  - Возраст");
            Console.WriteLine("10 - Вывод дней недели");
            Console.WriteLine("0  - Назад");

            int n = ReadChoice(new int[] { 0, 2, 4, 6, 8, 10 });
            switch (n)
            {
                case 2:
                    {
                        int x = ReadInt("Введите x: ");
                        int y = ReadInt("Введите y: ");
                        Console.WriteLine("Результат: " + tasks.safeDiv(x, y));
                        break;
                    }
                case 4:
                    {
                        int x = ReadInt("Введите x: ");
                        int y = ReadInt("Введите y: ");
                        Console.WriteLine("Результат: \"" + tasks.makeDecision(x, y) + "\"");
                        break;
                    }
                case 6:
                    {
                        int x = ReadInt("Введите x: ");
                        int y = ReadInt("Введите y: ");
                        int z = ReadInt("Введите z: ");
                        Console.WriteLine("Результат: " + tasks.sum3(x, y, z));
                        break;
                    }
                case 8:
                    {
                        int x = ReadInt("Введите возраст: ");
                        Console.WriteLine("Результат: \"" + tasks.age(x) + "\"");
                        break;
                    }
                case 10:
                    {
                        Console.Write("Введите название дня недели (например, четверг): ");
                        string day = Console.ReadLine();
                        Console.WriteLine("Результат:");
                        tasks.printDays(day);
                        break;
                    }
            }
        }

        // ------------------------------------------------------------------
        // Задание 3
        // ------------------------------------------------------------------
        private static void Part3()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 3. Циклы ---");
            Console.WriteLine("2  - Числа наоборот");
            Console.WriteLine("4  - Степень числа");
            Console.WriteLine("6  - Одинаковость");
            Console.WriteLine("8  - Левый треугольник");
            Console.WriteLine("10 - Угадайка");
            Console.WriteLine("0  - Назад");

            int n = ReadChoice(new int[] { 0, 2, 4, 6, 8, 10 });
            switch (n)
            {
                case 2:
                    {
                        int x = ReadInt("Введите x (x >= 0): ", 0, int.MaxValue);
                        Console.WriteLine("Результат: \"" + tasks.reverseListNums(x) + "\"");
                        break;
                    }
                case 4:
                    {
                        int x = ReadInt("Введите основание x: ");
                        int y = ReadInt("Введите степень y (y >= 0): ", 0, int.MaxValue);
                        try
                        {
                            Console.WriteLine("Результат: " + tasks.pow(x, y));
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Результат не помещается в тип int (переполнение).");
                        }
                        break;
                    }
                case 6:
                    {
                        int x = ReadInt("Введите число: ");
                        Console.WriteLine("Результат: " + tasks.equalNum(x));
                        break;
                    }
                case 8:
                    {
                        int x = ReadInt("Введите высоту треугольника (x >= 1): ", 1, 100);
                        tasks.leftTriangle(x);
                        break;
                    }
                case 10:
                    {
                        tasks.guessGame();
                        break;
                    }
            }
        }

        // ------------------------------------------------------------------
        // Задание 4
        // ------------------------------------------------------------------
        private static void Part4()
        {
            Console.WriteLine();
            Console.WriteLine("--- Задание 4. Массивы ---");
            Console.WriteLine("2  - Поиск последнего значения");
            Console.WriteLine("4  - Добавление в массив");
            Console.WriteLine("6  - Реверс");
            Console.WriteLine("8  - Объединение");
            Console.WriteLine("10 - Удалить негатив");
            Console.WriteLine("0  - Назад");

            int n = ReadChoice(new int[] { 0, 2, 4, 6, 8, 10 });
            switch (n)
            {
                case 2:
                    {
                        int[] arr = ReadIntArray("Введите элементы массива через пробел: ");
                        int x = ReadInt("Введите искомое число x: ");
                        Console.WriteLine("Результат: " + tasks.findLast(arr, x));
                        break;
                    }
                case 4:
                    {
                        int[] arr = ReadIntArray("Введите элементы массива через пробел: ");
                        int x = ReadInt("Введите вставляемое значение x: ");
                        int pos = ReadInt("Введите позицию (0.." + arr.Length + "): ", 0, arr.Length);
                        Console.WriteLine("Результат: " + ArrayToString(tasks.add(arr, x, pos)));
                        break;
                    }
                case 6:
                    {
                        int[] arr = ReadIntArray("Введите элементы массива через пробел: ");
                        tasks.reverse(arr);
                        Console.WriteLine("Результат: arr=" + ArrayToString(arr));
                        break;
                    }
                case 8:
                    {
                        int[] arr1 = ReadIntArray("Введите элементы первого массива через пробел: ");
                        int[] arr2 = ReadIntArray("Введите элементы второго массива через пробел: ");
                        Console.WriteLine("Результат: " + ArrayToString(tasks.concat(arr1, arr2)));
                        break;
                    }
                case 10:
                    {
                        int[] arr = ReadIntArray("Введите элементы массива через пробел: ");
                        Console.WriteLine("Результат: " + ArrayToString(tasks.deleteNegative(arr)));
                        break;
                    }
            }
        }

        // ------------------------------------------------------------------
        // Вспомогательные методы ввода с проверкой
        // ------------------------------------------------------------------

        /// <summary>Читает номер пункта подменю, допуская только значения из списка.</summary>
        private static int ReadChoice(int[] allowed)
        {
            while (true)
            {
                Console.Write("Выберите номер задачи: ");
                int value;
                if (int.TryParse(Console.ReadLine(), out value) && Array.IndexOf(allowed, value) >= 0)
                {
                    return value;
                }
                Console.WriteLine("Ошибка ввода! Выберите один из пунктов меню.");
            }
        }

        
        private static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                int value;
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine("Ошибка ввода! Введите целое число" +
                    (min != int.MinValue || max != int.MaxValue ? " от " + min + " до " + max : "") + ".");
            }
        }

        
        private static char ReadChar(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();
                if (line != null && line.Length == 1)
                {
                    return line[0];
                }
                Console.WriteLine("Ошибка ввода! Нужно ввести ровно один символ.");
            }
        }

        
        private static int[] ReadIntArray(string prompt, int expectedLength = -1)
        {
            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();
                string[] parts = (line ?? "").Split(new char[] { ' ', ',', ';' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0 || (expectedLength > 0 && parts.Length != expectedLength))
                {
                    Console.WriteLine(expectedLength > 0
                        ? "Ошибка ввода! Нужно ввести ровно " + expectedLength + " чисел."
                        : "Ошибка ввода! Массив не должен быть пустым.");
                    continue;
                }

                int[] result = new int[parts.Length];
                bool ok = true;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (!int.TryParse(parts[i], out result[i]))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    return result;
                }
                Console.WriteLine("Ошибка ввода! Все элементы должны быть целыми числами.");
            }
        }

        
        private static string ArrayToString(int[] arr)
        {
            return "[" + string.Join(", ", arr) + "]";
        }
    }
}
