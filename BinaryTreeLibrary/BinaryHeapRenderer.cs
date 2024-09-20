using System;
using System.Drawing;

namespace BinaryTreeLibrary
{
    public class BinaryHeapRenderer
    {
        private BinaryHeap heap;

        public BinaryHeapRenderer(BinaryHeap heap)
        {
            this.heap = heap;
        }

        public void Draw(Graphics g, int startX, int startY)
        {
            // Draw the heap as a complete binary tree
            if (heap.Count > 0)
            {
                DrawNode(g, 0, startX, startY, 200);
            }
        }

        private void DrawNode(Graphics g, int index, int x, int y, int offset)
        {
            if (index >= heap.Count) return; // No more nodes to draw

            // Draw the current node
            g.FillEllipse(Brushes.LightBlue, x - 20, y - 20, 40, 40);
            g.DrawEllipse(Pens.Black, x - 20, y - 20, 40, 40);
            g.DrawString(heap.GetHeap()[index].ToString(), SystemFonts.DefaultFont, Brushes.Black, x - 10, y - 10);

            // Calculate child indices
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            // Draw left child
            if (leftChildIndex < heap.Count)
            {
                int leftX = x - offset;
                int leftY = y + 60;
                g.DrawLine(Pens.Black, x, y + 20, leftX, leftY - 20);
                DrawNode(g, leftChildIndex, leftX, leftY, offset / 2);
            }

            // Draw right child
            if (rightChildIndex < heap.Count)
            {
                int rightX = x + offset;
                int rightY = y + 60;
                g.DrawLine(Pens.Black, x, y + 20, rightX, rightY - 20);
                DrawNode(g, rightChildIndex, rightX, rightY, offset / 2);
            }
        }
    }
}
