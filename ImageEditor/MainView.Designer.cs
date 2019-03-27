namespace ImageEditor
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            this.header = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter = new System.Windows.Forms.Splitter();
            this.sidebar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.viewport = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timeline = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.testFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PencilButton = new System.Windows.Forms.Button();
            this.EraserButton = new System.Windows.Forms.Button();
            this.SpraycanButton = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.viewport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.timeline.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.LightGray;
            this.header.Controls.Add(this.menuStrip1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(800, 25);
            this.header.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolmenu,
            this.filterToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolmenu
            // 
            this.toolmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolmenu.Name = "toolmenu";
            this.toolmenu.Size = new System.Drawing.Size(37, 20);
            this.toolmenu.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.invertedToolStripMenuItem,
            this.randomizedToolStripMenuItem,
            this.cycledToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // invertedToolStripMenuItem
            // 
            this.invertedToolStripMenuItem.Name = "invertedToolStripMenuItem";
            this.invertedToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.invertedToolStripMenuItem.Text = "Inverted";
            this.invertedToolStripMenuItem.Click += new System.EventHandler(this.invertedToolStripMenuItem_Click);
            // 
            // randomizedToolStripMenuItem
            // 
            this.randomizedToolStripMenuItem.Name = "randomizedToolStripMenuItem";
            this.randomizedToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.randomizedToolStripMenuItem.Text = "Randomized";
            this.randomizedToolStripMenuItem.Click += new System.EventHandler(this.randomizedToolStripMenuItem_Click);
            // 
            // cycledToolStripMenuItem
            // 
            this.cycledToolStripMenuItem.Name = "cycledToolStripMenuItem";
            this.cycledToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.cycledToolStripMenuItem.Text = "Cycled";
            this.cycledToolStripMenuItem.Click += new System.EventHandler(this.cycledToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.DarkGray;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.Location = new System.Drawing.Point(0, 310);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(800, 3);
            this.splitter.TabIndex = 5;
            this.splitter.TabStop = false;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.LightGray;
            this.sidebar.Controls.Add(this.SpraycanButton);
            this.sidebar.Controls.Add(this.EraserButton);
            this.sidebar.Controls.Add(this.PencilButton);
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 25);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(96, 285);
            this.sidebar.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.colorButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 66);
            this.panel1.TabIndex = 1;
            // 
            // colorButton
            // 
            this.colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton.BackColor = System.Drawing.Color.Black;
            this.colorButton.CausesValidation = false;
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.colorButton.Location = new System.Drawing.Point(14, 3);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(65, 56);
            this.colorButton.TabIndex = 0;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewport
            // 
            this.viewport.Controls.Add(this.pictureBox1);
            this.viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewport.Location = new System.Drawing.Point(96, 25);
            this.viewport.Name = "viewport";
            this.viewport.Size = new System.Drawing.Size(704, 285);
            this.viewport.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(179, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timeline
            // 
            this.timeline.BackColor = System.Drawing.Color.LightGray;
            this.timeline.Controls.Add(this.listView1);
            this.timeline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeline.Location = new System.Drawing.Point(0, 313);
            this.timeline.Name = "timeline";
            this.timeline.Size = new System.Drawing.Size(800, 137);
            this.timeline.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.BackColor = System.Drawing.Color.Silver;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 137);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(96, 96);
            this.imageList1.TransparentColor = System.Drawing.Color.Silver;
            // 
            // testFilterToolStripMenuItem
            // 
            this.testFilterToolStripMenuItem.Name = "testFilterToolStripMenuItem";
            this.testFilterToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBeforeToolStripMenuItem,
            this.removeFrameToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 48);
            // 
            // addBeforeToolStripMenuItem
            // 
            this.addBeforeToolStripMenuItem.Name = "addBeforeToolStripMenuItem";
            this.addBeforeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addBeforeToolStripMenuItem.Text = "Copy Frame";
            this.addBeforeToolStripMenuItem.Click += new System.EventHandler(this.addBeforeToolStripMenuItem_Click);
            // 
            // removeFrameToolStripMenuItem
            // 
            this.removeFrameToolStripMenuItem.Name = "removeFrameToolStripMenuItem";
            this.removeFrameToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.removeFrameToolStripMenuItem.Text = "Remove Frame";
            this.removeFrameToolStripMenuItem.Click += new System.EventHandler(this.removeFrameToolStripMenuItem_Click);
            // 
            // PencilButton
            // 
            this.PencilButton.Location = new System.Drawing.Point(12, 6);
            this.PencilButton.Name = "PencilButton";
            this.PencilButton.Size = new System.Drawing.Size(75, 23);
            this.PencilButton.TabIndex = 2;
            this.PencilButton.Text = "Pencil";
            this.PencilButton.UseVisualStyleBackColor = true;
            this.PencilButton.Click += new System.EventHandler(this.pencilButton_Click);
            // 
            // EraserButton
            // 
            this.EraserButton.Location = new System.Drawing.Point(12, 35);
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(75, 23);
            this.EraserButton.TabIndex = 3;
            this.EraserButton.Text = "Eraser";
            this.EraserButton.UseVisualStyleBackColor = true;
            this.EraserButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // SpraycanButton
            // 
            this.SpraycanButton.Location = new System.Drawing.Point(12, 64);
            this.SpraycanButton.Name = "SpraycanButton";
            this.SpraycanButton.Size = new System.Drawing.Size(75, 23);
            this.SpraycanButton.TabIndex = 4;
            this.SpraycanButton.Text = "Airbrush";
            this.SpraycanButton.UseVisualStyleBackColor = true;
            this.SpraycanButton.Click += new System.EventHandler(this.sprayCanButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewport);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.timeline);
            this.Controls.Add(this.header);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainView_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.viewport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.timeline.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel viewport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolmenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel timeline;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem cycledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testFilterToolStripMenuItem;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFrameToolStripMenuItem;
        private System.Windows.Forms.Button SpraycanButton;
        private System.Windows.Forms.Button EraserButton;
        private System.Windows.Forms.Button PencilButton;
    }
}

