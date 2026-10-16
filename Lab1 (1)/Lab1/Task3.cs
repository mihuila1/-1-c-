using System; // Console, Math, Random
using System.Text; // StringBuilder

public partial class Lab1 // Задание 3. Циклы (чётные задачи: 2, 4, 6, 8, 10)
{
    // Задача 2. Числа наоборот: строка «x x-1 ... 1 0»
    public string reverseListNums(int x)
    {
        StringBuilder sb = new StringBuilder(); // StringBuilder эффективнее, чем склеивать строки в цикле
        for (int i = x; i >= 0; i--) // идём от x вниз до 0 включительно
        {
            sb.Append(i); // добавляем число
            if (i > 0) // после последнего числа пробел не нужен
                sb.Append(' '); // разделитель
        }
        return sb.ToString(); // для x < 0 цикл не выполнится, вернётся пустая строка
    }

    // Задача 4. Степень числа: x в степени y умножением в цикле
    public int pow(int x, int y)
    {
        if (y < 0) // отрицательная степень не даёт целого числа
            throw new ArgumentOutOfRangeException(nameof(y), "Степень должна быть неотрицательной.");
        int result = 1; // начинаем с единицы (x^0 = 1)
        for (int i = 0; i < y; i++) // умножаем на x ровно y раз
            result = checked(result * x); // checked: при переполнении int будет исключение, а не неверный ответ
        return result; // итоговая степень
    }

    // Задача 6. Одинаковость: true, если все цифры числа одинаковы
    public bool equalNum(int x)
    {
        long n = Math.Abs((long)x); // знак числа не важен
        int last = (int)(n % 10); // запоминаем последнюю цифру
        while (n > 0) // пока в числе остались цифры
        {
            if (n % 10 != last) // текущая последняя цифра отличается от запомненной
                return false; // числа разные — сразу false
            n /= 10; // отбрасываем последнюю цифру
        }
        return true; // все цифры совпали (или цифра одна)
    }

    // Задача 8. Левый треугольник: в i-й строке i звёздочек
    public void leftTriangle(int x)
    {
        for (int i = 1; i <= x; i++) // перебираем строки от 1 до x
            Console.WriteLine(new string('*', i)); // строка из i символов '*'
    }

    // Вспомогательный метод: правильная форма слова «попытка» после числа (за 1 попытку, 2 попытки, 5 попыток)
    private string AttemptsWord(int n)
    {
        int last2 = n % 100; // две последние цифры
        int last = n % 10; // последняя цифра
        if (last2 >= 11 && last2 <= 14) return "попыток"; // 11–14 всегда «попыток»
        if (last == 1) return "попытку"; // 1, 21, 31...
        if (last >= 2 && last <= 4) return "попытки"; // 2–4, 22–24...
        return "попыток"; // остальные случаи
    }

    // Задача 10. Угадайка: играем, пока пользователь не угадает число от 0 до 9
    public void guessGame()
    {
        Random rnd = new Random(); // генератор случайных чисел
        int secret = rnd.Next(0, 10); // загаданное число: верхняя граница 10 не включается, значит 0..9
        int attempts = 0; // счётчик попыток
        int guess; // число, введённое пользователем

        Console.WriteLine("Введите число от 0 до 9:"); // первое приглашение
        do // выполняем хотя бы один раз
        {
            guess = ReadInt("", 0, 9); // читаем число с проверкой диапазона
            attempts++; // считаем попытку
            if (guess != secret) // не угадал
                Console.WriteLine("Вы не угадали, введите число от 0 до 9:"); // подсказка
        } while (guess != secret); // повторяем, пока не угадает

        Console.WriteLine("Вы угадали!"); // сообщение об успехе
        Console.WriteLine($"Вы отгадали число за {attempts} {AttemptsWord(attempts)}"); // итог по попыткам
    }

    // ---------- Запуск заданий с интерфейсом ----------

    public void RunTask3()
    {
        while (true) // подменю работает, пока не выберут 0
        {
            Console.WriteLine("\n--- Задание 3. Циклы ---"); // заголовок
            Console.WriteLine("2 - Числа наоборот"); // пункт
            Console.WriteLine("4 - Степень числа"); // пункт
            Console.WriteLine("6 - Одинаковость"); // пункт
            Console.WriteLine("8 - Левый треугольник"); // пункт
            Console.WriteLine("10 - Угадайка"); // пункт
            Console.WriteLine("0 - Назад"); // пункт

            int choice = ReadInt("Номер задачи: ", 0, 10); // читаем номер с проверкой

            switch (choice) // выбираем задачу
            {
                case 2:
                    int x2 = ReadInt("Введите x (не меньше 0): ", 0); // верхняя граница списка
                    Console.WriteLine($"Результат: \"{reverseListNums(x2)}\""); // выводим строку
                    break;

                case 4:
                    int x4 = ReadInt("Введите x: "); // основание
                    int y4 = ReadInt("Введите y (не меньше 0): ", 0); // показатель степени
                    try // ловим переполнение int
                    {
                        Console.WriteLine($"Результат: {pow(x4, y4)}"); // выводим степень
                    }
                    catch (OverflowException) // результат не помещается в int
                    {
                        Console.WriteLine("Ошибка: результат слишком большой для типа int."); // сообщение
                    }
                    break;

                case 6:
                    int x6 = ReadInt("Введите число: "); // читаем число
                    Console.WriteLine($"Результат: {equalNum(x6).ToString().ToLower()}"); // true/false строчными
                    break;

                case 8:
                    int x8 = ReadInt("Введите высоту (не меньше 1): ", 1); // высота треугольника
                    leftTriangle(x8); // метод сам печатает треугольник
                    break;

                case 10:
                    guessGame(); // запускаем игру
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
