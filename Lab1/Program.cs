using System; // Console, StringSplitOptions и т.д.

public partial class Lab1 // главный класс Lab1 (partial — класс собирается из 5 файлов: Program.cs и Task1–Task4)
{
    // Читает целое число с проверкой. min/max — допустимые границы (по умолчанию без ограничений)
    private int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true) // повторяем, пока не получим корректный ввод
        {
            Console.Write(prompt); // выводим приглашение
            // TryParse не бросает исключение: возвращает true, если строка — целое число
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value; // число корректно и входит в границы — возвращаем его
            if (min == int.MinValue && max == int.MaxValue) // границы не заданы
                Console.WriteLine("Ошибка: нужно ввести целое число."); // обычное сообщение
            else // границы заданы
                Console.WriteLine($"Ошибка: нужно ввести целое число от {min} до {max}."); // сообщение с диапазоном
        }
    }

    // Читает ровно один символ
    private char ReadChar(string prompt)
    {
        while (true) // повторяем до корректного ввода
        {
            Console.Write(prompt); // приглашение
            string s = Console.ReadLine(); // читаем строку (может быть null)
            if (s != null && s.Length == 1) // проверяем, что введён ровно один символ
                return s[0]; // возвращаем этот символ
            Console.WriteLine("Ошибка: нужно ввести ровно один символ."); // сообщение об ошибке
        }
    }

    // Читает непустую строку
    private string ReadString(string prompt)
    {
        while (true) // повторяем до непустого ввода
        {
            Console.Write(prompt); // приглашение
            string s = Console.ReadLine(); // читаем строку
            if (!string.IsNullOrWhiteSpace(s)) // проверяем, что строка не пустая и не из одних пробелов
                return s.Trim(); // убираем лишние пробелы по краям и возвращаем
            Console.WriteLine("Ошибка: строка не должна быть пустой."); // сообщение об ошибке
        }
    }

    // Читает массив целых чисел из одной строки (разделители: пробел, запятая, точка с запятой)
    private int[] ReadIntArray(string prompt)
    {
        while (true) // повторяем до корректного ввода
        {
            Console.Write(prompt); // приглашение
            string line = Console.ReadLine(); // читаем всю строку
            if (!string.IsNullOrWhiteSpace(line)) // строка не пустая
            {
                // режем строку на части по разделителям, пустые части отбрасываем
                string[] parts = line.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                int[] result = new int[parts.Length]; // массив для чисел той же длины
                bool ok = true; // флаг «все части — числа»
                for (int i = 0; i < parts.Length; i++) // перебираем части
                {
                    if (!int.TryParse(parts[i], out result[i])) // пробуем превратить часть в число
                    {
                        ok = false; // нашли не число
                        break; // дальше проверять нет смысла
                    }
                }
                if (ok) // все части оказались числами
                    return result; // возвращаем массив
            }
            Console.WriteLine("Ошибка: введите целые числа через пробел, например: 1 2 3"); // сообщение об ошибке
        }
    }

    // Превращает массив в строку вида [1, 2, 3]
    private string ArrayToString(int[] arr)
    {
        return "[" + string.Join(", ", arr) + "]"; // Join склеивает элементы через ", "
    }

    public static void Main(string[] args) // метод, с которого начинается выполнение программы
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // вывод в UTF-8 (русские буквы)
        Console.InputEncoding = System.Text.Encoding.UTF8; // ввод в UTF-8 (чтобы читать русские слова, например «четверг»)

        Lab1 lab = new Lab1(); // создаём объект класса, т.к. методы не static

        while (true) // главное меню работает, пока пользователь не выберет выход
        {
            Console.WriteLine("\n===== ЛАБОРАТОРНАЯ РАБОТА №1 ====="); // заголовок
            Console.WriteLine("1 - Задание 1 (Методы)"); // пункт меню
            Console.WriteLine("2 - Задание 2 (Условия)"); // пункт меню
            Console.WriteLine("3 - Задание 3 (Циклы)"); // пункт меню
            Console.WriteLine("4 - Задание 4 (Массивы)"); // пункт меню
            Console.WriteLine("0 - Выход"); // пункт меню

            int choice = lab.ReadInt("Ваш выбор: ", 0, 4); // читаем выбор с проверкой диапазона 0..4

            switch (choice) // вызываем нужное задание
            {
                case 1: lab.RunTask1(); break; // задание 1
                case 2: lab.RunTask2(); break; // задание 2
                case 3: lab.RunTask3(); break; // задание 3
                case 4: lab.RunTask4(); break; // задание 4
                case 0: // выход
                    Console.WriteLine("До свидания!"); // прощание
                    return; // завершаем Main, а значит и программу
            }
        }
    }
}
