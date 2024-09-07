using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

public class BinaryTree
{
    Node root;

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
        PrintTreeWithLinesRecursive(root, "");
    }

    private void PrintTreeWithLinesRecursive(Node node, string indent)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (node.left != null && node.right != null)
            {
                Console.WriteLine("├─ " + node.data);
                PrintTreeWithLinesRecursive(node.left, indent + "│  ");
                PrintTreeWithLinesRecursive(node.right, indent + "│  ");
            }
            else if (node.left != null)
            {
                Console.WriteLine("└─ " + node.data);
                PrintTreeWithLinesRecursive(node.left, indent + "   ");
            }
            else if (node.right != null)
            {
                Console.WriteLine("└─ " + node.data);
                PrintTreeWithLinesRecursive(node.right, indent + "   ");
            }
            else
            {
                Console.WriteLine("└─ " + node.data);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Добавление элементов в дерево
        tree.Add(50);
        tree.Add(30);
        tree.Add(20);
        tree.Add(40);
        tree.Add(70);
        tree.Add(60);
        tree.Add(80);

        // Вывод дерева в инфиксном порядке (слева направо, по возрастанию)
        tree.PrintTreeInOrder();

        // Остальные вызовы методов обхода и операций
        tree.PrintTreeTopToBottom();
        tree.PrintTreeBottomToTop();
        tree.PrintTreeWithLines();

        // Поиск элемента
        Console.WriteLine(tree.Search(40) ? "Элемент 40 найден" : "Элемент 40 не найден");

        // Удаление элемента
        tree.Remove(20);
        Console.WriteLine("Удален элемент 20");

        // Повторный вывод дерева после удаления
        tree.PrintTreeWithLines();

        // Попробуем найти удаленный элемент
        Console.WriteLine(tree.Search(20) ? "Элемент 20 найден" : "Элемент 20 не найден");
    }
}