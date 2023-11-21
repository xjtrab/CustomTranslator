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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.lab1 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnPasteCommit = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSubmit.Location = new System.Drawing.Point(388, 499);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 20);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(-1, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(602, 100);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox2.Location = new System.Drawing.Point(0, 135);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(601, 106);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(54, 109);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(45, 15);
            this.lab1.TabIndex = 3;
            this.lab1.Text = "English";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Location = new System.Drawing.Point(56, 244);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(31, 15);
            this.lab2.TabIndex = 4;
            this.lab2.Text = "中文";
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSwitch.Location = new System.Drawing.Point(282, 499);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(75, 20);
            this.btnSwitch.TabIndex = 5;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnPasteCommit
            // 
            this.btnPasteCommit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPasteCommit.Location = new System.Drawing.Point(494, 499);
            this.btnPasteCommit.Name = "btnPasteCommit";
            this.btnPasteCommit.Size = new System.Drawing.Size(98, 20);
            this.btnPasteCommit.TabIndex = 6;
            this.btnPasteCommit.Text = "PasteCommit";
            this.btnPasteCommit.UseVisualStyleBackColor = true;
            this.btnPasteCommit.Click += new System.EventHandler(this.btnPasteCommit_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox3.Location = new System.Drawing.Point(0, 283);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(601, 189);
            this.richTextBox3.TabIndex = 7;
            this.richTextBox3.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Open AI";
            // 
            // btnListen
            // 
            this.btnListen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnListen.Location = new System.Drawing.Point(187, 498);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 9;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 531);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.btnPasteCommit);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.lab2);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSubmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomTranslator";
            this.ResumeLayout(false);
            this.PerformLayout();

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