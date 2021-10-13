using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using TomatoClock.Entity;

namespace TomatoClock.Service
{
    
    public partial class TasksServiceDetail
    {
        public TasksServiceDetail()
        { }
        #region  BasicMethod
        // 增加一条数据
        public bool Add(Entity.Task task)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TaskInfo(");
            strSql.Append("Title,DateTime,Content,State,Stander,Category)");
            strSql.Append(" values (");
            strSql.Append("@Title,@DateTime,@Content,@State,@Stander,@Category)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@Content", DbType.String,100),
                    new SQLiteParameter("@State",DbType.String,25),
                    new SQLiteParameter("@Stander",DbType.Int32,8),
                    new SQLiteParameter("@Category",DbType.String,25)};
            parameters[0].Value = task.Title;
            parameters[1].Value = task.DateTime;
            parameters[2].Value = task.Content;
            parameters[3].Value = task.State;
            parameters[4].Value = task.Stander;
            parameters[5].Value = task.Category;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        // 更新一条数据
        public bool Update(Entity.Task task)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TaskInfo set ");
            strSql.Append("Title=@Title,");
            strSql.Append("DateTime=@DateTime,");
            strSql.Append("Content=@Content,");
            strSql.Append("State=@State,");
            strSql.Append("Stander=@Stander,");
            strSql.Append("Category=@Category");
            strSql.Append(" where TaskId=@TaskId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@Content", DbType.String,100),
                    new SQLiteParameter("@State",DbType.String,25),
                    new SQLiteParameter("@Stander",DbType.Int32,8),
                    new SQLiteParameter("@Category",DbType.String,25),
                    new SQLiteParameter("@TaskId", DbType.Int32,8)};
            parameters[0].Value = task.Title;
            parameters[1].Value = task.DateTime;
            parameters[2].Value = task.Content;
            parameters[3].Value = task.State;
            parameters[4].Value = task.Stander;
            parameters[5].Value = task.Category;
            parameters[6].Value = task.TaskId;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        // 删除一条数据
        public bool Delete(int TaskId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TaskInfo ");
            strSql.Append(" where TaskId=@TaskId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@TaskId", DbType.Int32,8)          };
            parameters[0].Value = TaskId;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        //获得数据列表
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TaskId,Title,DateTime,Content,State,Stander,Category ");
            strSql.Append(" FROM TaskInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        //获取(完成、未完成)记录总数
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TaskInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where State='" + strWhere + "'");
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        public int GetStander(DateTime d1)
        {
            int d2 = DateTime.Now.Day;
            int d3 = (d2 == d1.Day) ? 0 : 1;
            return d3;
        }

        //按状态、时间排序，未完成、距离时间最近的排在前面
        public DataSet GetOrderedListByDateTime(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TaskId,Title,DateTime,Content,State,Stander,Category ");
            strSql.Append(" from TaskInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by DateTime asc");//desc
            return DbHelperSQLite.Query(strSql.ToString());
        }

        //获取所需的记录数（统计部份：年月季）
        public int GetRecordCount(string strWhere, int i )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TaskInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where State='" + strWhere+"' AND ");
                //当前年份
                int year = DateTime.Now.Year;
                string ys = "" + year;
                //当前月份
                int month = DateTime.Now.Month;
                string ms;
                if (month < 10)
                {
                    ms = "0" + month;
                }
                else
                {
                    ms = "" + month;
                }
                //当前季度
                int jidu = (month - 1) / 3;
                string ss=""+jidu;
                string[] str = new string[3];
                for(int k = 0; k < 3; k++)
                {
                    int temp = k + 1 + jidu * 3;
                    if (temp < 10)
                    {
                        str[k] = "0" + temp;
                    }
                    else
                    {
                        str[k] = "" + temp;
                    }
                }
                //当前月份日期
                int days = DateTime.Now.Day;
                string ds;
                if(days < 10)
                {
                    ds = "0" + days;
                }
                else
                {
                    ds = "" + days;
                }
                switch (i)
                {
                    case 0:
                        strSql.Append("strftime('%d', DateTime)='" + ds + "'");
                        //strSql.Append("strftime('%m', DateTime)='" + ms + "'");
                        break;
                    case 1:
                        strSql.Append("(strftime('%m', DateTime)='" + str[0] + "' OR ");
                        strSql.Append("strftime('%m', DateTime)='" + str[1] + "' OR ");
                        strSql.Append("strftime('%m', DateTime)='" + str[2] + "')");
                        break;
                    case 2:
                        strSql.Append("strftime('%Y', DateTime)='" + ys + "'");
                        break;
                }
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
        #endregion  BasicMethod
    }

    public partial class TasksService
    {
        private readonly TasksServiceDetail tsd = new TasksServiceDetail();
        public TasksService(){ }

        #region  BasicMethod

        public bool Add(Entity.Task task){return tsd.Add(task); }// 增加一条数据
        public bool Update(Entity.Task task){return tsd.Update(task); }// 更新一条数据
        public bool Delete(int taskid){return tsd.Delete(taskid); }// 删除一条数据
        public DataSet GetList(string strWhere){return tsd.GetList(strWhere);}// 获得数据列表-->获取全部数
        public int GetRecordCount(string strWhere){return tsd.GetRecordCount(strWhere);}// 获取记录总数
        public int GetRecordCount(string strWhere, int i) {return tsd.GetRecordCount(strWhere, i);}//按年季月
        public int GetStander(DateTime d1) { return tsd.GetStander(d1); }
        public DataSet GetOrderedListByDateTime(string strWhere) { return tsd.GetOrderedListByDateTime(strWhere); }

        #endregion  BasicMethod

    }
}
