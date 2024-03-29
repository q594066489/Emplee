﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocs.Npoi
{
    class SqltableHelper
    {
 

        #region 判断数据库中，指定表是否存在
        /// <summary>
        /// 判断数据库表是否存在
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="tb">数据表名</param>
        /// <param name="connKey">连接数据库的key</param>
        /// <returns>true:表示数据表已经存在；false，表示数据表不存在</returns>
        public Boolean IsTableExist(string db, string tb, string connKey)
        {
            // var sqlExecuter = Abp.Dependency.IocManager.Instance.Resolve<ISqlExecuter>();
            //var charts = _sqlExecuter.Execute("CREATE TABLE Customer(First_Name char(50),Last_Name char(50),Address char(50),City char(50),Country char(25),Birth_Date datetime)");

            //在指定的数据库中  查找 该表是否存在
            //DataTable dt = helper.ExecuteQuery(createDbStr, CommandType.Text);
            //if (dt.Rows.Count == 0)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            return false;
        }
        #endregion

  

        #region 创建数据库表
        /// <summary>
        ///  在指定的数据库中，创建数据表
        /// </summary>
        /// <param name="db">指定的数据库</param>
        /// <param name="dt">要创建的数据表</param>
        /// <param name="dic">数据表中的字段及其数据类型</param>
        /// <param name="connKey">数据库的连接Key</param>
        public void CreateDataTable(string db, string dt, Dictionary<string, string> dic, string connKey)
        {
            //SQLHelper helper = SQLHelper.GetInstance();

            //string connToMaster = ConfigurationManager.ConnectionStrings[connKey].ToString();

            ////判断数据库是否存在
            //if (IsDBExist(db, connKey) == false)
            //{
            //    throw new Exception("数据库不存在！");
            //}

            ////如果数据库表存在，则抛出错误
            //if (IsTableExist(db, dt, connKey) == true)
            //{
            //    throw new Exception("数据库表已经存在！");
            //}
            //else//数据表不存在，创建数据表
            //{
            //    //拼接字符串，（该串为创建内容）
            //    string content = "serial int identity(1,1) primary key ";
            //    //取出dic中的内容，进行拼接
            //    List<string> test = new List<string>(dic.Keys);
            //    for (int i = 0; i < dic.Count(); i++)
            //    {
            //        content = content + " , " + test[i] + " " + dic[test[i]];
            //    }

            //    //其后判断数据表是否存在，然后创建数据表
            //    string createTableStr = "use " + db + " create table " + dt + " (" + content + ")";

            //    helper.ExecuteNonQuery(createTableStr, CommandType.Text);
            //}
        }
        #endregion
    }
}
