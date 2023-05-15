using System;

class SelectionSort
{
    static void Main()
    {
        int[] arr = { 64, 25, 12, 22, 11 };
        Console.WriteLine("Array antes da ordenação:");
        PrintArray(arr);

        SelectionSortAlgorithm(arr);

        Console.WriteLine("Array após a ordenação:");
        PrintArray(arr);
    }

    static void SelectionSortAlgorithm(int[] arr)
    {
        int n = arr.Length;

        // Itera através de todos os elementos do array
        for (int i = 0; i < n - 1; i++)
        {
            // Encontra o elemento mínimo no array não ordenado
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }

            // Troca o elemento mínimo encontrado com o primeiro elemento não ordenado
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
