namespace SortTest;
using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class SortTest
{
    static readonly int DATA_LENGTH = 20;
    static void Main()
    {
        int[] array = new int[DATA_LENGTH];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, DATA_LENGTH+1);
        }

        int[] bubbleSortArray = (int[])array.Clone();
        int[] selectionSortArray = (int[])array.Clone();
        int[] quickSortArray = (int[])array.Clone();
        int[] systemSortArray = (int[])array.Clone();

        // Bubble Sort
        Console.WriteLine("Proccessing start");
        Stopwatch sw = Stopwatch.StartNew();
        BubbleSort(bubbleSortArray);
        sw.Stop();
        Console.WriteLine($"BubbleSort:\t {TicksToMs(sw)} ms");

        // Selection Sort
        sw.Restart();
        SelectionSort(selectionSortArray);
        sw.Stop();
        Console.WriteLine($"SelectionSort:\t {TicksToMs(sw)} ms");

        // Quick Sort
        sw.Restart();
        QuickSort(quickSortArray, 0, quickSortArray.Length - 1);
        sw.Stop();
        Console.WriteLine($"QuickSort:\t {TicksToMs(sw)} ms");

        // Array Sort
        sw.Restart();
        Array.Sort(systemSortArray);
        sw.Stop();
        Console.WriteLine($"Array.Sort:\t {TicksToMs(sw)} ms");
    }

    static string TicksToMs(Stopwatch sw)
    {
        return ((double)sw.ElapsedTicks / Stopwatch.Frequency).ToString("N10");
    }

    static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            bool isSwapped = false;
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    isSwapped = true;
                }
            }
            if (!isSwapped)
            {
                break;
            }
        }
    }

    static void SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);
            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = (low - 1);
        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;
        return i + 1;

    }
}

