using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomatoClock.Entity
{
    public class TomatoData
    {
        public int Id { get; set; }//番茄数据Id
        public int Month { get; set; }//月份
        public int DayofMonth { get; set; }//天数
        public string Title { get; set; }//任务标题
        public int Tomatos { get; set; }//得到的番茄数
        public int TotalTime { get; set; }//工作的番茄时间
        public string Category { get; set; }//任务分类
        public TomatoData() { }

        public TomatoData(int id, int month, int dayofmonth, string title, int tomatos, int totalTime, string category)
        {
            Id = id;
            Month = month;
            DayofMonth = dayofmonth;
            Title = title;
            Tomatos = tomatos;
            TotalTime = totalTime;
            Category = category;
        }

        public override bool Equals(object obj)
        {
            return obj is TomatoData data &&
                   Id == data.Id &&
                   Month == data.Month &&
                   DayofMonth == data.DayofMonth &&
                   Title == data.Title &&
                   Tomatos == data.Tomatos &&
                   TotalTime == data.TotalTime &&
                   Category == data.Category;
        }

        public override int GetHashCode()
        {
            int hashCode = 1530916674;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + DayofMonth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + Tomatos.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Category);
            return hashCode;
        }
    }
}
