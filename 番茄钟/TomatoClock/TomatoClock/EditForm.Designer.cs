
namespace TomatoClock
{
    partial class EditForm
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker_datetime = new System.Windows.Forms.DateTimePicker();
            this.cmb_state = new System.Windows.Forms.ComboBox();
            this.cmb_category = new System.Windows.Forms.ComboBox();
            this.label_category = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label_content = new System.Windows.Forms.Label();
            this.label_datetime = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(73, 12);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(147, 25);
            this.textBox_Title.TabIndex = 15;
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(73, 155);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(161, 79);
            this.textBox_content.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(31, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 32);
            this.button2.TabIndex = 21;
            this.button2.Text = "新建任务";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(155, 363);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 32);
            this.button3.TabIndex = 22;
            this.button3.Text = "保存修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker_datetime);
            this.panel1.Controls.Add(this.cmb_state);
            this.panel1.Controls.Add(this.cmb_category);
            this.panel1.Controls.Add(this.label_category);
            this.panel1.Controls.Add(this.label_state);
            this.panel1.Controls.Add(this.label_content);
            this.panel1.Controls.Add(this.label_datetime);
            this.panel1.Controls.Add(this.label_title);
            this.panel1.Controls.Add(this.textBox_Title);
            this.panel1.Controls.Add(this.textBox_content);
            this.panel1.Location = new System.Drawing.Point(31, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 305);
            this.panel1.TabIndex = 31;
            // 
            // dateTimePicker_datetime
            // 
            this.dateTimePicker_datetime.CustomFormat = "yy/MM/dd HH:mm";
            this.dateTimePicker_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_datetime.Location = new System.Drawing.Point(73, 52);
            this.dateTimePicker_datetime.Name = "dateTimePicker_datetime";
            this.dateTimePicker_datetime.Size = new System.Drawing.Size(166, 25);
            this.dateTimePicker_datetime.TabIndex = 34;
            // 
            // cmb_state
            // 
            this.cmb_state.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_state.FormattingEnabled = true;
            this.cmb_state.Items.AddRange(new object[] {
            "未完成",
            "完成"});
            this.cmb_state.Location = new System.Drawing.Point(73, 102);
            this.cmb_state.Name = "cmb_state";
            this.cmb_state.Size = new System.Drawing.Size(102, 23);
            this.cmb_state.TabIndex = 42;
            // 
            // cmb_category
            // 
            this.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_category.FormattingEnabled = true;
            this.cmb_category.Items.AddRange(new object[] {
            "会议",
            "社交",
            "课程",
            "学习",
            "娱乐"});
            this.cmb_category.Location = new System.Drawing.Point(73, 254);
            this.cmb_category.Name = "cmb_category";
            this.cmb_category.Size = new System.Drawing.Size(109, 23);
            this.cmb_category.TabIndex = 41;
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_category.Location = new System.Drawing.Point(18, 253);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(49, 20);
            this.label_category.TabIndex = 39;
            this.label_category.Text = "分类";
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_state.Location = new System.Drawing.Point(18, 105);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(49, 20);
            this.label_state.TabIndex = 37;
            this.label_state.Text = "状态";
            // 
            // label_content
            // 
            this.label_content.AutoSize = true;
            this.label_content.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_content.Location = new System.Drawing.Point(18, 155);
            this.label_content.Name = "label_content";
            this.label_content.Size = new System.Drawing.Size(49, 20);
            this.label_content.TabIndex = 36;
            this.label_content.Text = "备注";
            // 
            // label_datetime
            // 
            this.label_datetime.AutoSize = true;
            this.label_datetime.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_datetime.Location = new System.Drawing.Point(18, 55);
            this.label_datetime.Name = "label_datetime";
            this.label_datetime.Size = new System.Drawing.Size(49, 20);
            this.label_datetime.TabIndex = 33;
            this.label_datetime.Text = "时间";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.Location = new System.Drawing.Point(18, 17);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(49, 20);
            this.label_title.TabIndex = 31;
            this.label_title.Text = "主题";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 473);
            this.panel2.TabIndex = 35;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 473);
            this.Controls.Add(this.panel2);
            this.Name = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_content;
        private System.Windows.Forms.Label label_datetime;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.ComboBox cmb_state;
        private System.Windows.Forms.DateTimePicker dateTimePicker_datetime;
        private System.Windows.Forms.ComboBox cmb_category;
        private System.Windows.Forms.Panel panel2;
    }
}
