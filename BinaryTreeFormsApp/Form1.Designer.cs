namespace BinaryTreeFormsApp
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
            buttonSearch = new Button();
            buttonRemove = new Button();
            richTextBoxStatus = new RichTextBox();
            textBoxInput = new TextBox();
            buttonGenerateRandom = new Button();
            pictureBox = new PictureBox();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel.SuspendLayout();
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
            // buttonSearch
            // 
            buttonSearch.Location = new Point(533, 106);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 37);
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
            richTextBoxStatus.Location = new Point(551, 211);
            richTextBoxStatus.Name = "richTextBoxStatus";
            richTextBoxStatus.Size = new Size(237, 211);
            richTextBoxStatus.TabIndex = 5;
            richTextBoxStatus.Text = "";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(551, 164);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(237, 27);
            textBoxInput.TabIndex = 6;
            // 
            // buttonGenerateRandom
            // 
            buttonGenerateRandom.Location = new Point(633, 14);
            buttonGenerateRandom.Name = "buttonGenerateRandom";
            buttonGenerateRandom.Size = new Size(164, 129);
            buttonGenerateRandom.TabIndex = 7;
            buttonGenerateRandom.Text = "Сгенерировать";
            buttonGenerateRandom.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(28, 25);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(460, 383);
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(pictureBox);
            panel.Location = new Point(4, 3);
            panel.Name = "panel";
            panel.Size = new Size(523, 435);
            panel.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            Controls.Add(buttonGenerateRandom);
            Controls.Add(textBoxInput);
            Controls.Add(richTextBoxStatus);
            Controls.Add(buttonRemove);
            Controls.Add(buttonSearch);
            Controls.Add(buttonAdd);
            Name = "Form1";
            Text = "Бинарное дерево поиска";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
        private Button buttonSearch;
        private Button buttonRemove;
        private RichTextBox richTextBoxStatus;
        private TextBox textBoxInput;
        private Button buttonGenerateRandom;
        private PictureBox pictureBox;
        private Panel panel;
    }
}
