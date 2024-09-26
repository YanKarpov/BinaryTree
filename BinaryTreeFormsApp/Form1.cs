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
            comboBoxStructure.Items.AddRange(new[] { "Бинарное дерево", "Бинарная куча" });
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
                PerformActionBasedOnStructure(() => AddToTree(addValue), () => AddToHeap(addValue));
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
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "Бинарная куча")
                {
                    RemoveFromHeap();
                }
                else
                {
                    ClearTextBoxAndAppendStatus("Удаление с пустой строкой ввода поддерживается только для бинарной кучи.\n");
                }
            }
            else
            {
                if (TryParseInput(out int removeValue))
                {
                    if (comboBoxStructure.SelectedItem.ToString() == "Бинарная куча")
                    {
                        RemoveFromHeap(removeValue);
                    }
                    else
                    {
                        PerformActionBasedOnStructure(() => RemoveFromTree(removeValue), RemoveFromHeap);
                    }
                }
                else
                {
                    ClearTextBoxAndAppendStatus("Некорректное значение.\n");
                }
            }
        }

        private void RemoveFromHeap()
        {
            try
            {
                int removedValue = heap.Remove(); // Удаляем максимальный элемент
                UpdateUI($"Максимальный элемент {removedValue} удалён из кучи.\n");
            }
            catch (InvalidOperationException ex)
            {
                ClearTextBoxAndAppendStatus(ex.Message + "\n");
            }
        }

        private void RemoveFromHeap(int value)
        {
            if (heap.RemoveSpecific(value))
            {
                UpdateUI($"Элемент {value} удалён из кучи.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus($"Элемент {value} не найден в куче.\n");
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
                else
                {
                    ClearTextBoxAndAppendStatus("Поиск поддерживается только в бинарном дереве.\n");
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
                PerformActionBasedOnStructure(() => tree.GenerateRandom(count), () => heap.GenerateRandom(count));
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
            PerformActionBasedOnStructure(
                () => treeRenderer.Draw(e.Graphics, pictureBox.Width / 2, 20),
                () => heapRenderer.Draw(e.Graphics, pictureBox.Width / 2, 20)
            );
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
            int centerX = pictureBox.Width / 2;
            int panelCenterX = panel.ClientSize.Width / 2;
            panel.AutoScrollPosition = new Point(centerX - panelCenterX, 0);
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

        private void PerformActionBasedOnStructure(Action binaryTreeAction, Action binaryHeapAction)
        {
            if (comboBoxStructure.SelectedItem.ToString() == "Бинарное дерево")
            {
                binaryTreeAction?.Invoke();
            }
            else
            {
                binaryHeapAction?.Invoke();
            }
        }
    }
}



