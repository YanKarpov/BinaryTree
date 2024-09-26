using System;

namespace HeapSortAndPriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            HeapSort.Sort(array);
            Console.WriteLine("Отсортированный массив:");
            PrintArray(array);

            PriorityQueue<string> pq = new PriorityQueue<string>();
            pq.Enqueue("Задача 1", 2);
            pq.Enqueue("Задача 3", 1);
            pq.Enqueue("Задача 2", 3);

            Console.WriteLine("Извлечение задач по приоритету:");
            while (!pq.IsEmpty())
            {
                Console.WriteLine(pq.Dequeue());
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
