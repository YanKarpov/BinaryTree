using System;
using System.Collections.Generic;

namespace HeapSortAndPriorityQueue
{
    public class PriorityQueue<T>
    {
        private List<(T item, int priority)> elements = new List<(T, int)>();

        public void Enqueue(T item, int priority)
        {
            elements.Add((item, priority));
            HeapifyUp(elements.Count - 1);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Очередь пуста.");

            var maxItem = elements[0].item;
            elements[0] = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);

            if (elements.Count > 0)
                HeapifyDown(0);

            return maxItem;
        }

        public bool IsEmpty()
        {
            return elements.Count == 0;
        }

        public int Count
        {
            get { return elements.Count; }
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (elements[index].priority <= elements[parentIndex].priority)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            int size = elements.Count;
            while (index < size)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int largest = index;

                if (leftChild < size && elements[leftChild].priority > elements[largest].priority)
                    largest = leftChild;

                if (rightChild < size && elements[rightChild].priority > elements[largest].priority)
                    largest = rightChild;

                if (largest == index)
                    break;

                Swap(index, largest);
                index = largest;
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temp;
        }
    }
}
