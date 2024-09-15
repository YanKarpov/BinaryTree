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

            // Добавляем обработчик события для перерисовки дерева в PictureBox
            pictureBox.Paint += pictureBox_Paint;
        }

        // Добавление элемента
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int addValue))
            {
                tree.Add(addValue);
                pictureBox.Invalidate();  // Обновляем PictureBox после добавления
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
                    pictureBox.Invalidate();  // Обновляем PictureBox после удаления
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

        // Генерация случайных элементов
        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int count))
            {
                tree.GenerateRandom(count);
                pictureBox.Invalidate();  // Обновляем PictureBox после генерации
                richTextBoxStatus.AppendText($"Сгенерировано {count} случайных элементов.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("Некорректное значение.\n");
            }
        }

        // Обработчик события Paint для отрисовки дерева
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (tree != null && tree.Root != null)
            {
                // Центрируем корневой узел на середине PictureBox
                int startX = pictureBox.Width / 2;
                int startY = 20;
                int offsetX = 200; // Стартовое смещение для ветвей

                // Вызов метода для отрисовки дерева
                DrawTree(e.Graphics, tree.Root, startX, startY, offsetX, 0);
            }
        }

        // Метод для отрисовки дерева вручную
        private void DrawTree(Graphics g, Node node, int x, int y, int offsetX, int level)
        {
            if (node == null) return;

            int nodeRadius = 30;  // Радиус узла (в пикселях)
            // Нарисовать узел дерева (круг)
            g.DrawEllipse(Pens.Black, x, y, nodeRadius, nodeRadius);
            g.FillEllipse(Brushes.LightBlue, x, y, nodeRadius, nodeRadius); // Закрасить круг
            g.DrawString(node.data.ToString(), this.Font, Brushes.Black, x + 10, y + 10);

            int childOffsetX = offsetX / 2; // Смещение для дочерних узлов

            // Нарисовать линию к левому узлу
            if (node.left != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x - offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.left, x - offsetX, y + 60, childOffsetX, level + 1); // Рекурсивно нарисовать левое поддерево
            }

            // Нарисовать линию к правому узлу
            if (node.right != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x + offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.right, x + offsetX, y + 60, childOffsetX, level + 1); // Рекурсивно нарисовать правое поддерево
            }
        }
    }
}


