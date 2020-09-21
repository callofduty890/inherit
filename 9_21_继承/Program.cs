using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;//引用自己写好的数据库DLL

namespace _9_21_继承
{
    //定义一个数据类
    class AdminLogin
    {
        private string account;//账号
        private string passwords;//密码
        private string powers;//权限

        public string Account { get => account; set => account = value; }
        public string Passwords { get => passwords; set => passwords = value; }
        public string Powers { get => powers; set => powers = value; }
    }

    class Program
    {
        /// <summary>
        /// 验证账号密码
        /// </summary>
        /// <param name="objAdmin">数据类</param>
        /// <returns>数据对象(NULL/账号密码权限)</returns>
        public static AdminLogin Login(AdminLogin objAdmin)
        {
            //形成SQL语句
            string sql = "select powers from information where account='{0}' and passwords='{1}'";
            sql = string.Format(sql,objAdmin.Account, objAdmin.Passwords);

            //向数据库发起请求
            SqlDataReader objReader= SQLHelper.SQLHelper.GetReader(sql);

            //判断是否有内容
            if (objReader.Read())
            {
                objAdmin.Powers = (string)objReader["powers"];//获取对应的权限
                return objAdmin;//取到对应的值，返回对象(账号/密码/权限)
            }
            else
            {
                return objAdmin = null;//返回NULL说明没有对应的账号
            }

        }
        static void Main(string[] args)
        {
            //提示输入账号与密码
            Console.WriteLine("请输入账号:");
            string account=  Console.ReadLine();
            Console.WriteLine("请输入密码:");
            string password = Console.ReadLine();

            //创建数据对象
            AdminLogin admin = new AdminLogin();
            admin.Account = account;
            admin.Passwords = password;

            //验证账号和密码数据库中是否存在
            admin = Login(admin);
            if (admin != null)
            {
                Console.WriteLine("登录成功!,您的权限为{0}", admin.Powers);
            }
            else
            {
                Console.WriteLine("登录失败,请检查账号密码");
            }

            Console.ReadLine();//卡屏
        }
    }
}
