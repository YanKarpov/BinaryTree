namespace BinaryTreeFormsApp
{
    public partial class Form1 : Form
    {
        private BinaryTree tree;  // ������ �� ������

        public Form1()
        {
            InitializeComponent();
            tree = new BinaryTree();  // ������������� ������


            buttonAdd.Click += buttonAdd_Click;
            buttonRemove.Click += buttonRemove_Click;
            buttonSearch.Click += buttonSearch_Click;
            buttonGenerateRandom.Click += buttonGenerateRandom_Click;
        }

        // ���������� ��������
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int addValue))
            {
                tree.Add(addValue);
                UpdateTreeView();
                richTextBoxStatus.AppendText($"������� {addValue} ��������.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
            }
        }

        // �������� ��������
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int removeValue))
            {
                if (tree.Search(removeValue))
                {
                    tree.Remove(removeValue);
                    UpdateTreeView();
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

        // ����� ��������
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

        // ���������� TreeView ��� ����������� ��������� ������
        private void UpdateTreeView()
        {
            treeViewBinaryTree.Nodes.Clear();
            AddNodes(treeViewBinaryTree.Nodes, tree.Root);
            treeViewBinaryTree.ExpandAll();
        }

        // ����������� ���������� ����� � TreeView
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

        // ��������� ��������� ���������
        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int count))
            {
                tree.GenerateRandom(count);
                UpdateTreeView();
                richTextBoxStatus.AppendText($"������������� {count} ��������� ���������.\n");
            }
            else
            {
                richTextBoxStatus.AppendText("������������ ��������.\n");
            }
        }
    }
}


