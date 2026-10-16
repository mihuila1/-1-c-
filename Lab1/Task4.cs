using System; // Console, Array, ArgumentOutOfRangeException

public partial class Lab1 // Задание 4. Массивы (чётные задачи: 2, 4, 6, 8, 10)
{
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
