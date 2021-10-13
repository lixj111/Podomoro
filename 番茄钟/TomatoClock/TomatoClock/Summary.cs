using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TomatoClock.Service;

namespace TomatoClock
{
    public partial class Summary : UserControl
    {
        public Summary()
        {
            InitializeComponent();
            UserDataServiceDetails osd = new UserDataServiceDetails();
            DataSet ds = osd.GetAchievement_unitList();
            this.comboBox1.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["Achievement_unit"]);
            this.query();
        }
        UserDataServiceDetails osd = new UserDataServiceDetails();
        private void queryBtn_Click(object sender, EventArgs e)
        {
            this.query();
            Entity.UserData others = new Entity.UserData();
            others.Achievement_unit = comboBox1.SelectedIndex;
            osd.UpdateAchievement_unit(others);
        }
        private void query()
        {
            //pie图
            TasksService service = new TasksService();
            List<string> xData = new List<string>() { "完成", "未完成" };
            List<int> yData = new List<int>() { 1, 2 };
            yData[0] = service.GetRecordCount("完成");
            yData[1] = service.GetRecordCount("未完成");
            chart1.Series[0].XValueType = ChartValueType.String;//设置字符串格式
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线

            //柱状图-番茄数
            TomatoService tomatoService = new TomatoService();
            List<string> xDatas = new List<string>();
            List<int> yDatas = new List<int>();
            chart2.Series[0].XValueType = ChartValueType.String;

            //柱状图-番茄时间
            TomatoService ts2 = new TomatoService();
            List<string> xDatas2 = new List<string>();
            List<int> yDatas2 = new List<int>();
            chart3.Series[0].XValueType = ChartValueType.String;

            switch (comboBox1.SelectedIndex) {
                case 0://全年
                    label_unit1.Text = "日期";
                    label_unit2.Text = "日期";
                    //pie图
                    yData[0] = service.GetRecordCount("完成", 0);
                    yData[1] = service.GetRecordCount("未完成", 0);
                    //柱状图-番茄数、番茄时间
                    int j = DateTime.Now.Day <= 12 ? 0 : DateTime.Now.Day - 12;
                    for (int k = j; k <= DateTime.Now.Day; k++)
                    {
                        int temp = k + 1;
                        xDatas.Add(temp.ToString());
                        yDatas.Add(tomatoService.GetRecordCountByDay(temp.ToString()));
                        xDatas2.Add(temp.ToString());
                        yDatas2.Add(ts2.GetTotalTimeRecordCountByDay(temp.ToString()));
                    }
                    break;
                /*
                //pie图
                yData[0] = service.GetRecordCount("完成",0);
                yData[1] = service.GetRecordCount("未完成",0);
                //柱状图-番茄数
                xDatas.Add(DateTime.Now.Month.ToString());
                yDatas.Add(tomatoService.GetRecordCount(DateTime.Now.Month.ToString()));
                //柱状图-番茄时间
                xDatas2.Add(DateTime.Now.Month.ToString());
                yDatas2.Add(ts2.GetTotalTimeRecordCount(DateTime.Now.Month.ToString()));
                break;
                */
                case 1://本季度
                    label_unit1.Text = "月份";
                    label_unit2.Text = "月份";
                    //pie图
                    yData[0] = service.GetRecordCount("完成", 1);
                    yData[1] = service.GetRecordCount("未完成", 1);
                    //柱状图-番茄数-番茄时间
                    int month = DateTime.Now.Month;
                    int jidu = (month - 1) / 3;
                    for(int k = 0; k < 3; k++)
                    {
                        int temp = jidu * 3 + k + 1;
                        xDatas.Add(temp.ToString());
                        yDatas.Add(tomatoService.GetRecordCount(temp.ToString()));
                        xDatas2.Add(temp.ToString());
                        yDatas2.Add(ts2.GetTotalTimeRecordCount(temp.ToString()));
                    }                    
                    break;
                case 2://月份
                    label_unit1.Text = "月份";
                    label_unit2.Text = "月份";
                    //pie图
                    yData[0] = service.GetRecordCount("完成", 2);
                    yData[1] = service.GetRecordCount("未完成", 2);
                    //柱状图
                    for (int k = 0; k < 12; k++)
                    {
                        int temp = k + 1;
                        xDatas.Add(temp.ToString());
                        yDatas.Add(tomatoService.GetRecordCount(temp.ToString()));
                        xDatas2.Add(temp.ToString());
                        yDatas2.Add(ts2.GetTotalTimeRecordCount(temp.ToString()));
                    }
                    break;
                    /*
                case 3://本月日期
                    //pie图
                    yData[0] = service.GetRecordCount("完成", 3);
                    yData[1] = service.GetRecordCount("未完成", 3);
                    //柱状图-番茄数、番茄时间
                    for(int k = 0; k < 30; k++)
                    {
                        int temp = k + 1;
                        xDatas.Add(DateTime.Now.Day.ToString());
                        yDatas.Add(tomatoService.GetRecordCountByDay(temp.ToString()));
                        xDatas2.Add(DateTime.Now.Day.ToString());
                        yDatas2.Add(ts2.GetTotalTimeRecordCountByDay(temp.ToString()));
                    }
                    break;
                    */
                default:
                    yData[0] = service.GetRecordCount("完成", 2);
                    yData[1] = service.GetRecordCount("未完成", 2);
                    break;
            }

            chart1.Series[0].Points.DataBindXY(xData, yData);
            chart2.Series[0].Points.DataBindXY(xDatas, yDatas);
            chart3.Series[0].Points.DataBindXY(xDatas2, yDatas2);
        }
    }
}
