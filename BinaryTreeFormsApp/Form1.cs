using BinaryTreeLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BinaryTreeFormsApp
{
    public partial class Form1 : Form
    {
        private BinaryTree tree;
        private BinaryTreeRenderer treeRenderer;

        public Form1()
        {
            InitializeComponent();
            tree = new BinaryTree();
            treeRenderer = new BinaryTreeRenderer(tree);

            buttonAdd.Click += buttonAdd_Click;
            buttonRemove.Click += buttonRemove_Click;
            buttonSearch.Click += buttonSearch_Click;
            buttonGenerateRandom.Click += buttonGenerateRandom_Click;
            buttonReset.Click += buttonReset_Click;
            pictureBox.Paint += pictureBox_Paint;
            panel.AutoScroll = true;

            checkBoxBalance.CheckedChanged += checkBoxBalance_CheckedChanged;
        }

        private void ClearTextBoxAndAppendStatus(string message)
        {
            richTextBoxStatus.AppendText(message);
            textBoxInput.Clear();
        }

        private bool TryParseInput(out int value)
        {
            return int.TryParse(textBoxInput.Text, out value);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int addValue))
            {
                if (!tree.Search(addValue))
                {
                    tree.Add(addValue);
                    AdjustPictureBoxSize();
                    pictureBox.Invalidate();
                    CenterTreeInPanel();
                    ClearTextBoxAndAppendStatus($"������� {addValue} ��������.\n");
                }
                else
                {
                    ClearTextBoxAndAppendStatus($"������� {addValue} ��� ����������.\n");
                }
            }
            else
            {
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int removeValue))
            {
                if (tree.Search(removeValue))
                {
                    tree.Remove(removeValue);
                    AdjustPictureBoxSize();
                    pictureBox.Invalidate();
                    ClearTextBoxAndAppendStatus($"������� {removeValue} �����.\n");
                }
                else
                {
                    ClearTextBoxAndAppendStatus($"������� {removeValue} �� ������.\n");
                }
            }
            else
            {
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int searchValue))
            {
                bool found = tree.Search(searchValue);
                ClearTextBoxAndAppendStatus(found ? $"������� {searchValue} ������.\n" : $"������� {searchValue} �� ������.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (TryParseInput(out int count))
            {
                tree.GenerateRandom(count);
                AdjustPictureBoxSize();
                pictureBox.Invalidate();
                CenterTreeInPanel();
                ClearTextBoxAndAppendStatus($"������������� {count} ��������� ���������.\n");
            }
            else
            {
                ClearTextBoxAndAppendStatus("������������ ��������.\n");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            tree = new BinaryTree(checkBoxBalance.Checked); 
            treeRenderer = new BinaryTreeRenderer(tree);
            pictureBox.Invalidate();
            richTextBoxStatus.Clear();
            ClearTextBoxAndAppendStatus("������ ��������.\n");
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (tree != null && tree.Root != null)
            {
                int startX = pictureBox.Width / 2;
                int startY = 20;

                treeRenderer.Draw(e.Graphics, startX, startY);
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
        }

        private void AdjustPictureBoxSize()
        {
            if (tree != null && tree.Root != null)
            {
                int treeDepth = tree.GetMaxDepth();
                int treeWidth = (int)Math.Pow(2, treeDepth) * 100;

                pictureBox.Width = Math.Max(treeWidth, panel.Width);
                pictureBox.Height = treeDepth * 80 + 100;

                panel.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
            }
            else
            {
                pictureBox.Width = 500;
                pictureBox.Height = 500;
                panel.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
            }
        }

        private void CenterTreeInPanel()
        {
            if (tree != null && tree.Root != null)
            {
                // ���������� ����������� ����� ������ � ������
                int treeCenterX = pictureBox.Width / 2;
                int panelCenterX = panel.ClientSize.Width / 2;

                // ������������ ����� ��� ������������� ������
                int offsetX = treeCenterX - panelCenterX;

                // ������������� ������� ���������, ��������� ������
                panel.AutoScrollPosition = new Point(offsetX, 0);  
            }
        }

        private void checkBoxBalance_CheckedChanged(object sender, EventArgs e)
        {
            bool isBalanced = checkBoxBalance.Checked;
            tree.SetBalance(isBalanced);
            ClearTextBoxAndAppendStatus(isBalanced
                ? "������������ ��������.\n"
                : "������������ ���������.\n");
        }
    }
}
