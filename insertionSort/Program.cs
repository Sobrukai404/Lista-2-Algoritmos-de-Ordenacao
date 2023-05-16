using System;
using System.Diagnostics;

class InsertionSort
{
    static int comparisonCount = 0;
    static int movementCount = 0;

    static int[] GenerateRandomArray(int length, int min, int max)
    {
        Random random = new Random();
        int[] arr = new int[length];
        for (int i = 0; i < length; i++)
        {
            arr[i] = random.Next(min, max + 1);
        }
        return arr;
    }

    static void InsertionSortAlgorithm(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                comparisonCount++;
                arr[j + 1] = arr[j];
                j--;
                movementCount++;
            }

            arr[j + 1] = key;
            movementCount++;
        }
    }

    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = GenerateRandomArray(10000, 0, 1000);
        Console.WriteLine("Array antes da ordenação:");
        PrintArray(arr);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        InsertionSortAlgorithm(arr);

        stopwatch.Stop();
        Console.WriteLine("Array após a ordenação:");
        PrintArray(arr);

        Console.WriteLine("Tempo de execução: " + stopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Número de comparações: " + comparisonCount);
        Console.WriteLine("Número de movimentações: " + movementCount);
    }
}
