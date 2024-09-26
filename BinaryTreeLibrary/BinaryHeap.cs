public class BinaryHeap
{
    private List<int> heap = new List<int>();

    // Вставка элемента в кучу
    public void Insert(int value)
    {
        heap.Add(value);
        HeapifyUp(heap.Count - 1);
    }

    // Удаление произвольного элемента
    public bool RemoveSpecific(int value)
    {
        int index = heap.IndexOf(value);
        if (index == -1) return false; // Элемент не найден

        // Заменяем удаляемый элемент последним элементом
        heap[index] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        // Восстанавливаем свойства кучи
        if (index < heap.Count)
        {
            // Сначала пытаемся "спустить" элемент вниз
            HeapifyDown(index);
            // Затем "поднимаем" элемент вверх, если это необходимо
            HeapifyUp(index);
        }

        return true; // Элемент успешно удалён
    }

    // Поднятие элемента вверх для соблюдения свойств кучи
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index] <= heap[parentIndex])
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    // Извлечение максимального элемента
    public int ExtractMax()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Куча пуста.");

        int max = heap[0];  // Сохраняем максимальный элемент
        heap[0] = heap[heap.Count - 1];  // Перемещаем последний элемент наверх
        heap.RemoveAt(heap.Count - 1);  // Удаляем последний элемент
        if (heap.Count > 0)
            HeapifyDown(0);  // Восстанавливаем кучу, начиная с корня
        return max;
    }

    // Спуск элемента вниз для соблюдения свойств кучи
    private void HeapifyDown(int index)
    {
        int size = heap.Count;
        while (index < size)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            // Сравнение с левым потомком
            if (leftChild < size && heap[leftChild] > heap[largest])
                largest = leftChild;

            // Сравнение с правым потомком
            if (rightChild < size && heap[rightChild] > heap[largest])
                largest = rightChild;

            // Если индекс уже на месте, прерываем цикл
            if (largest == index)
                break;

            Swap(index, largest);
            index = largest;
        }
    }

    // Генерация случайных значений и вставка в кучу
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
        return heap.Count == 0 ? 0 : (int)Math.Floor(Math.Log2(heap.Count)) + 1;
    }

    // Удаление максимального элемента (аналогично ExtractMax)
    public int Remove()
    {
        return ExtractMax();
    }

    // Очистка кучи
    public void Clear()
    {
        heap.Clear();
    }

    // Получение текущего состояния кучи как списка
    public List<int> GetHeap()
    {
        return new List<int>(heap); // Возвращение копии списка кучи
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
