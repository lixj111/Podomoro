using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TomatoClock.Entity;
using TomatoClock.Service;

namespace TomatoClock
{
    public partial class EditForm : Form
    {
        public Main Main = new Main();
        public TaskForm taskform;
        public Entity.Task Task { get; }

        int TaskId { get; }
        public EditForm(Main m , Entity.Task task)
        {
            Main = m;
            Task = task;
            TaskId = 0;
            InitializeComponent();
        }
        
        public EditForm(Main m, int taskid)
        {
            Main = m;
            TaskId = taskid;
            
            InitializeComponent();
        }

        TasksService ts = new TasksService(); 
        
        //增
        private void button2_Click(object sender, EventArgs e)
        {
            Entity.Task task = new Entity.Task();
            task.Title = this.textBox_Title.Text;
            task.DateTime = this.dateTimePicker_datetime.Value;
            task.Content = this.textBox_content.Text;
            task.State = this.cmb_state.SelectedItem.ToString();
            task.Stander = ts.GetStander(task.DateTime);
            task.Category = this.cmb_category.SelectedItem.ToString();
            ts.Add(task);
            this.Close();
            //Main.Show();
            taskform = new TaskForm(Main);
            taskform.Show();
            Main.panel1.Controls.Clear();
            Main.panel1.Controls.Add(taskform);
            //taskform = new TaskForm(Main);
            //taskform.Refresh();
        }

        //改
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Entity.Task task = new Entity.Task();
                task.TaskId = TaskId;
                task.Title = this.textBox_Title.Text;
                task.DateTime = this.dateTimePicker_datetime.Value;
                task.Content = this.textBox_content.Text;
                task.State = this.cmb_state.SelectedItem.ToString();
                task.Stander = ts.GetStander(task.DateTime);
                task.Category = this.cmb_category.SelectedItem.ToString();
                ts.Update(task);
                this.Close();
                taskform = new TaskForm(Main);
                taskform.Show();
                Main.panel1.Controls.Clear();
                Main.panel1.Controls.Add(taskform);
                //Main.Refresh();
                //Main.Show();
                //taskform = new TaskForm(Main);
                //taskform.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("未选中事项！", "提示");
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

            this.Left = Convert.ToInt32(1280);
            this.Top = Convert.ToInt32(80);
            if (TaskId != 0)
            {
                TasksService ts = new TasksService();
                StringBuilder strSql = new StringBuilder();
                strSql.Append($"TaskId = {TaskId}");
                //SQLiteParameter[] parameters = { new SQLiteParameter("@TaskId", DbType.Int32, 8) };
                //parameters[0].Value = TaskId;
                
                
                DataSet ds = ts.GetList(strSql.ToString());

                this.textBox_Title.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                this.dateTimePicker_datetime.Value = DateTime.Parse(ds.Tables[0].Rows[0]["DateTime"].ToString());
                this.textBox_content.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                this.cmb_state.SelectedItem = ds.Tables[0].Rows[0]["State"].ToString();
                this.cmb_category.SelectedItem = ds.Tables[0].Rows[0]["Category"].ToString();
            }
            else
            {
                this.textBox_Title.Text = "新建事件";
                this.textBox_content.Text = "事件备注";
            }
        }
    }
}
