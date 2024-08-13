namespace PigUnlocker
{
    partial class autorun
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(autorun));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            tabControl2 = new TabControl();
            tabPage4 = new TabPage();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            tabPage5 = new TabPage();
            listView2 = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            tabPage6 = new TabPage();
            listView3 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            contextMenuStrip3 = new ContextMenuStrip(components);
            deleteToolStripMenuItem2 = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            listView4 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            button2 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            contextMenuStrip2 = new ContextMenuStrip(components);
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip4 = new ContextMenuStrip(components);
            deleteToolStripMenuItem3 = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage4.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            contextMenuStrip3.SuspendLayout();
            tabPage2.SuspendLayout();
            statusStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(724, 346);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(716, 318);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Regedit";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(569, 293);
            button1.Name = "button1";
            button1.Size = new Size(129, 22);
            button1.TabIndex = 1;
            button1.Text = "Find";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Controls.Add(tabPage6);
            tabControl2.Location = new Point(8, 6);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(700, 285);
            tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(listView1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(692, 257);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Run";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader3 });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(6, 6);
            listView1.Name = "listView1";
            listView1.Size = new Size(680, 245);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.MouseDown += ListView1_MouseDown;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Meaning";
            columnHeader1.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Registry Path";
            columnHeader3.Width = 520;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(listView2);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(692, 257);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "RunOnce";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader4 });
            listView2.ContextMenuStrip = contextMenuStrip1;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Location = new Point(6, 6);
            listView2.Name = "listView2";
            listView2.Size = new Size(680, 245);
            listView2.TabIndex = 2;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            listView2.MouseDown += ListView2_MouseDown;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Meaning";
            columnHeader2.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Registry Path";
            columnHeader4.Width = 520;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(listView3);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(692, 257);
            tabPage6.TabIndex = 2;
            tabPage6.Text = "Winlogon";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            listView3.ContextMenuStrip = contextMenuStrip3;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;
            listView3.Location = new Point(6, 6);
            listView3.Name = "listView3";
            listView3.Size = new Size(680, 245);
            listView3.TabIndex = 2;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            listView3.MouseDown += ListView3_MouseDown;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Name";
            columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Meaning";
            columnHeader6.Width = 520;
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem2 });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(116, 26);
            // 
            // deleteToolStripMenuItem2
            // 
            deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            deleteToolStripMenuItem2.Size = new Size(115, 22);
            deleteToolStripMenuItem2.Text = "Change";
            deleteToolStripMenuItem2.Click += DeleteToolStripMenuItem2_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listView4);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(716, 318);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "AutoRun Folder";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView4
            // 
            listView4.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8 });
            listView4.ContextMenuStrip = contextMenuStrip1;
            listView4.FullRowSelect = true;
            listView4.GridLines = true;
            listView4.Location = new Point(6, 6);
            listView4.Name = "listView4";
            listView4.Size = new Size(702, 281);
            listView4.TabIndex = 2;
            listView4.UseCompatibleStateImageBehavior = false;
            listView4.View = View.Details;
            listView4.MouseDown += ListView5_MouseDown;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "File Name";
            columnHeader7.Width = 130;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Path";
            columnHeader8.Width = 520;
            // 
            // button2
            // 
            button2.Location = new Point(561, 293);
            button2.Name = "button2";
            button2.Size = new Size(147, 23);
            button2.TabIndex = 3;
            button2.Text = "Update list";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 361);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(724, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(72, 17);
            toolStripStatusLabel1.Text = "Version: 1.52";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem1 });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Size = new Size(107, 22);
            deleteToolStripMenuItem1.Text = "Delete";
            deleteToolStripMenuItem1.Click += deleteToolStripMenuItem1_Click_1;
            // 
            // contextMenuStrip4
            // 
            contextMenuStrip4.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem3 });
            contextMenuStrip4.Name = "contextMenuStrip4";
            contextMenuStrip4.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem3
            // 
            deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
            deleteToolStripMenuItem3.Size = new Size(107, 22);
            deleteToolStripMenuItem3.Text = "Delete";
            deleteToolStripMenuItem3.Click += deleteToolStripMenuItem3_Click;
            // 
            // autorun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 383);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "autorun";
            Text = "AutoRun";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            contextMenuStrip3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Button button1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ListView listView2;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private ListView listView3;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem deleteToolStripMenuItem2;
        private ListView listView4;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Button button2;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ContextMenuStrip contextMenuStrip4;
        private ToolStripMenuItem deleteToolStripMenuItem3;
    }
}