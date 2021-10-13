using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TomatoClock.Service;
using System.Runtime.InteropServices;

namespace TomatoClock
{
    public partial class Main : Form
    {
        public Setting setting; //创建用户控件变量
        //public EditForm editform; 
        public Pomodoro pomodoro; 
        public TaskForm taskform; 
        public Summary summary;
        public MainWindow mainwindow;
        public static Main main;
        public Main()
        { 
            InitializeComponent();
            //this.Left=Convert.ToInt32(this.textBox1.Text);
            //this.Top = Convert.ToInt32(this.textBox2.Text);
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOPMOST = 8;
                base.CreateParams.Parent = GetDesktopWindow();
                base.CreateParams.ExStyle |= WS_EX_TOPMOST;
                return base.CreateParams;
            }
        }
        //AnchorStyles anchors;
        //const int OFFSET = 2;
        /*
        protected override void WndProc(ref Message m)
        {
            const int WM_MOVING = 534;
            switch (m.Msg)
            {
                case WM_MOVING: // 窗体移动的消息，控制窗体不会移出屏幕外
                    int left = Marshal.ReadInt32(m.LParam, 0);
                    int top = Marshal.ReadInt32(m.LParam, 4);
                    int right = Marshal.ReadInt32(m.LParam, 8);
                    int bottom = Marshal.ReadInt32(m.LParam, 12);
                    left = Math.Min(Math.Max(0, left),
                        Screen.PrimaryScreen.Bounds.Width - Width);
                    top = Math.Min(Math.Max(0, top),
                        Screen.PrimaryScreen.Bounds.Height - Height);
                    right = Math.Min(Math.Max(Width, right),
                        Screen.PrimaryScreen.Bounds.Width);
                    bottom = Math.Min(Math.Max(Height, bottom),
                        Screen.PrimaryScreen.Bounds.Height);
                    Marshal.WriteInt32(m.LParam, 0, left);
                    Marshal.WriteInt32(m.LParam, 4, top);
                    Marshal.WriteInt32(m.LParam, 8, right);
                    Marshal.WriteInt32(m.LParam, 12, bottom);
                    anchors = AnchorStyles.None;
                    if (left <= OFFSET) anchors |= AnchorStyles.Left;
                    if (top <= OFFSET) anchors |= AnchorStyles.Top;
                    if (bottom >= Screen.PrimaryScreen.Bounds.Height - OFFSET)
                        anchors |= AnchorStyles.Bottom;
                    if (right >= Screen.PrimaryScreen.Bounds.Width - OFFSET)
                        anchors |= AnchorStyles.Right;
                    timer1.Enabled = anchors != AnchorStyles.None;
                    break;
            }
            base.WndProc(ref m);
        }
        */

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval = 2000;//2秒后跳转
            timer1.Start();
            this.Left = Convert.ToInt32(1100);
            this.Top = Convert.ToInt32(0);
        }

        //[DllImport("user32.dll")]
        //public static extern IntPtr WindowFromPoint(Point Point);
        //[DllImport("user32.dll")]
        //public static extern IntPtr GetParent(IntPtr hWnd);
        private void timer1_Tick(object sender, EventArgs e)
        {
            taskform = new TaskForm(this);
            taskform.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(taskform);
            timer1.Enabled = false;
            /*
            IntPtr vHandle = WindowFromPoint(Control.MousePosition);
            while (vHandle != IntPtr.Zero && vHandle != Handle)
                vHandle = GetParent(vHandle);
            if (vHandle == Handle) // 如果鼠标停留的窗体是本窗体，还原位置
            {
                if ((anchors & AnchorStyles.Left) == AnchorStyles.Left) Left = 0;
                if ((anchors & AnchorStyles.Top) == AnchorStyles.Top) Top = 0;
                if ((anchors & AnchorStyles.Right) == AnchorStyles.Right)
                    Left = Screen.PrimaryScreen.Bounds.Width - Width;
                if ((anchors & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                    Top = Screen.PrimaryScreen.Bounds.Height - Height;
            }
            else // 隐藏起来
            {
                if ((anchors & AnchorStyles.Left) == AnchorStyles.Left)
                    Left = -Width + OFFSET;
                if ((anchors & AnchorStyles.Top) == AnchorStyles.Top)
                    Top = -Height + OFFSET;
                if ((anchors & AnchorStyles.Right) == AnchorStyles.Right)
                    Left = Screen.PrimaryScreen.Bounds.Width - OFFSET;
                if ((anchors & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                    Top = Screen.PrimaryScreen.Bounds.Height - OFFSET;
            }
            */
        }

        private void task_btn_Click(object sender, EventArgs e)
        {
            taskform = new TaskForm(this);
            taskform.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(taskform);
        }

        private void btn_summary_Click(object sender, EventArgs e)
        {
            summary = new Summary();
            summary.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(summary);
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            mainwindow = new MainWindow();
            mainwindow.Show();
            panel1.Controls.Clear();
            panel1.Controls.Add(mainwindow);
        }
        private void btn_pomodoro_Click(object sender, EventArgs e)
        {
            TasksService ts = new TasksService();
            DataSet ds = ts.GetOrderedListByDateTime("State like '未完成' ");
            Entity.Task task = new Entity.Task();
            task.TaskId = Int32.Parse(ds.Tables[0].Rows[0]["TaskId"].ToString());
            task.Title = ds.Tables[0].Rows[0]["Title"].ToString();
            task.DateTime = DateTime.Parse(ds.Tables[0].Rows[0]["DateTime"].ToString());
            task.Content = ds.Tables[0].Rows[0]["Content"].ToString();
            task.State = ds.Tables[0].Rows[0]["Content"].ToString();
            task.Category = ds.Tables[0].Rows[0]["Category"].ToString();
            //= Int32.Parse(ds.Tables[0].Rows[0]["Stander"].ToString());
            //task.Category = ds.Tables[0].Rows[0]["Category"].ToString();  
            Pomodoro p = new Pomodoro(this, task);
            this.Hide();
            p.ShowDialog();
            /*f3 = new Pomodoro(this,task);
            f3.Show();   
            panel1.Controls.Clear();  
            panel1.Controls.Add(f3); */ 
        }

        /*public void ShowPodomoro(Entity.Task task)
{
   f3 = new Pomodoro(this, task);
   f3.Show();
   panel1.Controls.Clear();
   panel1.Controls.Add(f3);
}*/
    }
}