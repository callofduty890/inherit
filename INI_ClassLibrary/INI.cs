using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace INI_ClassLibrary
{
    public class INI
    {

        /// <summary>
        /// 写入INI配置文件
        /// </summary>
        /// <param name="section">根节点</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        /// <summary>
        /// 读取INI配置文件
        /// </summary>
        /// <param name="section">根节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">默认返回值(没有查找的返回的内容)</param>
        /// <param name="retval">返回的字符串对象</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval,int size, string filePath);

        //对读取进行二次封装->提高代码的可用性
        public static string ContentValue(string section, string key, string strFilePath)
        {
            //新建可变字符串空间
            StringBuilder temp = new StringBuilder(1024);//申请1MB的空间储存字符串
            //传入DLL函数当中接收返回值
            GetPrivateProfileString(section, key, "NULL", temp, 1024, strFilePath);
            //返回内容
            return temp.ToString();
        }

    }
}
