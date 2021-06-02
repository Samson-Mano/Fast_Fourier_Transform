namespace Fast_fourier_transform
{
    partial class chart_view
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chartElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatChartAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatHorizontalAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatVerticalAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatDataSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.main_pic = new System.Windows.Forms.Panel();
            this.mt_pic = new System.Windows.Forms.PictureBox();
            this.dataSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.main_pic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mt_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartElementToolStripMenuItem,
            this.dataSeriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chartElementToolStripMenuItem
            // 
            this.chartElementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatChartAreaToolStripMenuItem,
            this.formatHorizontalAxisToolStripMenuItem,
            this.formatVerticalAxisToolStripMenuItem,
            this.formatDataSeriesToolStripMenuItem});
            this.chartElementToolStripMenuItem.Name = "chartElementToolStripMenuItem";
            this.chartElementToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.chartElementToolStripMenuItem.Text = "Chart Element";
            // 
            // formatChartAreaToolStripMenuItem
            // 
            this.formatChartAreaToolStripMenuItem.Name = "formatChartAreaToolStripMenuItem";
            this.formatChartAreaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.formatChartAreaToolStripMenuItem.Text = "Format Chart Area";
            this.formatChartAreaToolStripMenuItem.Click += new System.EventHandler(this.formatChartAreaToolStripMenuItem_Click);
            // 
            // formatHorizontalAxisToolStripMenuItem
            // 
            this.formatHorizontalAxisToolStripMenuItem.Name = "formatHorizontalAxisToolStripMenuItem";
            this.formatHorizontalAxisToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.formatHorizontalAxisToolStripMenuItem.Text = "Format Horizontal Axis";
            this.formatHorizontalAxisToolStripMenuItem.Click += new System.EventHandler(this.formatHorizontalAxisToolStripMenuItem_Click);
            // 
            // formatVerticalAxisToolStripMenuItem
            // 
            this.formatVerticalAxisToolStripMenuItem.Name = "formatVerticalAxisToolStripMenuItem";
            this.formatVerticalAxisToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.formatVerticalAxisToolStripMenuItem.Text = "Format Vertical Axis";
            this.formatVerticalAxisToolStripMenuItem.Click += new System.EventHandler(this.formatVerticalAxisToolStripMenuItem_Click);
            // 
            // formatDataSeriesToolStripMenuItem
            // 
            this.formatDataSeriesToolStripMenuItem.Name = "formatDataSeriesToolStripMenuItem";
            this.formatDataSeriesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.formatDataSeriesToolStripMenuItem.Text = "Format Data Series";
            this.formatDataSeriesToolStripMenuItem.Click += new System.EventHandler(this.formatDataSeriesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // main_pic
            // 
            this.main_pic.BackColor = System.Drawing.Color.White;
            this.main_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_pic.Controls.Add(this.mt_pic);
            this.main_pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_pic.Location = new System.Drawing.Point(0, 24);
            this.main_pic.Name = "main_pic";
            this.main_pic.Size = new System.Drawing.Size(800, 404);
            this.main_pic.TabIndex = 2;
            this.main_pic.SizeChanged += new System.EventHandler(this.main_pic_SizeChanged);
            this.main_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.main_pic_Paint);
            // 
            // mt_pic
            // 
            this.mt_pic.BackColor = System.Drawing.Color.Transparent;
            this.mt_pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_pic.Enabled = false;
            this.mt_pic.Location = new System.Drawing.Point(0, 0);
            this.mt_pic.Name = "mt_pic";
            this.mt_pic.Size = new System.Drawing.Size(796, 400);
            this.mt_pic.TabIndex = 0;
            this.mt_pic.TabStop = false;
            // 
            // dataSeriesToolStripMenuItem
            // 
            this.dataSeriesToolStripMenuItem.Name = "dataSeriesToolStripMenuItem";
            this.dataSeriesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.dataSeriesToolStripMenuItem.Text = "Data Series";
            // 
            // chart_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.main_pic);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "chart_view";
            this.Text = "Chart View";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.main_pic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mt_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chartElementToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel main_pic;
        public System.Windows.Forms.PictureBox mt_pic;
        private System.Windows.Forms.ToolStripMenuItem formatChartAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatHorizontalAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatVerticalAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatDataSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSeriesToolStripMenuItem;
    }
}