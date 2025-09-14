using System;

namespace SearchSortApp
{
    // ==================== ArrayProcessor Class ====================
    public class ArrayProcessor
    {
        private int[] arr = Array.Empty<int>();

        public void Input()
        {
            Console.Write("Nhap so phan tu: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap arr[{i}]: ");
                arr[i] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        public void Display(string title = "Mang")
        {
            Console.WriteLine(title + ": " + string.Join(" ", arr));
        }

        public void BubbleSort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        }

        public void QuickSort(int left, int right)
        {
            int i = left, j = right;
            int pivot = arr[(left + right) / 2];
            while (i <= j)
            {
                while (arr[i] < pivot) i++;
                while (arr[j] > pivot) j--;
                if (i <= j)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++; j--;
                }
            }
            if (left < j) QuickSort(left, j);
            if (i < right) QuickSort(i, right);
        }

        public int LinearSearch(int key)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == key)
                    return i;
            return -1;
        }

        public int BinarySearch(int key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == key) return mid;
                if (arr[mid] < key) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        public int Length => arr.Length;
    }

    // ==================== Program ====================
    class Program
    {
        static void Main()
        {
            var ap = new ArrayProcessor();

            ap.Input();
            ap.Display("Mang ban dau");

            ap.BubbleSort();
            ap.Display("Sau Bubble Sort");

            ap.QuickSort(0, ap.Length - 1);
            ap.Display("Sau Quick Sort");

            Console.Write("Nhap so can tim: ");
            int key = int.Parse(Console.ReadLine() ?? "0");

            int posLinear = ap.LinearSearch(key);
            Console.WriteLine(posLinear >= 0
                ? $"Linear Search: tim thay {key} tai vi tri {posLinear}"
                : $"Linear Search: khong tim thay {key}");

            int posBinary = ap.BinarySearch(key);
            Console.WriteLine(posBinary >= 0
                ? $"Binary Search: tim thay {key} tai vi tri {posBinary}"
                : $"Binary Search: khong tim thay {key}");
        }
    }
}
