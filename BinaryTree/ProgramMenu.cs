using System;
class ProgramMenu
{
    public static void RunMenu()
    {
        BinaryTree tree = new BinaryTree();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Консольное меню:");
            Console.WriteLine("1. Добавить элемент");
            Console.WriteLine("2. Удалить элемент");
            Console.WriteLine("3. Найти элемент");
            Console.WriteLine("4. Вывести дерево (префиксный обход)");
            Console.WriteLine("5. Вывести дерево (постфиксный обход)");
            Console.WriteLine("6. Вывести дерево в инфиксном порядке");
            Console.WriteLine("7. Вывести дерево с вертикальными линиями");
            Console.WriteLine("0. Выйти");
            Console.Write("Выберите опцию: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите значение для добавления: ");
                    if (int.TryParse(Console.ReadLine(), out int addValue))
                    {
                        tree.Add(addValue);
                        Console.WriteLine($"Элемент {addValue} добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректное значение.");
                    }
                    break;

                case "2":
                    Console.Write("Введите значение для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int removeValue))
                    {
                        // Удаление элемента
                        if (tree.Search(removeValue))
                        {
                            tree.Remove(removeValue);
                            Console.WriteLine($"Элемент {removeValue} удален.");
                        }
                        else
                        {
                            Console.WriteLine($"Элемент {removeValue} не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректное значение.");
                    }
                    break;

                case "3":
                    Console.Write("Введите значение для поиска: ");
                    if (int.TryParse(Console.ReadLine(), out int searchValue))
                    {
                        bool found = tree.Search(searchValue);
                        Console.WriteLine(found ? $"Элемент {searchValue} найден." : $"Элемент {searchValue} не найден.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректное значение.");
                    }
                    break;

                case "4":
                    tree.PrintTreeTopToBottom();
                    break;

                case "5":
                    tree.PrintTreeBottomToTop();
                    break;

                case "6":
                    tree.PrintTreeInOrder();
                    break;

                case "7":
                    tree.PrintTreeWithLines();
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Выход из программы...");
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}


