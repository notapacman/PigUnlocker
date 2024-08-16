namespace PigUnlocker
{
    partial class Other
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Other));
            label1 = new Label();
            groupBox1 = new GroupBox();
            button7 = new Button();
            button8 = new Button();
            button5 = new Button();
            button6 = new Button();
            button4 = new Button();
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(-2, 23);
            label1.Name = "label1";
            label1.Size = new Size(474, 37);
            label1.TabIndex = 0;
            label1.Text = "Pig Helper";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(448, 167);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.System;
            button7.Font = new Font("Segoe UI", 9F);
            button7.Location = new Point(10, 98);
            button7.Name = "button7";
            button7.Size = new Size(213, 25);
            button7.TabIndex = 10;
            button7.Text = "Open Task Scheduler";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.FlatStyle = FlatStyle.System;
            button8.Font = new Font("Segoe UI", 9F);
            button8.Location = new Point(229, 98);
            button8.Name = "button8";
            button8.Size = new Size(213, 25);
            button8.TabIndex = 9;
            button8.Text = "Open Resmon";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.System;
            button5.Font = new Font("Segoe UI", 9F);
            button5.Location = new Point(10, 67);
            button5.Name = "button5";
            button5.Size = new Size(213, 25);
            button5.TabIndex = 8;
            button5.Text = "Open MSConfig";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button6
            // 
            button6.FlatStyle = FlatStyle.System;
            button6.Font = new Font("Segoe UI", 9F);
            button6.Location = new Point(229, 67);
            button6.Name = "button6";
            button6.Size = new Size(213, 25);
            button6.TabIndex = 6;
            button6.Text = "Open Compmgmt";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.System;
            button4.Font = new Font("Segoe UI", 11F);
            button4.Location = new Point(229, 129);
            button4.Name = "button4";
            button4.Size = new Size(213, 32);
            button4.TabIndex = 4;
            button4.Text = "Open eventvwr";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Segoe UI", 11F);
            button2.Location = new Point(10, 129);
            button2.Name = "button2";
            button2.Size = new Size(213, 32);
            button2.TabIndex = 3;
            button2.Text = "Open gpedit.msc";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.System;
            button3.Font = new Font("Segoe UI", 11F);
            button3.Location = new Point(229, 22);
            button3.Name = "button3";
            button3.Size = new Size(213, 39);
            button3.TabIndex = 2;
            button3.Text = "Open Task Manager";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(10, 22);
            button1.Name = "button1";
            button1.Size = new Size(213, 39);
            button1.TabIndex = 0;
            button1.Text = "Open Registry Editor";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 242);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(472, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(81, 17);
            toolStripStatusLabel1.Text = "Version: 1.33.7";
            // 
            // Other
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 264);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Other";
            Text = "PigHelper";
            groupBox1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button button3;
        private Button button1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button button4;
        private Button button2;
        private Button button7;
        private Button button8;
        private Button button5;
        private Button button6;
    }
}