using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TomatoClock.Entity
{
    public class Task
    {
        public int TaskId { get; set; }//任务Id
        public string Title { get; set; }//任务标题
        public DateTime DateTime { get; set; }//任务事件
        public string Content { get; set; }//任务内容
        public string State { get; set; }//状态
        public int Stander { get; set; }//参考标准(判断是否为今日任务)
        public string Category { get; set; }//分类
        public Task(){ }

        public Task(int id, string title, DateTime datetime, string content, string state, string category, int stander ) : this()
        {
            this.TaskId = id;
            this.Title = title;
            this.DateTime = datetime;
            this.Content = content;
            this.State = state;
            this.Category = category;
            this.Stander = stander;
        }
        public override bool Equals(object obj)
        {
            var task = obj as Task;
            return task != null &&
                   TaskId == task.TaskId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
