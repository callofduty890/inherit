using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLHelper
    {
        //编辑SQL Server数据库连接字符串
        readonly static string conString = @"Server=DESKTOP-CTV4ATU\SQLSERVER;DataBase=Admin_information;Uid=sa;pwd=123456";

        /// <summary>
        /// 执行 SQL查询命令，获取SqlDataReader结果对象
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(conString);//连接数据库
            SqlCommand cmd = new SqlCommand(sql, conn);//执行SQL语句
            try
            {
                conn.Open();//打开数据库
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//返回对象
            }
            catch (Exception)
            {
                //异常处理
                conn.Close();//关闭数据库
                throw;//错误信息抛出
            }
        }

        /// <summary>
        /// 执行 增删改 方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(conString);//连接数据库
            SqlCommand cmd = new SqlCommand(sql, conn);//执行SQL语句
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();//返回受影响的行数
            }
            catch (Exception)
            {
                //可以将错误的日志写入保存到txt当中
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}
