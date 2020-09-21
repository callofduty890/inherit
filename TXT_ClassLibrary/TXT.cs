using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXT_ClassLibrary
{
    public class TXT
   {
        /// <summary>
        /// 写入TXT文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="str">字符串内容</param>
        public static void write_txt(string path, string str)
        {
            using (StreamWriter sr2= new StreamWriter(path,true,Encoding.UTF8))
            {
                sr2.WriteLine(str);
                sr2.Close();
            }

        }
        //完成读取TXT文件

    }
}
