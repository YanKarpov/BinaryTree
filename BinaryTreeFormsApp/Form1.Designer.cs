﻿namespace BinaryTreeFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAdd = new Button();
            treeViewBinaryTree = new TreeView();
            buttonSearch = new Button();
            buttonRemove = new Button();
            richTextBoxStatus = new RichTextBox();
            textBoxInput = new TextBox();
            buttonGenerateRandom = new Button();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(533, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 42);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // treeViewBinaryTree
            // 
            treeViewBinaryTree.Location = new Point(12, 12);
            treeViewBinaryTree.Name = "treeViewBinaryTree";
            treeViewBinaryTree.Size = new Size(515, 416);
            treeViewBinaryTree.TabIndex = 2;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(633, 12);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(164, 42);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(533, 60);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(94, 40);
            buttonRemove.TabIndex = 4;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // richTextBoxStatus
            // 
            richTextBoxStatus.Location = new Point(551, 217);
            richTextBoxStatus.Name = "richTextBoxStatus";
            richTextBoxStatus.Size = new Size(237, 211);
            richTextBoxStatus.TabIndex = 5;
            richTextBoxStatus.Text = "";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(551, 116);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(237, 27);
            textBoxInput.TabIndex = 6;
            // 
            // buttonGenerateRandom
            // 
            buttonGenerateRandom.Location = new Point(633, 60);
            buttonGenerateRandom.Name = "buttonGenerateRandom";
            buttonGenerateRandom.Size = new Size(164, 40);
            buttonGenerateRandom.TabIndex = 7;
            buttonGenerateRandom.Text = "Сгенерировать";
            buttonGenerateRandom.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonGenerateRandom);
            Controls.Add(textBoxInput);
            Controls.Add(richTextBoxStatus);
            Controls.Add(buttonRemove);
            Controls.Add(buttonSearch);
            Controls.Add(treeViewBinaryTree);
            Controls.Add(buttonAdd);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
        private TreeView treeViewBinaryTree;
        private Button buttonSearch;
        private Button buttonRemove;
        private RichTextBox richTextBoxStatus;
        private TextBox textBoxInput;
        private Button buttonGenerateRandom;
    }
}
