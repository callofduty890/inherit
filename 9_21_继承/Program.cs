﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;//引用自己写好的数据库DLL
using TXT_ClassLibrary;//引用自己写好的数据库DLL
using INI_ClassLibrary;//引用自己写好的数据库DLL


namespace _9_21_继承
{
    //定义一个数据类
    class AdminLogin   //等同于 class AdminLogin:Object
    {
        private string account;//账号
        private string passwords;//密码
        private string powers;//权限

        public string Account { get => account; set => account = value; }
        public string Passwords { get => passwords; set => passwords = value; }
        public string Powers { get => powers; set => powers = value; }
    } // [基类/父类]

    class AdminLoginEx : AdminLogin //   [派生类/子类]
    {
        private string _name;//拥有人姓名
        private string _phone_Number;//电话号码

        public string Name { get => _name; set => _name = value; }
        public string Phone_Number { get => _phone_Number; set => _phone_Number = value; }
    }

    class AdminLoginSuperEx:AdminLoginEx
    {
        
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

            //进行数据库操作的日志记录
            string information =DateTime.Now.ToString() +"： 执行SQL语句 "+sql;
            Console.WriteLine(information);
            //向txt中写入信息
            TXT.write_txt("Log_Save.txt",information);

            //向数据库发起请求
            SqlDataReader objReader= SQLHelper.SQLHelper.GetReader(sql);

            //判断是否有内容
            if (objReader.Read())
            {
                TXT.write_txt("Log_Save.txt", DateTime.Now.ToString() + "：SQL查询成功");
                objAdmin.Powers = (string)objReader["powers"];//获取对应的权限
                return objAdmin;//取到对应的值，返回对象(账号/密码/权限)
            }
            else
            {
                TXT.write_txt("Log_Save.txt", DateTime.Now.ToString() + "：SQL查询没有找到对应的账号密码");
                return objAdmin = null;//返回NULL说明没有对应的账号
            }

        }
        static void Main(string[] args)
        {
            //测试INI的写入操作

            //保存绝对路径
            string Save_File = System.AppDomain.CurrentDomain.BaseDirectory + "数据库配置.ini";

            Console.WriteLine("Save_File:{0}", Save_File);
            INI.WritePrivateProfileString("数据库配置信息", "数据库地址", @"DESKTOP-CTV4ATU\SQLSERVER", Save_File);
            INI.WritePrivateProfileString("数据库配置信息", "数据库名称", "Admin_information", Save_File);
            INI.WritePrivateProfileString("数据库配置信息", "账号", "Admin", Save_File);
            INI.WritePrivateProfileString("数据库配置信息", "密码", "123456", Save_File);

            //读取的操作
            string Server = INI.ContentValue("数据库配置信息", "数据库地址", Save_File);
            string DataBase = INI.ContentValue("数据库配置信息", "数据库名称", Save_File);
            string Uid= INI.ContentValue("数据库配置信息", "账号", Save_File);
            string pwd = INI.ContentValue("数据库配置信息", "密码", Save_File);

            Console.WriteLine("Server={0}", Server);
            Console.WriteLine("DataBase={0}", DataBase);
            Console.WriteLine("Uid={0}", Uid);
            Console.WriteLine("pwd={0}", pwd);

            ////提示输入账号与密码
            //Console.WriteLine("请输入账号:");
            //string account=  Console.ReadLine();
            //Console.WriteLine("请输入密码:");
            //string password = Console.ReadLine();

            ////创建数据对象
            //AdminLogin admin = new AdminLogin();
            //admin.Account = account;
            //admin.Passwords = password;

            ////验证账号和密码数据库中是否存在
            //admin = Login(admin);
            //if (admin != null)
            //{
            //    Console.WriteLine("登录成功!,您的权限为{0}", admin.Powers);
            //}
            //else
            //{
            //    Console.WriteLine("登录失败,请检查账号密码");
            //}

            Console.ReadLine();//卡屏
        }
    }
}
