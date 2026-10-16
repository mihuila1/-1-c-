using System; // Console, Math, Random, Array и т.д.
using System.Text; // StringBuilder

// Лабораторная работа №1. Всё решение — в одном классе Lab1 (чётные задачи 2, 4, 6, 8, 10 из заданий 1–4)
public class Lab1
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


    // Задача 2. Поиск последнего значения: индекс последнего вхождения x или -1
    public int findLast(int[] arr, int x)
    {
        for (int i = arr.Length - 1; i >= 0; i--) // идём с конца массива к началу
        {
            if (arr[i] == x) // нашли значение
                return i; // первое найденное с конца — и есть последнее вхождение
        }
        return -1; // значения в массиве нет
    }

    // Задача 4. Добавление в массив: новый массив со вставленным x в позицию pos
    public int[] add(int[] arr, int x, int pos)
    {
        if (pos < 0 || pos > arr.Length) // позиция должна быть от 0 до длины массива
            throw new ArgumentOutOfRangeException(nameof(pos), "Недопустимая позиция вставки.");
        int[] result = new int[arr.Length + 1]; // новый массив на один элемент длиннее
        for (int i = 0; i < pos; i++) // копируем элементы до позиции вставки
            result[i] = arr[i];
        result[pos] = x; // вставляем новое значение
        for (int i = pos; i < arr.Length; i++) // копируем оставшиеся элементы со сдвигом на 1
            result[i + 1] = arr[i];
        return result; // возвращаем новый массив
    }

    // Задача 6. Реверс: меняет исходный массив задом наперёд
    public void reverse(int[] arr)
    {
        for (int i = 0; i < arr.Length / 2; i++) // идём только до середины, иначе развернём обратно
        {
            int tmp = arr[i]; // запоминаем левый элемент
            arr[i] = arr[arr.Length - 1 - i]; // на его место ставим симметричный правый
            arr[arr.Length - 1 - i] = tmp; // а на правое место — запомненный левый
        }
    }

    // Задача 8. Объединение: сначала элементы arr1, затем arr2
    public int[] concat(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length]; // длина — сумма длин
        for (int i = 0; i < arr1.Length; i++) // копируем первый массив
            result[i] = arr1[i];
        for (int i = 0; i < arr2.Length; i++) // копируем второй массив после первого
            result[arr1.Length + i] = arr2[i];
        return result; // возвращаем объединённый массив
    }

    // Задача 10. Удалить негатив: новый массив без отрицательных элементов
    public int[] deleteNegative(int[] arr)
    {
        int count = 0; // сколько неотрицательных элементов
        for (int i = 0; i < arr.Length; i++) // первый проход: считаем
        {
            if (arr[i] >= 0) // элемент не отрицательный
                count++;
        }
        int[] result = new int[count]; // создаём массив нужного размера
        int k = 0; // позиция записи в новый массив
        for (int i = 0; i < arr.Length; i++) // второй проход: копируем
        {
            if (arr[i] >= 0) // берём только неотрицательные
            {
                result[k] = arr[i]; // записываем
                k++; // сдвигаем позицию записи
            }
        }
        return result; // возвращаем отфильтрованный массив
    }

    // ---------- Запуск заданий с интерфейсом ----------

    public void RunTask4()
    {
        while (true) // подменю работает, пока не выберут 0
        {
            Console.WriteLine("\n--- Задание 4. Массивы ---"); // заголовок
            Console.WriteLine("2 - Поиск последнего значения"); // пункт
            Console.WriteLine("4 - Добавление в массив"); // пункт
            Console.WriteLine("6 - Реверс"); // пункт
            Console.WriteLine("8 - Объединение"); // пункт
            Console.WriteLine("10 - Удалить негатив"); // пункт
            Console.WriteLine("0 - Назад"); // пункт

            int choice = ReadInt("Номер задачи: ", 0, 10); // читаем номер с проверкой

            switch (choice) // выбираем задачу
            {
                case 2:
                    int[] arr2 = ReadIntArray("Введите массив (через пробел): "); // читаем массив
                    int x2 = ReadInt("Введите искомое число: "); // что ищем
                    Console.WriteLine($"Результат: {findLast(arr2, x2)}"); // индекс или -1
                    break;

                case 4:
                    int[] arr4 = ReadIntArray("Введите массив (через пробел): "); // читаем массив
                    int x4 = ReadInt("Введите число для вставки: "); // что вставляем
                    int pos4 = ReadInt($"Введите позицию (от 0 до {arr4.Length}): ", 0, arr4.Length); // куда вставляем
                    Console.WriteLine($"Результат: {ArrayToString(add(arr4, x4, pos4))}"); // новый массив
                    break;

                case 6:
                    int[] arr6 = ReadIntArray("Введите массив (через пробел): "); // читаем массив
                    reverse(arr6); // разворачиваем на месте
                    Console.WriteLine($"Результат: {ArrayToString(arr6)}"); // массив после изменения
                    break;

                case 8:
                    int[] a1 = ReadIntArray("Введите первый массив: "); // первый массив
                    int[] a2 = ReadIntArray("Введите второй массив: "); // второй массив
                    Console.WriteLine($"Результат: {ArrayToString(concat(a1, a2))}"); // объединённый массив
                    break;

                case 10:
                    int[] arr10 = ReadIntArray("Введите массив (через пробел): "); // читаем массив
                    Console.WriteLine($"Результат: {ArrayToString(deleteNegative(arr10))}"); // без отрицательных
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
