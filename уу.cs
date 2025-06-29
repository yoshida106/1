
using System;

namespace SortingExample
{
    public abstract class ArraySorterBase
    {
        public abstract void Sort(int[] array);
    }

    public class BubbleSorter : ArraySorterBase
    {
        public override void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }

    public class MergeSorter : ArraySorterBase
    {
        public override void Sort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort(int[] array, int left, int right)
        {
            if (left >= right) return;

            int middle = (left + right) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }

        private void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < n1)
            {
                array[k++] = leftArray[i++];
            }

            while (j < n2)
            {
                array[k++] = rightArray[j++];
            }
        }
    }

    public class SelectionSorter : ArraySorterBase
    {
        public override void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    public enum SortingMethods
    {
        Selection,
        Bubble,
        Merge
    }

    public static class ArrayHelper
    {
        private static Random _random = new Random();

        public static void FillArrayWithRandomValues(int[] array, int minValue, int inclusiveMaxValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _random.Next(minValue, inclusiveMaxValue + 1);
            }
        }

        public static void Sort(int[] array, SortingMethods method = SortingMethods.Selection)
        {
            ArraySorterBase sorter = method switch
            {
                SortingMethods.Bubble => new BubbleSorter(),
                SortingMethods.Merge => new MergeSorter(),
                SortingMethods.Selection => new SelectionSorter(),
                _ => throw new NotSupportedException("Вказаний метод сортування не підтримується")
            };

            sorter.Sort(array);
        }

        public static int MinValue(int[] array, out int index)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Масив порожній або null");

            int min = array[0];
            index = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }

            return min;
        }

        public static int MaxValue(int[] array, out int index)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Масив порожній або null");

            int max = array[0];
            index = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }

            return max;
        }

        public static void Replace(int[] array, int index1, int index2)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index1 < 0 || index1 >= array.Length || index2 < 0 || index2 >= array.Length)
                throw new IndexOutOfRangeException("Індекси виходять за межі масиву");

            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
