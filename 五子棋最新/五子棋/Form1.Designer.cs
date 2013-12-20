namespace 五子棋
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联机对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EscToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助F1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再来一局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再来一局ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.退出EscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助F1ToolStripMenuItem,
            this.再来一局ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(519, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.联机对战ToolStripMenuItem,
            this.退出EscToolStripMenuItem,
            this.退出EscToolStripMenuItem1});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.文件ToolStripMenuItem.Text = "游戏&G";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始ToolStripMenuItem.Text = "开局(F2)";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 联机对战ToolStripMenuItem
            // 
            this.联机对战ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务器ToolStripMenuItem,
            this.客户端ToolStripMenuItem});
            this.联机对战ToolStripMenuItem.Name = "联机对战ToolStripMenuItem";
            this.联机对战ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.联机对战ToolStripMenuItem.Text = "联机对战";
            this.联机对战ToolStripMenuItem.Click += new System.EventHandler(this.联机对战ToolStripMenuItem_Click);
            // 
            // 服务器ToolStripMenuItem
            // 
            this.服务器ToolStripMenuItem.Name = "服务器ToolStripMenuItem";
            this.服务器ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.服务器ToolStripMenuItem.Text = "服务器";
            this.服务器ToolStripMenuItem.Click += new System.EventHandler(this.服务器ToolStripMenuItem_Click);
            // 
            // 客户端ToolStripMenuItem
            // 
            this.客户端ToolStripMenuItem.Name = "客户端ToolStripMenuItem";
            this.客户端ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.客户端ToolStripMenuItem.Text = "客户端";
            this.客户端ToolStripMenuItem.Click += new System.EventHandler(this.客户端ToolStripMenuItem_Click);
            // 
            // 退出EscToolStripMenuItem1
            // 
            this.退出EscToolStripMenuItem1.Name = "退出EscToolStripMenuItem1";
            this.退出EscToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.退出EscToolStripMenuItem1.Text = "退出(Esc)";
            this.退出EscToolStripMenuItem1.Click += new System.EventHandler(this.退出EscToolStripMenuItem1_Click);
            // 
            // 帮助F1ToolStripMenuItem
            // 
            this.帮助F1ToolStripMenuItem.Name = "帮助F1ToolStripMenuItem";
            this.帮助F1ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.帮助F1ToolStripMenuItem.Text = "帮助(F1)";
            this.帮助F1ToolStripMenuItem.Click += new System.EventHandler(this.帮助F1ToolStripMenuItem_Click);
            // 
            // 再来一局ToolStripMenuItem
            // 
            this.再来一局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.断开连接ToolStripMenuItem,
            this.再来一局ToolStripMenuItem1});
            this.再来一局ToolStripMenuItem.Enabled = false;
            this.再来一局ToolStripMenuItem.Name = "再来一局ToolStripMenuItem";
            this.再来一局ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.再来一局ToolStripMenuItem.Text = "再来一局";
            this.再来一局ToolStripMenuItem.Click += new System.EventHandler(this.再来一局ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // 再来一局ToolStripMenuItem1
            // 
            this.再来一局ToolStripMenuItem1.Name = "再来一局ToolStripMenuItem1";
            this.再来一局ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.再来一局ToolStripMenuItem1.Text = "认输";
            this.再来一局ToolStripMenuItem1.Click += new System.EventHandler(this.再来一局ToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(519, 23);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel1.Text = "五子棋对战";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "悔棋";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 退出EscToolStripMenuItem
            // 
            this.退出EscToolStripMenuItem.Name = "退出EscToolStripMenuItem";
            this.退出EscToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出EscToolStripMenuItem.Text = "悔棋(F3)";
            this.退出EscToolStripMenuItem.Click += new System.EventHandler(this.退出EscToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 278);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(535, 604);
            this.Name = "Form1";
            this.Text = "五子棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联机对战ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EscToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助F1ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再来一局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再来一局ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出EscToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

