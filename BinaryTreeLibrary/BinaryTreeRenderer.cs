using System.Drawing;


namespace BinaryTreeLibrary
{
    public class BinaryTreeRenderer
    {
        private BinaryTree tree;
        private int nodeRadius = 30;

        public BinaryTreeRenderer(BinaryTree tree)
        {
            this.tree = tree;
        }

        public void Draw(Graphics g, int startX, int startY)
        {
            if (tree != null && tree.Root != null)
            {
                int offsetX = 200;
                DrawTree(g, tree.Root, startX, startY, offsetX, 0);
            }
            else
            {
                g.Clear(Color.White); 
            }
        }

        private void DrawTree(Graphics g, Node node, int x, int y, int offsetX, int level)
        {
            if (node == null) return;

            g.DrawEllipse(Pens.Black, x, y, nodeRadius, nodeRadius);
            g.FillEllipse(Brushes.Gray, x, y, nodeRadius, nodeRadius);
            g.DrawString(node.data.ToString(), SystemFonts.DefaultFont, Brushes.Black, x + 10, y + 10);

            int childOffsetX = offsetX / 2;

            if (node.left != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x - offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.left, x - offsetX, y + 60, childOffsetX, level + 1);
            }

            if (node.right != null)
            {
                g.DrawLine(Pens.Black, x + nodeRadius / 2, y + nodeRadius, x + offsetX + nodeRadius / 2, y + 60);
                DrawTree(g, node.right, x + offsetX, y + 60, childOffsetX, level + 1);
            }
        }
    }
}
