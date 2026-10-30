using System;
using System.Text;

namespace Lab1
{
    /// <summary>
    /// Лабораторная работа №1. Чётный вариант (задачи 2, 4, 6, 8, 10 из каждого задания).
    /// Все решения собраны в одном классе. Сигнатуры методов соответствуют заданию.
    /// </summary>
    public class Lab1Tasks
    {
        
        public int sumLastNums(int x)
        {
            int last = Math.Abs(x % 10);          
            int prev = Math.Abs((x / 10) % 10);   
            return last + prev;
        }

        
        public bool isPositive(int x)
        {
            return x > 0;
        }

        
        public bool isUpperCase(char x)
        {
            return x >= 'A' && x <= 'Z';
        }

        
        public bool isDivisor(int a, int b)
        {
            
            if (a != 0 && (long)b % a == 0) return true;
            if (b != 0 && (long)a % b == 0) return true;
            return false;
        }

        
        public int lastNumSum(int a, int b)
        {
            return Math.Abs(a % 10) + Math.Abs(b % 10);
        }

        
        public void lastNumSumChain(int[] nums)
        {
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                Console.Write(result + "+" + nums[i] + " это ");
                result = lastNumSum(result, nums[i]);
                Console.WriteLine(result);
            }
            Console.WriteLine("Итого " + result);
        }

        
        public double safeDiv(int x, int y)
        {
            if (y == 0)
            {
                return 0;
            }
            return (double)x / y;
        }

        
        public string makeDecision(int x, int y)
        {
            if (x > y)
            {
                return x + " > " + y;
            }
            if (x < y)
            {
                return x + " < " + y;
            }
            return x + " == " + y;
        }

        
        public bool sum3(int x, int y, int z)
        {
            return x + y == z || x + z == y || y + z == x;
        }

        
        public string age(int x)
        {
            int n = Math.Abs(x % 100);
            int d = n % 10;
            string word;

            if (n >= 11 && n <= 14)
            {
                word = "лет";
            }
            else if (d == 1)
            {
                word = "год";
            }
            else if (d >= 2 && d <= 4)
            {
                word = "года";
            }
            else
            {
                word = "лет";
            }
            return x + " " + word;
        }

        
        public void printDays(string x)
        {
            if (x == null)
            {
                x = "";
            }

            switch (x.Trim().ToLower())
            {
                case "понедельник":
                    Console.WriteLine("понедельник");
                    goto case "вторник";
                case "вторник":
                    Console.WriteLine("вторник");
                    goto case "среда";
                case "среда":
                    Console.WriteLine("среда");
                    goto case "четверг";
                case "четверг":
                    Console.WriteLine("четверг");
                    goto case "пятница";
                case "пятница":
                    Console.WriteLine("пятница");
                    goto case "суббота";
                case "суббота":
                    Console.WriteLine("суббота");
                    goto case "воскресенье";
                case "воскресенье":
                    Console.WriteLine("воскресенье");
                    break;
                default:
                    Console.WriteLine("это не день недели");
                    break;
            }
        }

        
        public string reverseListNums(int x)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = x; i >= 0; i--)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }
                sb.Append(i);
            }
            return sb.ToString();
        }

        
        public int pow(int x, int y)
        {
            if (y < 0)
            {
                throw new ArgumentException("Степень должна быть неотрицательной.");
            }

            int result = 1;
            checked 
            {
                for (int i = 0; i < y; i++)
                {
                    result *= x;
                }
            }
            return result;
        }

        
        public bool equalNum(int x)
        {
            long n = Math.Abs((long)x);
            long digit = n % 10;

            while (n > 0)
            {
                if (n % 10 != digit)
                {
                    return false;
                }
                n /= 10;
            }
            return true;
        }

        
        public void leftTriangle(int x)
        {
            for (int row = 1; row <= x; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        
        public void guessGame()
        {
            Random rnd = new Random();
            int secret = rnd.Next(0, 10);
            int attempts = 0;
            bool guessed = false;

            Console.WriteLine("Введите число от 0 до 9:");
            while (!guessed)
            {
                string line = Console.ReadLine();
                int number;

                if (!int.TryParse(line, out number) || number < 0 || number > 9)
                {
                    Console.WriteLine("Ошибка ввода! Введите целое число от 0 до 9:");
                    continue; 
                }

                attempts++;
                if (number == secret)
                {
                    guessed = true;
                    Console.WriteLine("Вы угадали!");
                }
                else
                {
                    Console.WriteLine("Вы не угадали, введите число от 0 до 9:");
                }
            }

            Console.WriteLine("Вы отгадали число за " + attempts + " " + attemptsWord(attempts));
        }

        
        private string attemptsWord(int n)
        {
            int m = n % 100;
            int d = n % 10;
            if (m >= 11 && m <= 14) return "попыток";
            if (d == 1) return "попытку";
            if (d >= 2 && d <= 4) return "попытки";
            return "попыток";
        }

        
        public int findLast(int[] arr, int x)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        
        public int[] add(int[] arr, int x, int pos)
        {
            if (pos < 0 || pos > arr.Length)
            {
                throw new ArgumentOutOfRangeException("pos", "Позиция вне допустимого диапазона.");
            }

            int[] result = new int[arr.Length + 1];
            for (int i = 0; i < pos; i++)
            {
                result[i] = arr[i];
            }
            result[pos] = x;
            for (int i = pos; i < arr.Length; i++)
            {
                result[i + 1] = arr[i];
            }
            return result;
        }

        
        public void reverse(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int tmp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = tmp;
            }
        }

        
        public int[] concat(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result[arr1.Length + i] = arr2[i];
            }
            return result;
        }

        
        public int[] deleteNegative(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    result[k] = arr[i];
                    k++;
                }
            }
            return result;
        }
    }
}
