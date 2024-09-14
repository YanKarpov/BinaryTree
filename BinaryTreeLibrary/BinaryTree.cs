using System;

public class BinaryTree
{
    private Node root;  

    public Node Root
    {
        get { return root; }
    }

    public BinaryTree()
    {
        root = null;
    }

    // Добавление элемента в дерево
    public void Add(int data)
    {
        root = AddRecursive(root, data);
    }

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

        return node;
    }

    // Удаление элемента из дерева
    public void Remove(int data)
    {
        root = RemoveRecursive(root, data);
    }

    private Node RemoveRecursive(Node root, int data)
    {
        if (root == null)
            return root;

        if (data < root.data)
            root.left = RemoveRecursive(root.left, data);
        else if (data > root.data)
            root.right = RemoveRecursive(root.right, data);
        else
        {
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;

            root.data = MinValue(root.right);
            root.right = RemoveRecursive(root.right, root.data);
        }

        return root;
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

    // Метод для генерации и добавления случайных элементов
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
