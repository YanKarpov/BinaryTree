using System;
using System.Collections.Generic;

namespace BinaryTreeLibrary
{
    public class BinaryHeap
    {
        private List<int> heap = new List<int>();

        public void Insert(int value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && heap[index] > heap[(index - 1) / 2])
            {
                int parentIndex = (index - 1) / 2;
                int temp = heap[parentIndex];
                heap[parentIndex] = heap[index];
                heap[index] = temp;
                index = parentIndex;
            }
        }

        public int ExtractMax()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Куча пуста.");
            int max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return max;
        }

        private void HeapifyDown(int index)
        {
            while (index < heap.Count)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int largest = index;

                if (leftChild < heap.Count && heap[leftChild] > heap[largest]) largest = leftChild;
                if (rightChild < heap.Count && heap[rightChild] > heap[largest]) largest = rightChild;

                if (largest == index) break;

                int temp = heap[index];
                heap[index] = heap[largest];
                heap[largest] = temp;

                index = largest;
            }
        }

        public int Max => heap.Count > 0 ? heap[0] : throw new InvalidOperationException("Куча пуста.");
        public int Count => heap.Count;

        // Метод для генерации случайных значений
        public void GenerateRandom(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                Insert(rand.Next(1, 100)); // Генерируем случайное значение от 1 до 99
            }
        }

        public int GetMaxDepth()
        {
            int depth = 0;
            int count = Count;

            while (count > 0)
            {
                count = (count - 1) / 2;
                depth++;
            }

            return depth;
        }

        public int Remove()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Куча пуста.");
            return ExtractMax(); // Удаляет максимальный элемент
        }


        public void Clear()
        {
            heap.Clear();
        }

        public List<int> GetHeap()
        {
            return new List<int>(heap); // Возвращаем копию кучи
        }
    }
}

