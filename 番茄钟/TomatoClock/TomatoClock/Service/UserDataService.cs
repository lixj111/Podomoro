using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using TomatoClock.Entity;

namespace TomatoClock.Service
{
    public partial class UserDataServiceDetails
    {
        public UserDataServiceDetails() { }

        #region Basic Methon

        public void UpdatePreference(Entity.UserData oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Preference=@Preference");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Preference", DbType.Int32,8)};
            parameters[0].Value = oth.Preference;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetPreferenceList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Preference ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public void UpdateMusic(Entity.UserData oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Music_path=@Music_path");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Music_path", DbType.String,200)};
            parameters[0].Value = oth.Music_path;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetMusic_pathList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Music_path ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public void UpdateAchievement_unit(Entity.UserData oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Achievement_unit=@Achievement_unit");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Achievement_unit", DbType.Int32,8)};
            parameters[0].Value = oth.Achievement_unit;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetAchievement_unitList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Achievement_unit ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public void UpdateTheme_path(Entity.UserData oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Theme_path=@Theme_path");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Theme_path", DbType.String,200)};
            parameters[0].Value = oth.Theme_path;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetTheme_pathList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Theme_path ");
            strSql.Append(" FROM Others ");
            strSql.Append($" where OthersId={OthesId} ");
            return DbHelperSQLite.Query(strSql.ToString());
        }
        #endregion Basic Region
    }
}