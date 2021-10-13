namespace TomatoClock
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_buttons = new System.Windows.Forms.Panel();
            this.btn_summary = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.task_btn = new System.Windows.Forms.Button();
            this.btn_pomodoro = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 480);
            this.panel1.TabIndex = 14;
            // 
            // panel_buttons
            // 
            this.panel_buttons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_buttons.BackgroundImage")));
            this.panel_buttons.Controls.Add(this.btn_summary);
            this.panel_buttons.Controls.Add(this.btn_return);
            this.panel_buttons.Controls.Add(this.task_btn);
            this.panel_buttons.Controls.Add(this.btn_pomodoro);
            this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_buttons.Location = new System.Drawing.Point(0, 0);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Size = new System.Drawing.Size(418, 44);
            this.panel_buttons.TabIndex = 16;
            // 
            // btn_summary
            // 
            this.btn_summary.BackColor = System.Drawing.Color.Transparent;
            this.btn_summary.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_summary.Location = new System.Drawing.Point(178, 7);
            this.btn_summary.Margin = new System.Windows.Forms.Padding(4);
            this.btn_summary.Name = "btn_summary";
            this.btn_summary.Size = new System.Drawing.Size(65, 31);
            this.btn_summary.TabIndex = 16;
            this.btn_summary.Text = "统计";
            this.btn_summary.UseVisualStyleBackColor = false;
            this.btn_summary.Click += new System.EventHandler(this.btn_summary_Click);
            // 
            // btn_return
            // 
            this.btn_return.BackColor = System.Drawing.SystemColors.Window;
            this.btn_return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_return.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_return.Location = new System.Drawing.Point(257, 6);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(60, 31);
            this.btn_return.TabIndex = 7;
            this.btn_return.Text = "返回";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // task_btn
            // 
            this.task_btn.Location = new System.Drawing.Point(12, 6);
            this.task_btn.Name = "task_btn";
            this.task_btn.Size = new System.Drawing.Size(64, 31);
            this.task_btn.TabIndex = 0;
            this.task_btn.Text = "任务";
            this.task_btn.UseVisualStyleBackColor = true;
            this.task_btn.Click += new System.EventHandler(this.task_btn_Click);
            // 
            // btn_pomodoro
            // 
            this.btn_pomodoro.Location = new System.Drawing.Point(88, 7);
            this.btn_pomodoro.Name = "btn_pomodoro";
            this.btn_pomodoro.Size = new System.Drawing.Size(77, 31);
            this.btn_pomodoro.TabIndex = 16;
            this.btn_pomodoro.Text = "番茄钟";
            this.btn_pomodoro.UseVisualStyleBackColor = true;
            this.btn_pomodoro.Click += new System.EventHandler(this.btn_pomodoro_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(418, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_buttons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(436, 571);
            this.MinimumSize = new System.Drawing.Size(433, 568);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "番茄钟";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Click += new System.EventHandler(this.Main_Load);
            this.panel_buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDoAffairIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn urgencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel_buttons;
        private System.Windows.Forms.Button btn_pomodoro;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button task_btn;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Button btn_summary;
    }
}