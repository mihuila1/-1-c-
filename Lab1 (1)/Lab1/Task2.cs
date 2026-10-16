using System; // Console, Math

public partial class Lab1 // Задание 2. Условия (чётные задачи: 2, 4, 6, 8, 10)
{
    // Задача 2. Безопасное деление: при делении на 0 возвращаем 0
    public double safeDiv(int x, int y)
    {
        if (y == 0) // проверяем делитель
            return 0; // делить на ноль нельзя — возвращаем 0, как требует условие
        return (double)x / y; // приводим x к double, чтобы деление было дробным, а не целочисленным
    }

    // Задача 4. Строка сравнения: «5 < 7», «8 > -1», «4 == 4»
    public string makeDecision(int x, int y)
    {
        if (x < y) // первое меньше
            return x + " < " + y; // склеиваем числа и знак
        if (x > y) // первое больше
            return x + " > " + y; // склеиваем числа и знак
        return x + " == " + y; // остался случай равенства
    }

    // Задача 6. Тройная сумма: любые два числа в сумме дают третье
    public bool sum3(int x, int y, int z)
    {
        long a = x, b = y, c = z; // long защищает от переполнения при сложении
        return a + b == c // первое + второе = третье
            || a + c == b // первое + третье = второе
            || b + c == a; // второе + третье = первое
    }

    // Задача 8. Возраст: число + слово «год» / «года» / «лет»
    public string age(int x)
    {
        int n = Math.Abs(x); // работаем с модулем числа
        int last2 = n % 100; // две последние цифры
        int last = n % 10; // последняя цифра
        string word; // здесь будет нужное слово
        if (last2 >= 11 && last2 <= 14) // 11, 12, 13, 14 (и 111–114 и т.д.) — всегда «лет»
            word = "лет";
        else if (last == 1) // заканчивается на 1 (кроме 11)
            word = "год";
        else if (last >= 2 && last <= 4) // заканчивается на 2, 3, 4 (кроме 12–14)
            word = "года";
        else // все остальные случаи
            word = "лет";
        return x + " " + word; // число, пробел, слово
    }

    // Задача 10. Вывод дней недели: от указанного дня до воскресенья (через switch)
    public void printDays(string x)
    {
        string[] days = { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" }; // все дни по порядку
        int start; // индекс дня, с которого начинаем вывод
        switch (x.Trim().ToLower()) // приводим к нижнему регистру и убираем пробелы по краям
        {
            case "понедельник": start = 0; break; // индекс 0
            case "вторник": start = 1; break; // индекс 1
            case "среда": start = 2; break; // индекс 2
            case "четверг": start = 3; break; // индекс 3
            case "пятница": start = 4; break; // индекс 4
            case "суббота": start = 5; break; // индекс 5
            case "воскресенье": start = 6; break; // индекс 6
            default: start = -1; break; // не день недели
        }

        if (start == -1) // строка не распознана
        {
            Console.WriteLine("это не день недели"); // сообщение по условию
            return; // выходим из метода
        }

        for (int i = start; i < days.Length; i++) // от выбранного дня до конца недели
            Console.WriteLine(days[i]); // выводим название дня
    }

    // ---------- Запуск заданий с интерфейсом ----------

    public void RunTask2()
    {
        while (true) // подменю работает, пока не выберут 0
        {
            Console.WriteLine("\n--- Задание 2. Условия ---"); // заголовок
            Console.WriteLine("2 - Безопасное деление"); // пункт
            Console.WriteLine("4 - Строка сравнения"); // пункт
            Console.WriteLine("6 - Тройная сумма"); // пункт
            Console.WriteLine("8 - Возраст"); // пункт
            Console.WriteLine("10 - Вывод дней недели"); // пункт
            Console.WriteLine("0 - Назад"); // пункт

            int choice = ReadInt("Номер задачи: ", 0, 10); // читаем номер с проверкой

            switch (choice) // выбираем задачу
            {
                case 2:
                    int x2 = ReadInt("Введите x: "); // делимое
                    int y2 = ReadInt("Введите y: "); // делитель
                    Console.WriteLine($"Результат: {safeDiv(x2, y2)}"); // результат деления
                    break;

                case 4:
                    int x4 = ReadInt("Введите x: "); // первое число
                    int y4 = ReadInt("Введите y: "); // второе число
                    Console.WriteLine($"Результат: \"{makeDecision(x4, y4)}\""); // строка сравнения
                    break;

                case 6:
                    int x6 = ReadInt("Введите x: "); // первое число
                    int y6 = ReadInt("Введите y: "); // второе число
                    int z6 = ReadInt("Введите z: "); // третье число
                    Console.WriteLine($"Результат: {sum3(x6, y6, z6).ToString().ToLower()}"); // true/false строчными
                    break;

                case 8:
                    int x8 = ReadInt("Введите возраст: ", 0); // возраст не может быть отрицательным
                    Console.WriteLine($"Результат: \"{age(x8)}\""); // «5 лет», «31 год» и т.п.
                    break;

                case 10:
                    string day = ReadString("Введите день недели: "); // читаем строку
                    printDays(day); // метод сам выводит результат
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
