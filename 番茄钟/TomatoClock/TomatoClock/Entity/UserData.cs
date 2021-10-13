using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomatoClock.Entity
{
    public class UserData
    {
        public int OthersId { get; set; }//用户数据Id
        public int Preference { get; set; }//用户偏好
        public string Music_path { get; set; }//铃声路径
        public int Achievement_unit { get; set; }//统计界面单位
        public string Theme_path { get; set; }//主题路径

        public UserData() { }
        public UserData(int othersid, int preference, string music_path,int achievement_unit, string theme_path):this()
        {
            this.OthersId = othersid;
            this.Preference = preference;
            this.Music_path = music_path;
            this.Achievement_unit = achievement_unit;
            this.Theme_path = theme_path;
        }
    }
}
