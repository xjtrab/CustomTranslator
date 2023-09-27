namespace CustomTranslator.Win
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnSubmit = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            lab1 = new Label();
            lab2 = new Label();
            btnSwitch = new Button();
            btnPasteCommit = new Button();
            richTextBox3 = new RichTextBox();
            label1 = new Label();
            btnListen = new Button();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(388, 499);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 20);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(-1, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(602, 100);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox2.Location = new Point(0, 135);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(601, 106);
            richTextBox2.TabIndex = 2;
            richTextBox2.Text = "";
            // 
            // lab1
            // 
            lab1.AutoSize = true;
            lab1.Location = new Point(54, 109);
            lab1.Name = "lab1";
            lab1.Size = new Size(45, 15);
            lab1.TabIndex = 3;
            lab1.Text = "English";
            // 
            // lab2
            // 
            lab2.AutoSize = true;
            lab2.Location = new Point(56, 244);
            lab2.Name = "lab2";
            lab2.Size = new Size(31, 15);
            lab2.TabIndex = 4;
            lab2.Text = "中文";
            // 
            // btnSwitch
            // 
            btnSwitch.Location = new Point(282, 499);
            btnSwitch.Name = "btnSwitch";
            btnSwitch.Size = new Size(75, 20);
            btnSwitch.TabIndex = 5;
            btnSwitch.Text = "Switch";
            btnSwitch.UseVisualStyleBackColor = true;
            btnSwitch.Click += btnSwitch_Click;
            // 
            // btnPasteCommit
            // 
            btnPasteCommit.Location = new Point(494, 499);
            btnPasteCommit.Name = "btnPasteCommit";
            btnPasteCommit.Size = new Size(98, 20);
            btnPasteCommit.TabIndex = 6;
            btnPasteCommit.Text = "PasteCommit";
            btnPasteCommit.UseVisualStyleBackColor = true;
            btnPasteCommit.Click += btnPasteCommit_Click;
            // 
            // richTextBox3
            // 
            richTextBox3.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox3.Location = new Point(0, 283);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(601, 189);
            richTextBox3.TabIndex = 7;
            richTextBox3.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 475);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 8;
            label1.Text = "Open AI";
            // 
            // btnListen
            // 
            btnListen.Location = new Point(187, 498);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(75, 23);
            btnListen.TabIndex = 9;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Visible = false;
            btnListen.Click += btnListen_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 531);
            Controls.Add(btnListen);
            Controls.Add(label1);
            Controls.Add(richTextBox3);
            Controls.Add(btnPasteCommit);
            Controls.Add(btnSwitch);
            Controls.Add(lab2);
            Controls.Add(lab1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(btnSubmit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomTranslator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label lab1;
        private Label lab2;
        private Button btnSwitch;
        private Button btnPasteCommit;
        private RichTextBox richTextBox3;
        private Label label1;
        private Button btnListen;
    }
}