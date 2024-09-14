namespace BinaryTreeFormsApp
{
    public partial class Form1 : Form
    {
        private BinaryTree tree;  // Ссылка на дерево

        public Form1()
        {
            InitializeComponent();
            tree = new BinaryTree();  // Инициализация дерева


            buttonAdd.Click += buttonAdd_Click;
            buttonRemove.Click += buttonRemove_Click;
            buttonSearch.Click += buttonSearch_Click;
            buttonGenerateRandom.Click += buttonGenerateRandom_Click;
        }

        // Добавление элемента
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int addValue))
            {
                tree.Add(addValue);
                UpdateTreeView();
                richTextBoxStatus.AppendText($"Элемент {addValue} добавлен.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("Некорректное значение.\n");
            }
        }

        // Удаление элемента
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int removeValue))
            {
                if (tree.Search(removeValue))
                {
                    tree.Remove(removeValue);
                    UpdateTreeView();
                    richTextBoxStatus.AppendText($"Элемент {removeValue} удалён.\n");
                }
                else
                {
                    richTextBoxStatus.AppendText($"Элемент {removeValue} не найден.\n");
                }
            }
            else
            {
                richTextBoxStatus.AppendText("Некорректное значение.\n");
            }
        }

        // Поиск элемента
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int searchValue))
            {
                bool found = tree.Search(searchValue);
                richTextBoxStatus.AppendText(found ? $"Элемент {searchValue} найден.\n" : $"Элемент {searchValue} не найден.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("Некорректное значение.\n");
            }
        }

        // Обновление TreeView для отображения элементов дерева
        private void UpdateTreeView()
        {
            treeViewBinaryTree.Nodes.Clear();
            AddNodes(treeViewBinaryTree.Nodes, tree.Root);
            treeViewBinaryTree.ExpandAll();
        }

        // Рекурсивное добавление узлов в TreeView
        private void AddNodes(TreeNodeCollection nodes, Node node)
        {
            if (node != null)
            {
                TreeNode newNode = new TreeNode(node.data.ToString());
                nodes.Add(newNode);
                AddNodes(newNode.Nodes, node.left);
                AddNodes(newNode.Nodes, node.right);
            }
        }

        // Генерация случайных элементов
        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int count))
            {
                tree.GenerateRandom(count);
                UpdateTreeView();
                richTextBoxStatus.AppendText($"Сгенерировано {count} случайных элементов.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("Некорректное значение.\n");
            }
        }
    }
}


