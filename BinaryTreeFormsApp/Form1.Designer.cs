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
            buttonReset = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(808, 22);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 42);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(808, 116);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 42);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(808, 70);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(94, 40);
            buttonRemove.TabIndex = 4;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // richTextBoxStatus
            // 
            richTextBoxStatus.Location = new Point(808, 228);
            richTextBoxStatus.Name = "richTextBoxStatus";
            richTextBoxStatus.Size = new Size(278, 211);
            richTextBoxStatus.TabIndex = 5;
            richTextBoxStatus.Text = "";
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(808, 178);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(278, 27);
            textBoxInput.TabIndex = 6;
            // 
            // buttonGenerateRandom
            // 
            buttonGenerateRandom.Location = new Point(931, 22);
            buttonGenerateRandom.Name = "buttonGenerateRandom";
            buttonGenerateRandom.Size = new Size(155, 60);
            buttonGenerateRandom.TabIndex = 7;
            buttonGenerateRandom.Text = "Сгенерировать";
            buttonGenerateRandom.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(754, 546);
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(pictureBox);
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(787, 561);
            panel.TabIndex = 9;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(931, 102);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(155, 56);
            buttonReset.TabIndex = 10;
            buttonReset.Text = "Сброс";
            buttonReset.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 573);
            Controls.Add(buttonReset);
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
        private Button buttonReset;
    }
}
