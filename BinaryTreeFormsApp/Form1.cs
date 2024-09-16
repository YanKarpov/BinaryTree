using System.Windows.Forms;
using System.Drawing;

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
                richTextBoxStatus.AppendText($"������� {addValue} ��������.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
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
                }
                else
                {
                    richTextBoxStatus.AppendText($"������� {removeValue} �� ������.\n");
                }
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int searchValue))
            {
                bool found = tree.Search(searchValue);
                richTextBoxStatus.AppendText(found ? $"������� {searchValue} ������.\n" : $"������� {searchValue} �� ������.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
            }
        }

        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int count))
            {
                tree.GenerateRandom(count);
                AdjustPictureBoxSize();
                pictureBox.Invalidate();
                richTextBoxStatus.AppendText($"������������� {count} ��������� ���������.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            tree = new BinaryTree();  // ������� ����� ������ ������
            pictureBox.Invalidate();  // ��������� ������������
            richTextBoxStatus.Clear();  // ������� ��������� ���� �� ���������
            richTextBoxStatus.AppendText("������ ��������.\n");
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (tree != null && tree.Root != null)
            {
                int startX = pictureBox.Width / 2;
                int startY = 20;
                int offsetX = 200;

                DrawTree(e.Graphics, tree.Root, startX, startY, offsetX, 0);
            }
            else
            {
                // ������� PictureBox, ���� ������ ������
                e.Graphics.Clear(Color.White);
            }
        }

        private void DrawTree(Graphics g, Node node, int x, int y, int offsetX, int level)
        {
            if (node == null) return;

            int nodeRadius = 30;

            g.DrawEllipse(Pens.Black, x, y, nodeRadius, nodeRadius);
            g.FillEllipse(Brushes.LightBlue, x, y, nodeRadius, nodeRadius);
            g.DrawString(node.data.ToString(), this.Font, Brushes.Black, x + 10, y + 10);

            int childOffsetX = offsetX / 2;

            // ���������� ����� � ������ ����
            if (node.left != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x - offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.left, x - offsetX, y + 60, childOffsetX, level + 1);
            }

            // ���������� ����� � ������� ����
            if (node.right != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x + offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.right, x + offsetX, y + 60, childOffsetX, level + 1);
            }
        }

        private void AdjustPictureBoxSize()
        {
            if (tree != null && tree.Root != null)
            {
                // ������ ��� ������� �������� ��� ������� �����
            }
            else
            {
                // ��������������� ������� PictureBox ��� ������ ������
                pictureBox.Width = 500;  // ����������� ������
                pictureBox.Height = 500; // ����������� ������
                panel.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
            }
        }
    }
}



