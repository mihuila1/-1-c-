using System; // Console, Math

public partial class Lab1 // Задание 1. Методы (чётные задачи: 2, 4, 6, 8, 10)
{
    // Задача 2. Сумма знаков: сумма двух последних цифр числа
    public int sumLastNums(int x)
    {
        long n = Math.Abs((long)x); // модуль числа в long (чтобы не было проблем с отрицательными и int.MinValue)
        return (int)(n % 10 + (n / 10) % 10); // n%10 — последняя цифра, (n/10)%10 — предпоследняя
    }

    // Задача 4. Есть ли позитив: true, если число положительное
    public bool isPositive(int x)
    {
        return x > 0; // ноль не положительный, поэтому строго больше нуля
    }

    // Задача 6. Большая буква: true, если символ от 'A' до 'Z'
    public bool isUpperCase(char x)
    {
        return x >= 'A' && x <= 'Z'; // символы сравниваются по кодам
    }

    // Задача 8. Делитель: true, если одно из чисел делит другое нацело
    public bool isDivisor(int a, int b)
    {
        if (a == 0 || b == 0) // на ноль делить нельзя
            return false; // считаем, что в этом случае делителя нет
        return a % b == 0 || b % a == 0; // остаток от деления равен 0 в любую сторону
    }

    // Задача 10. Многократный вызов: сумма цифр разряда единиц двух чисел
    public int lastNumSum(int a, int b)
    {
        // последняя цифра a плюс последняя цифра b (модуль — чтобы знак не мешал)
        return (int)(Math.Abs((long)a) % 10 + Math.Abs((long)b) % 10);
    }

    // ---------- Запуск заданий с интерфейсом ----------

    public void RunTask1()
    {
        while (true) // подменю работает, пока не выберут 0
        {
            Console.WriteLine("\n--- Задание 1. Методы ---"); // заголовок
            Console.WriteLine("2 - Сумма знаков"); // пункт
            Console.WriteLine("4 - Есть ли позитив"); // пункт
            Console.WriteLine("6 - Большая буква"); // пункт
            Console.WriteLine("8 - Делитель"); // пункт
            Console.WriteLine("10 - Многократный вызов"); // пункт
            Console.WriteLine("0 - Назад"); // пункт

            int choice = ReadInt("Номер задачи: ", 0, 10); // читаем номер с проверкой

            switch (choice) // выбираем задачу
            {
                case 2:
                    int x2;
                    do // повторяем, пока число не будет иметь минимум две цифры
                    {
                        x2 = ReadInt("Введите число (не менее двух цифр): "); // читаем число
                        if (Math.Abs((long)x2) < 10) // в числе меньше двух цифр
                            Console.WriteLine("Ошибка: в числе должно быть минимум две цифры."); // сообщение
                    } while (Math.Abs((long)x2) < 10); // условие повтора
                    Console.WriteLine($"Результат: {sumLastNums(x2)}"); // выводим результат
                    break;

                case 4:
                    int x4 = ReadInt("Введите число: "); // читаем число
                    Console.WriteLine($"Результат: {isPositive(x4).ToString().ToLower()}"); // true/false строчными
                    break;

                case 6:
                    char c = ReadChar("Введите символ: "); // читаем символ
                    Console.WriteLine($"Результат: {isUpperCase(c).ToString().ToLower()}"); // true/false строчными
                    break;

                case 8:
                    int a8 = ReadInt("Введите a: "); // первое число
                    int b8 = ReadInt("Введите b: "); // второе число
                    Console.WriteLine($"Результат: {isDivisor(a8, b8).ToString().ToLower()}"); // true/false строчными
                    break;

                case 10:
                    // используем минимум переменных: result хранит текущую сумму, next — очередное число
                    int result = ReadInt("Введите 1-е число: "); // первое число становится начальным результатом
                    for (int i = 2; i <= 5; i++) // берём ещё четыре числа (всего пять)
                    {
                        int next = ReadInt($"Введите {i}-е число: "); // читаем очередное число
                        Console.Write($"{result}+{next} это "); // печатаем начало строки вида «5+11 это »
                        result = lastNumSum(result, next); // складываем цифры разряда единиц
                        Console.WriteLine(result); // печатаем результат шага
                    }
                    Console.WriteLine($"Итого {result}"); // итоговый результат
                    break;

                case 0:
                    return; // выходим в главное меню

                default:
                    Console.WriteLine("Эта задача не входит в чётные — выберите 2, 4, 6, 8 или 10."); // подсказка
                    break;
            }
        }
    }
}
