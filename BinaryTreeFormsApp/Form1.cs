using System.Windows.Forms;

namespace BinaryTreeFormsApp
{
    public partial class Form1 : Form
    {
        private BinaryTree tree;  

        public Form1()
        {
            InitializeComponent();
            tree = new BinaryTree();  

            buttonAdd.Click += buttonAdd_Click;
            buttonRemove.Click += buttonRemove_Click;
            buttonSearch.Click += buttonSearch_Click;
            buttonGenerateRandom.Click += buttonGenerateRandom_Click;
            pictureBox.Paint += pictureBox_Paint;
            panel.AutoScroll = true;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int addValue))
            {
                tree.Add(addValue);
                AdjustPictureBoxSize(); 
                pictureBox.Invalidate();  
                richTextBoxStatus.AppendText($"Элемент {addValue} добавлен.\n");
                textBoxInput.Clear();
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
                    AdjustPictureBoxSize(); 
                    pictureBox.Invalidate();  
                    richTextBoxStatus.AppendText($"Элемент {removeValue} удалён.\n");
                    textBoxInput.Clear();
                }
                else
                {
                    richTextBoxStatus.AppendText($"Элемент {removeValue} не найден.\n");
                    textBoxInput.Clear();
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
                textBoxInput.Clear();
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
                AdjustPictureBoxSize(); 
                pictureBox.Invalidate(); 
                richTextBoxStatus.AppendText($"Сгенерировано {count} случайных элементов.\n");
                textBoxInput.Clear();
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
                int startX = pictureBox.Width / 2;
                int startY = 20;
                int offsetX = 200;

                
                DrawTree(e.Graphics, tree.Root, startX, startY, offsetX, 0);
            }
        }

        // Метод для отрисовки дерева вручную
        private void DrawTree(Graphics g, Node node, int x, int y, int offsetX, int level)
        {
            if (node == null) return;

            int nodeRadius = 30;  
            
            g.DrawEllipse(Pens.Black, x, y, nodeRadius, nodeRadius);
            g.FillEllipse(Brushes.LightBlue, x, y, nodeRadius, nodeRadius); 
            g.DrawString(node.data.ToString(), this.Font, Brushes.Black, x + 10, y + 10);

            int childOffsetX = offsetX / 2; 

            // Нарисовать линию к левому узлу
            if (node.left != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x - offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.left, x - offsetX, y + 60, childOffsetX, level + 1); 
            }

            // Нарисовать линию к правому узлу
            if (node.right != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x + offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.right, x + offsetX, y + 60, childOffsetX, level + 1); 
            }
        }

        // Метод для динамического изменения размеров PictureBox
        private void AdjustPictureBoxSize()
        {
            if (tree != null && tree.Root != null)
            {
                int maxX = pictureBox.Width;
                int maxY = pictureBox.Height;

                pictureBox.Width = Math.Max(pictureBox.Width, maxX + 50);
                pictureBox.Height = Math.Max(pictureBox.Height, maxY + 50);

                panel.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
            }
        }
    }
}



