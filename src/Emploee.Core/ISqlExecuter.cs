using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emploee
{
    public interface ISqlExecuter
    {        /// <summary>        /// 执行给定的命令  /// </summary>   
             /// <param name="sql">命令字符串</param> ///     
             /// <param name="parameters">要应用于命令字符串的参数</param> ///
             /// <returns>执行命令后由数据库返回的结果</returns>     
        int Execute(string sql, params object[] parameters);
        /// <summary>  /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。   /// </summary>            

        /// <typeparam name="T">查询所返回对象的类型</typeparam>        
        /// <param name="sql">SQL 查询字符串</param>       
        /// <param name="parameters">要应用于 SQL 查询字符串的参数</param>       
        /// <returns></returns>        

        IQueryable<T> SqlQuery<T>(string sql, params object[] parameters);

          DataTable SqlQueryForDataTatable(
                    string sql,
                    SqlParameter[] parameters);


        /// <summary>
        /// mysql生产
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
      DataTable MySqlQueryForDataTatable(string sql,
                    SqlParameter[] parameters);


        /// <summary>
        /// 动态行转列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="DimensionList"></param>
        /// <param name="DynamicColumn"></param>
        /// <param name="AllDynamicColumn"></param>
        /// <returns></returns>
        //List<dynamic> DynamicLinq<T>(List<T> list, List<string> DimensionList, string DynamicColumn, out List<string> AllDynamicColumn) where T : class;
    }
}