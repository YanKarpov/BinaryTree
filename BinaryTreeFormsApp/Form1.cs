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
            comboBoxStructure.Items.Add("�������� ������");
            comboBoxStructure.Items.Add("�������� ����");
            comboBoxStructure.SelectedIndex = 0; // �� ��������� �������� ������
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
                if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
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
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void AddToTree(int value)
        {
            if (!tree.Search(value))
            {
                tree.Add(value);
                UpdateUI($"������� {value} �������� � ������.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus($"������� {value} ��� ���������� � ������.\n");
            }
        }

        private void AddToHeap(int value)
        {
            heap.Insert(value);
            UpdateUI($"������� {value} �������� � ����.\n");
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int removeValue))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
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
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void RemoveFromHeap()
        {
            try
            {
                int removedValue = heap.Remove(); 
                UpdateUI($"������������ ������� {removedValue} ����� �� ����.\n");
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
                UpdateUI($"������� {value} ����� �� ������.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus($"������� {value} �� ������ � ������.\n");
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int searchValue))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
                {
                    SearchInTree(searchValue);
                }
            }
            else
            {
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void SearchInTree(int value)
        {
            bool found = tree.Search(value);
            ClearTextBoxAndAppendStatus(found ? $"������� {value} ������ � ������.\n" : $"������� {value} �� ������ � ������.\n");
        }

        private void ButtonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int count))
            {
                if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
                {
                    tree.GenerateRandom(count);
                }
                else
                {
                    heap.GenerateRandom(count);
                }

                UpdateUI($"������������� {count} ��������� ���������.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetDataStructures();
            ClearTextBoxAndAppendStatus("��������� ��������.\n");
        }

        private void ResetDataStructures()
        {
            if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
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
            if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
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
            int depth = (comboBoxStructure.SelectedItem.ToString() == "�������� ������") ? tree.GetMaxDepth() : heap.GetMaxDepth();
            int width = (int)Math.Pow(2, depth) * 100;

            pictureBox.Width = Math.Max(width, panel.Width);
            pictureBox.Height = depth * 80 + 100;
            panel.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
        }

        private void CenterTreeInPanel()
        {
            if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
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
            if (comboBoxStructure.SelectedItem.ToString() == "�������� ������")
            {
                bool isBalanced = checkBoxBalance.Checked;
                tree.SetBalance(isBalanced);
                ClearTextBoxAndAppendStatus(isBalanced ? "������������ ��������.\n" : "������������ ���������.\n");
            }
        }
    }
}


