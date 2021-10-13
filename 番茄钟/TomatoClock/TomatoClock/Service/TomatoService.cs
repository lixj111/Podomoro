using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
namespace TomatoClock.Service
{
    class TomatoServiceDetail
    {
        public bool Add(Entity.TomatoData tomatoData)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TomatoInfo");//有问题的地方
            strSql.Append("(Id,Month,DayofMonth,Title,Tomatos,TotalTime,Category)");
            strSql.Append(" values ");
            strSql.Append("(@Id,@Month,@DayofMonth,@Title,@Tomatos,@TotalTime,@Category)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Id", DbType.Int32),
                    new SQLiteParameter("@Month", DbType.Int32),
                    new SQLiteParameter("@DayofMonth", DbType.Int32),
                    new SQLiteParameter("@Title", DbType.String),
                    new SQLiteParameter("@Tomatos", DbType.Int32),
                    new SQLiteParameter("@TotalTime", DbType.Int32),
                    new SQLiteParameter("@Category", DbType.String)};
            parameters[0].Value = tomatoData.Id;
            parameters[1].Value = tomatoData.Month;
            parameters[2].Value = tomatoData.DayofMonth;
            parameters[3].Value = tomatoData.Title;
            parameters[4].Value = tomatoData.Tomatos;
            parameters[5].Value = tomatoData.TotalTime;
            parameters[6].Value = tomatoData.Category;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Month,DayofMonth,Title,Tomatos,TotalTime,Category ");
            strSql.Append(" FROM TomatoInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Tomatos) FROM TomatoInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where Month=" + strWhere + "");
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        public int GetRecordCountByDay(string strWhere)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Tomatos) FROM TomatoInfo ");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" where DayofMonth=" + strWhere + "");
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        public int GetTotalTimeRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(TotalTime) FROM TomatoInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where Month=" + strWhere + "");
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        public int GetTotalTimeRecordCountByDay(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(TotalTime) FROM TomatoInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where DayofMonth=" + strWhere + "");
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
    }
    public class TomatoService
    {
        private TomatoServiceDetail tsd = new TomatoServiceDetail();
        public TomatoService() { }
        public bool Add(Entity.TomatoData tomatoData) { return tsd.Add(tomatoData); }// 增加一条数据
        public DataSet GetList(string strWhere) { return tsd.GetList(strWhere); }// 获得数据列表
        public DataSet GetAllList() { return GetList(""); }// 获得全部数据列表
        public int GetRecordCount(string strWhere) { return tsd.GetRecordCount(strWhere); }
        public int GetRecordCountByDay(string strWhere) { return tsd.GetRecordCountByDay(strWhere); }
        public int GetTotalTimeRecordCount(string strWhere) { return tsd.GetTotalTimeRecordCount(strWhere)/60; }
        public int GetTotalTimeRecordCountByDay(string strWhere) { return tsd.GetTotalTimeRecordCountByDay(strWhere)/60; }
    }
}
