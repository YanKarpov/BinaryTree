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
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int addValue))
            {
                tree.Add(addValue);
                AdjustPictureBoxSize();
                pictureBox.Invalidate();
                CenterTreeInPanel();
                richTextBoxStatus.AppendText($"������� {addValue} ��������.\n");
                textBoxInput.Clear();
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
                textBoxInput.Clear();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int removeValue))
            {
                if (tree.Search(removeValue))
                {
                    tree.Remove(removeValue);
                    AdjustPictureBoxSize();
                    pictureBox.Invalidate();
                    richTextBoxStatus.AppendText($"������� {removeValue} �����.\n");
                    textBoxInput.Clear();
                }
                else
                {
                    richTextBoxStatus.AppendText($"������� {removeValue} �� ������.\n");
                    textBoxInput.Clear();
                }
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
                textBoxInput.Clear();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int searchValue))
            {
                bool found = tree.Search(searchValue);
                richTextBoxStatus.AppendText(found ? $"������� {searchValue} ������.\n" : $"������� {searchValue} �� ������.\n");
                textBoxInput.Clear();
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
                textBoxInput.Clear();
            }
        }

        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int count))
            {
                tree.GenerateRandom(count);
                AdjustPictureBoxSize();
                pictureBox.Invalidate();
                CenterTreeInPanel();
                richTextBoxStatus.AppendText($"������������� {count} ��������� ���������.\n");
                textBoxInput.Clear();
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
                textBoxInput.Clear();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            tree = new BinaryTree();  
            treeRenderer = new BinaryTreeRenderer(tree);  
            pictureBox.Invalidate();  
            richTextBoxStatus.Clear();  
            richTextBoxStatus.AppendText("������ ��������.\n");
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
                panel.AutoScrollPosition = new Point(offsetX, 0);  // ���������� �� �����������
            }
        }
    }
}





