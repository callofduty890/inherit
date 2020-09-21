using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Base关键字
{
    public class Person
    {
        public string name;public int age;
        public Person(string name,int age)
        {
            this.name = name;this.age = age;//基类构造函数赋值
        }

        public void print() //基类的实例方法
        {
            Console.WriteLine("name={0},age={1}", this.name, this.age);
        }
    }

    public class student : Person //派生类
    {
        public string studentID;
        public student(string name,int age,string id):base(name,age)
        {
            this.studentID = id;
        }

        public new void print() //new 隐藏父类的同名函数
        {
            base.print();//使用base关键字，调用基类的方法
            Console.WriteLine("studentID={0}", this.studentID);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            student objstudent = new student("李四", 18, "2020921");
            objstudent.print();
            Console.ReadKey();
        }
    }
}
