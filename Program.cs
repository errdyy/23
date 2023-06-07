using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        };

        Console.WriteLine("Исходный массив:");
        PrintMatrix(matrix);

        Console.WriteLine("Выберите способ сортировки:");
        Console.WriteLine("1. По строкам");
        Console.WriteLine("2. По столбцам");
        int choice = ReadIntInput("Введите номер выбранного способа: ", 1, 2);

        Console.WriteLine("Выберите направление сортировки:");
        Console.WriteLine("1. По возрастанию");
        Console.WriteLine("2. По убыванию");
        int direction = ReadIntInput("Введите номер выбранного направления: ", 1, 2);

        SortMatrix(matrix, choice, direction);

        Console.WriteLine("Отсортированный массив:");
        PrintMatrix(matrix);

        Console.ReadLine();
    }

    static void SortMatrix(int[,] matrix, int choice, int direction)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        if (choice == 1) 
        {
            for (int i = 0; i < rows; i++)
            {
                SortArray(matrix, i, 0, columns - 1, direction);
            }
        }
        else if (choice == 2) 
        {
            for (int j = 0; j < columns; j++)
            {
                SortArray(matrix, j, 0, rows - 1, direction);
            }
        }
    }

    static void SortArray(int[,] matrix, int index, int start, int end, int direction)
    {
        for (int i = start; i <= end; i++)
        {
            for (int j = i + 1; j <= end; j++)
            {
                bool compareCondition;
                if (direction == 1)
                {
                    compareCondition = matrix[index, i] > matrix[index, j];
                }
                else
                {
                    compareCondition = matrix[index, i] < matrix[index, j];
                }

                if (compareCondition)
                {
                    int temp = matrix[index, i];
                    matrix[index, i] = matrix[index, j];
                    matrix[index, j] = temp;
                }
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int ReadIntInput(string prompt, int min, int max)
    {
        int value;
        bool isValid;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out value);

            if (!isValid || value < min || value > max)
            {
                Console.WriteLine($"Введите целое число от {min} до {max}.");
                isValid = false;
            }
        } while (!isValid);

        return value;
    }
}