using System;
using System.Collections.Generic;

namespace BinaryTreeLibrary
{
    public class BinaryHeap
    {
        private List<int> heap = new List<int>();

        // Вставка элемента в кучу
        public void Insert(int value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }

        // Поднятие элемента вверх для соблюдения свойств кучи
        private void HeapifyUp(int index)
        {
            while (index > 0 && heap[index] > heap[(index - 1) / 2])
            {
                int parentIndex = (index - 1) / 2;
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        // Извлечение максимального элемента
        public int ExtractMax()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Куча пуста.");

            int max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return max;
        }

        // Спуск элемента вниз для соблюдения свойств кучи
        private void HeapifyDown(int index)
        {
            while (index < heap.Count)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int largest = index;

                if (leftChild < heap.Count && heap[leftChild] > heap[largest])
                    largest = leftChild;

                if (rightChild < heap.Count && heap[rightChild] > heap[largest])
                    largest = rightChild;

                if (largest == index)
                    break;

                Swap(index, largest);
                index = largest;
            }
        }

        // Метод для генерации случайных значений
        public void GenerateRandom(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                Insert(rand.Next(1, 100)); // Генерация случайных значений от 1 до 99
            }
        }

        // Получение глубины кучи
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

        // Удаление максимального элемента
        public int Remove()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Куча пуста.");

            return ExtractMax(); // Удаление максимального элемента
        }

        // Очистка кучи
        public void Clear()
        {
            heap.Clear();
        }

        // Возвращение текущего состояния кучи как списка
        public List<int> GetHeap()
        {
            return new List<int>(heap); // Возвращение копии кучи
        }

        // Получение максимального элемента
        public int Max => heap.Count > 0 ? heap[0] : throw new InvalidOperationException("Куча пуста.");

        // Количество элементов в куче
        public int Count => heap.Count;

        // Вспомогательный метод для обмена элементов
        private void Swap(int index1, int index2)
        {
            int temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}


