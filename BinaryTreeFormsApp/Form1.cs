using BinaryTreeLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BinaryTreeFormsApp
{
    public partial class Form1 : Form
    {
        private BinaryTree tree;
        private BinaryHeap heap;
        private BinaryTreeRenderer treeRenderer;
        private BinaryHeapRenderer heapRenderer;

        public Form1()
        {
            InitializeComponent();
            InitializeDataStructures();
            InitializeComboBox();
            InitializeEventHandlers();
            panel.AutoScroll = true;
        }

        private void InitializeDataStructures()
        {
            tree = new BinaryTree();
            heap = new BinaryHeap();
            treeRenderer = new BinaryTreeRenderer(tree);
            heapRenderer = new BinaryHeapRenderer(heap);
        }

        private void InitializeComboBox()
        {
            comboBoxStructure.Items.Add("Бинарное дерево");
            comboBoxStructure.Items.Add("Бинарная куча");
            comboBoxStructure.SelectedIndex = 0; // По умолчанию бинарное дерево
        }

        private void InitializeEventHandlers()
        {
            comboBoxStructure.SelectedIndexChanged += (s, e) => pictureBox.Invalidate();
            buttonAdd.Click += ButtonAdd_Click;
            buttonRemove.Click += ButtonRemove_Click;
            buttonSearch.Click += ButtonSearch_Click;
            buttonGenerateRandom.Click += ButtonGenerateRandom_Click;
            buttonReset.Click += ButtonReset_Click;
            pictureBox.Paint += PictureBox_Paint;
            checkBoxBalance.CheckedChanged += CheckBoxBalance_CheckedChanged;
        }

        private void ClearTextBoxAndAppendStatus(string message)
        {
            richTextBoxStatus.AppendText(message);
            textBoxInput.Clear();
        }

        private bool TryParseInput(out int value) => int.TryParse(textBoxInput.Text, out value);

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int addValue))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
                {
                    AddToTree(addValue);
                }
                else
                {
                    AddToHeap(addValue);
                }
            }
            else
            {
                ClearTextBoxAndAppendStatus("Некорректное значение.\n");
            }
        }

        private void AddToTree(int value)
        {
            if (!tree.Search(value))
            {
                tree.Add(value);
                UpdateUI($"Элемент {value} добавлен в дерево.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus($"Элемент {value} уже существует в дереве.\n");
            }
        }

        private void AddToHeap(int value)
        {
            heap.Insert(value);
            UpdateUI($"Элемент {value} добавлен в кучу.\n");
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int removeValue))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
                {
                    RemoveFromTree(removeValue);
                }
                else
                {
                    RemoveFromHeap();
                }
            }
            else
            {
                ClearTextBoxAndAppendStatus("Некорректное значение.\n");
            }
        }

        private void RemoveFromHeap()
        {
            try
            {
                int removedValue = heap.Remove(); 
                UpdateUI($"Максимальный элемент {removedValue} удалён из кучи.\n");
            }
            catch (InvalidOperationException ex)
            {
                ClearTextBoxAndAppendStatus(ex.Message + "\n");
            }
        }


        private void RemoveFromTree(int value)
        {
            if (tree.Search(value))
            {
                tree.Remove(value);
                UpdateUI($"Элемент {value} удалён из дерева.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus($"Элемент {value} не найден в дереве.\n");
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int searchValue))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
                {
                    SearchInTree(searchValue);
                }
            }
            else
            {
                ClearTextBoxAndAppendStatus("Некорректное значение.\n");
            }
        }

        private void SearchInTree(int value)
        {
            bool found = tree.Search(value);
            ClearTextBoxAndAppendStatus(found ? $"Элемент {value} найден в дереве.\n" : $"Элемент {value} не найден в дереве.\n");
        }

        private void ButtonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int count))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
                {
                    tree.GenerateRandom(count);
                }
                else
                {
                    heap.GenerateRandom(count);
                }

                UpdateUI($"Сгенерировано {count} случайных элементов.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus("Некорректное значение.\n");
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetDataStructures();
            ClearTextBoxAndAppendStatus("Структура сброшена.\n");
        }

        private void ResetDataStructures()
        {
            if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
            {
                tree = new BinaryTree(checkBoxBalance.Checked);
                treeRenderer = new BinaryTreeRenderer(tree);
            }
            else
            {
                heap = new BinaryHeap();
                heapRenderer = new BinaryHeapRenderer(heap);
            }
            pictureBox.Invalidate();
            richTextBoxStatus.Clear();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
            {
                if (tree?.Root != null)
                {
                    treeRenderer.Draw(e.Graphics, pictureBox.Width / 2, 20);
                }
            }
            else
            {
                if (heap?.Count != null)
                {
                    heapRenderer.Draw(e.Graphics, pictureBox.Width / 2, 20);
                }
            }
        }

        private void UpdateUI(string message)
        {
            AdjustPictureBoxSize();
            pictureBox.Invalidate();
            CenterTreeInPanel();
            ClearTextBoxAndAppendStatus(message);
        }

        private void AdjustPictureBoxSize()
        {
            int depth = (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево") ? tree.GetMaxDepth() : heap.GetMaxDepth();
            int width = (int)Math.Pow(2, depth) * 100;

            pictureBox.Width = Math.Max(width, panel.Width);
            pictureBox.Height = depth * 80 + 100;
            panel.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
        }

        private void CenterTreeInPanel()
        {
            if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
            {
                CenterInPanel(tree);
            }
            else
            {
                CenterInPanel(heap);
            }
        }

        private void CenterInPanel(dynamic structure)
        {
            if (structure != null && (structure is BinaryTree tree && tree.Root != null || structure is BinaryHeap heap && heap.Count > 0))
            {
                int centerX = pictureBox.Width / 2;
                int panelCenterX = panel.ClientSize.Width / 2;
                panel.AutoScrollPosition = new Point(centerX - panelCenterX, 0);
            }
        }


        private void CheckBoxBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
            {
                bool isBalanced = checkBoxBalance.Checked;
                tree.SetBalance(isBalanced);
                ClearTextBoxAndAppendStatus(isBalanced ? "Балансировка включена.\n" : "Балансировка выключена.\n");
            }
        }
    }
}


