using System;
using System.Diagnostics;

class QuickSort
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

    static void QuickSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            QuickSortAlgorithm(arr, low, pivotIndex - 1);
            QuickSortAlgorithm(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            comparisonCount++;
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        movementCount++;
    }

    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr = GenerateRandomArray(10000, 0, 1000);
        Console.WriteLine("Array antes da ordenação:");
        PrintArray(arr);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        QuickSortAlgorithm(arr, 0, arr.Length - 1);

        stopwatch.Stop();
        Console.WriteLine("Array após a ordenação:");
        PrintArray(arr);

        Console.WriteLine("Tempo de execução: " + stopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Número de comparações: " + comparisonCount);
        Console.WriteLine("Número de movimentações: " + movementCount);
    }
}
