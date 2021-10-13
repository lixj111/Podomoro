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
using System.Text.RegularExpressions;

namespace TomatoClock
{
    public partial class TaskForm : UserControl
    {
        public Main Main = new Main();
        //public Pomodoro f3;
        //public EditForm f2;
        public DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone(); // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {

                tmp.ImportRow(row); // 将DataRow添加到DataTable中
            }
            return tmp;
        }
        public TaskForm(Main m)
        {                                                                                                                                                         
            Main = m;
            InitializeComponent();
            label1.Text = $"{DateTime.Now.Month.ToString()}月{DateTime.Now.Day.ToString()}日-任务";
            TasksService ts = new TasksService();
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select DateTime,TaskId,Title,Content,State,Stander,Category ");
            //strSql.Append(" FROM TaskInfo Order by DateTime ASC");
            //DataSet ds = DbHelperSQLite.Query(strSql.ToString());
            DataSet ds = ts.GetOrderedListByDateTime("");
            DataRow[] dd = ds.Tables[0].Select("Stander = '0'");
            DataTable today = this.ToDataTable(dd);
            this.dataGridView2.DataSource = today;
            dataGridView2.Columns["Title"].Width = 165;
            if (this.dataGridView2.Rows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[0];
                dataGridView2.Columns[1].HeaderCell.Value = "任务";
                contentBox.Text = row.Cells[3].Value == null?"":row.Cells[3].Value.ToString();
                starttimeBox.Text = row.Cells[2].Value == null ? "" : DateTime.Parse(row.Cells[2].Value.ToString()).TimeOfDay.ToString();
                stateBox.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                //添加一个分类
            }

            //隐藏列
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].Visible = false;     
            dataGridView2.Columns[3].Visible = false;     
            dataGridView2.Columns[4].Visible = false;     
            dataGridView2.Columns[5].Visible = false;     
            dataGridView2.Columns[6].Visible = false;     
        }
        //用于委托，在main里每次进入该界面时被调用，来刷新datagridview
        private void UserControl5_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        //设置行的颜色-完成为浅蓝色、未完成为红色
        string st;
        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && this.dataGridView2.Rows[e.RowIndex].Cells[4].Value != null)
            {
                st = this.dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (st == "完成")
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                }
                else if (st == "未完成")
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        //点击查看事项
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.CurrentRow;
            label_Id.Text = row.Cells[0].Value.ToString();
            contentBox.Text = row.Cells[3].Value.ToString();
            starttimeBox.Text = DateTime.Parse(row.Cells[2].Value.ToString()).TimeOfDay.ToString();
            stateBox.Text = row.Cells[4].Value.ToString();
        }
        //进入番茄钟
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.CurrentRow;
            if (row.Cells[4].Value.ToString() != "完成")
            {
                Entity.Task task = new Entity.Task();
                task.TaskId = Int32.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                task.Title = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                task.DateTime = DateTime.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
                task.Content = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                task.State = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                task.Category = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                Pomodoro p = new Pomodoro(Main, task);
                Main.Hide();
                p.ShowDialog();
                //f3 = new Pomodoro(Main, task);
                //f3.Show();
                //Main main = new Main();
                //main.ShowPodomoro(task);
                //main.panel1.Controls.Clear();    
                //main.panel1.Controls.Add(f3);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(stateBox.Text != "完成")
            {
                //更新日程里的选定项
                DataGridViewRow row = this.dataGridView2.CurrentRow;
                Entity.Task task = new Entity.Task();
                TasksService ts = new TasksService();
                task.TaskId = Convert.ToInt32(row.Cells[0].Value.ToString());
                task.Title = row.Cells[1].Value.ToString();
                task.DateTime = DateTime.Parse(row.Cells[2].Value.ToString());
                task.Content = row.Cells[3].Value.ToString();
                task.State = "完成";
                task.Stander = ts.GetStander(task.DateTime);
                task.Category = row.Cells[6].Value.ToString();
                ts.Update(task);
                //改完状态刷新一下
                Refresh();
                //祝贺！
                DialogResult rst = MessageBox.Show(" 恭喜您! 又完成一个任务!");
            }
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Entity.Task task = new Entity.Task();
            task.TaskId = 00;
            task.Title = "新建任务";
            task.DateTime = DateTime.Now;
            task.Content = "备注";
            task.State = "未完成";
            task.Stander = ts.GetStander(task.DateTime);
            task.Category = "娱乐";
            EditForm edit = new EditForm(Main,task);
            edit.ShowDialog();

        }
        TasksService ts = new TasksService();
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("是否确定要删除该任务?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)//注意是diagresult.yes而不是ok；
                {
                    ts.Delete(int.Parse(this.label_Id.Text));
                }
                else 
                {

                }
                Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("未选中事项！", "提示");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Entity.Task updatetask = new Entity.Task();
                updatetask.TaskId = Int32.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                EditForm edit = new EditForm(Main, updatetask.TaskId);
                edit.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("未选中事项！", "提示");
            }
        }

        private void Refresh()
        {
            label1.Text = $"{DateTime.Now.Month.ToString()}月{DateTime.Now.Day.ToString()}日-任务";
            TasksService ts = new TasksService();
            DataSet ds = ts.GetOrderedListByDateTime("");
            DataRow[] dd = ds.Tables[0].Select("stander = '0'");
            DataTable today = this.ToDataTable(dd);
            this.dataGridView2.DataSource = today;
            if (this.dataGridView2.Rows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[0];
                dataGridView2.Columns[1].HeaderCell.Value = "任务";
                contentBox.Text = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                starttimeBox.Text = row.Cells[2].Value == null ? "" : DateTime.Parse(row.Cells[2].Value.ToString()).TimeOfDay.ToString();
                stateBox.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
            }
        }
    }
}
