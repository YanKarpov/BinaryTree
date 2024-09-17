using System;

public class BinaryTree
{
    private Node root;

    public Node Root
    {
        get { return root; }
    }

    private bool _isBalanced; // Новый флаг для включения/выключения балансировки

    public BinaryTree(bool isBalanced = false)
    {
        root = null;
        _isBalanced = isBalanced; // Инициализация балансировки
    }

    // Добавление элемента в дерево
    public void Add(int data)
    {
        root = AddRecursive(root, data);
    }

    // Включение или выключение балансировки
    public void SetBalance(bool isBalanced)
    {
        _isBalanced = isBalanced;
    }

    // Получение максимальной глубины
    public int GetMaxDepth()
    {
        return GetDepth(Root);
    }

    private int GetDepth(Node node)
    {
        if (node == null)
            return 0;

        int leftDepth = GetDepth(node.left);
        int rightDepth = GetDepth(node.right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    // Рекурсивное добавление с учетом балансировки
    private Node AddRecursive(Node node, int data)
    {
        if (node == null)
        {
            node = new Node(data);
            return node;
        }

        if (data < node.data)
            node.left = AddRecursive(node.left, data);
        else if (data > node.data)
            node.right = AddRecursive(node.right, data);

        if (_isBalanced)
        {
            node = Balance(node); // Выполнение балансировки, если флаг установлен
        }

        return node;
    }

    // Удаление элемента из дерева
    public void Remove(int data)
    {
        root = RemoveRecursive(root, data);
    }

    private Node RemoveRecursive(Node node, int data)
    {
        if (node == null)
            return node;

        if (data < node.data)
            node.left = RemoveRecursive(node.left, data);
        else if (data > node.data)
            node.right = RemoveRecursive(node.right, data);
        else
        {
            if (node.left == null)
                return node.right;
            else if (node.right == null)
                return node.left;

            node.data = MinValue(node.right);
            node.right = RemoveRecursive(node.right, node.data);
        }

        if (_isBalanced)
        {
            node = Balance(node); // Балансировка после удаления
        }

        return node;
    }

    private int MinValue(Node node)
    {
        int minValue = node.data;
        while (node.left != null)
        {
            minValue = node.left.data;
            node = node.left;
        }
        return minValue;
    }

    // Поиск элемента в дереве
    public bool Search(int data)
    {
        return SearchRecursive(root, data);
    }

    private bool SearchRecursive(Node root, int data)
    {
        if (root == null)
            return false;

        if (root.data == data)
            return true;

        if (root.data < data)
            return SearchRecursive(root.right, data);

        return SearchRecursive(root.left, data);
    }

    // Метод для генерации случайных элементов
    public void GenerateRandom(int count)
    {
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            int randomValue = rand.Next(1, 101); // Генерация случайных чисел от 1 до 100
            Add(randomValue);
            Console.WriteLine($"Добавлен элемент: {randomValue}");
        }
    }

    // Балансировка узла
    private Node Balance(Node node)
    {
        int balanceFactor = GetBalanceFactor(node);

        // Левое поддерево слишком высоко
        if (balanceFactor > 1)
        {
            // Левый ребенок имеет отрицательный баланс
            if (GetBalanceFactor(node.left) < 0)
            {
                node.left = RotateLeft(node.left);
            }
            node = RotateRight(node);
        }
        // Правое поддерево слишком высоко
        else if (balanceFactor < -1)
        {
            // Правый ребенок имеет положительный баланс
            if (GetBalanceFactor(node.right) > 0)
            {
                node.right = RotateRight(node.right);
            }
            node = RotateLeft(node);
        }

        return node;
    }

    // Получение баланса узла (разница высот поддеревьев)
    private int GetBalanceFactor(Node node)
    {
        if (node == null)
            return 0;
        return GetDepth(node.left) - GetDepth(node.right);
    }

    // Поворот вправо
    private Node RotateRight(Node y)
    {
        Node x = y.left;
        Node T2 = x.right;

        // Выполняем поворот
        x.right = y;
        y.left = T2;

        return x;
    }

    // Поворот влево
    private Node RotateLeft(Node x)
    {
        Node y = x.right;
        Node T2 = y.left;

        // Выполняем поворот
        y.left = x;
        x.right = T2;

        return y;
    }

    // Вывод дерева на консоль (сверху вниз)
    public void PrintTreeTopToBottom()
        {
            Console.WriteLine("Дерево (сверху вниз):");
            PrintTreeTopToBottomRecursive(root);
        }

    private void PrintTreeTopToBottomRecursive(Node node)
    {
        if (node == null)
            return;

        // Обход в префиксном порядке (корень, левое поддерево, правое поддерево)
        Console.WriteLine(node.data);
        PrintTreeTopToBottomRecursive(node.left);
        PrintTreeTopToBottomRecursive(node.right);
    }

    // Вывод дерева на консоль (снизу вверх)
    public void PrintTreeBottomToTop()
    {
        Console.WriteLine("Дерево (снизу вверх):");
        PrintTreeBottomToTopRecursive(root);
    }

    private void PrintTreeBottomToTopRecursive(Node node)
    {
        if (node == null)
            return;

        // Обход в обратном порядке (правое поддерево, левое поддерево, корень)
        PrintTreeBottomToTopRecursive(node.right);
        PrintTreeBottomToTopRecursive(node.left);
        Console.WriteLine(node.data);
    }

    // Вывод дерева в инфиксном порядке
    public void PrintTreeInOrder()
    {
        Console.WriteLine("Дерево в инфиксном порядке:");
        PrintTreeInOrderRecursive(root);
    }

    private void PrintTreeInOrderRecursive(Node node)
    {
        if (node == null)
            return;

        // Сначала левое поддерево
        PrintTreeInOrderRecursive(node.left);

        // Затем текущий узел
        Console.WriteLine(node.data);

        // Затем правое поддерево
        PrintTreeInOrderRecursive(node.right);
    }

    // Вывод дерева на консоль (с вертикальными линиями)
    public void PrintTreeWithLines()
    {
        Console.WriteLine("Дерево с вертикальными линиями:");
        PrintTreeWithLinesRecursive(root, "", true);
    }

    private void PrintTreeWithLinesRecursive(Node node, string indent, bool isLast)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (isLast)
            {
                Console.Write("└─ ");
                indent += "   ";
            }
            else
            {
                Console.Write("├─ ");
                indent += "│  ";
            }

            Console.WriteLine(node.data);

            PrintTreeWithLinesRecursive(node.left, indent, false);
            PrintTreeWithLinesRecursive(node.right, indent, true);
        }
    }
}
