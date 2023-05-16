using System;
using System.Diagnostics;

class MergeSort
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

    static void MergeSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSortAlgorithm(arr, low, mid);
            MergeSortAlgorithm(arr, mid + 1, high);
            Merge(arr, low, mid, high);
        }
    }

    static void Merge(int[] arr, int low, int mid, int high)
    {
        int leftLength = mid - low + 1;
        int rightLength = high - mid;

        int[] leftArr = new int[leftLength];
        int[] rightArr = new int[rightLength];

        for (int i = 0; i < leftLength; i++)
        {
            leftArr[i] = arr[low + i];
        }

        for (int j = 0; j < rightLength; j++)
        {
            rightArr[j] = arr[mid + 1 + j];
        }

        int leftIndex = 0;
        int rightIndex = 0;
        int mergedIndex = low;

        while (leftIndex < leftLength && rightIndex < rightLength)
        {
            comparisonCount++;
            if (leftArr[leftIndex] >= rightArr[rightIndex])
            {
                arr[mergedIndex] = leftArr[leftIndex];
                leftIndex++;
            }
            else
            {
                arr[mergedIndex] = rightArr[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
            movementCount++;
        }

        while (leftIndex < leftLength)
        {
            arr[mergedIndex] = leftArr[leftIndex];
            leftIndex++;
            mergedIndex++;
            movementCount++;
        }

        while (rightIndex < rightLength)
        {
            arr[mergedIndex] = rightArr[rightIndex];
            rightIndex++;
            mergedIndex++;
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

        MergeSortAlgorithm(arr, 0, arr.Length - 1);

        stopwatch.Stop();
        Console.WriteLine("Array após a ordenação:");
        PrintArray(arr);

        Console.WriteLine("Tempo de execução: " + stopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Número de comparações: " + comparisonCount);
        Console.WriteLine("Número de movimentações: " + movementCount);
    }
}
