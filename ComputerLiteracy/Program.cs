using System.Collections.Generic;
namespace ComputerLiteracy
{
    public enum Birthplace { Aomori,Akita,Iwate,Yamagata,Miyagi,Fukushima};


    public class Student
    {
        public string Name { get; set; }
        public  Birthplace birthplace{ get; set; }
        public Student(string n, Birthplace b )
        {
            Name = n;
            birthplace = b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> game1 =new Dictionary<string, Student>();
            game1.Add("242J011", new Student("阿部 遥登",Birthplace.Miyagi));

            /*
            game1.Add("242J011","阿部 遥登");
            game1.Add("242J004","伊藤 藍樹");
            game1.Add("242J001", "小椋 優斗");
            game1.Add("242J002", "鈴木 智大");
            game1.Add("242J007", "高野 一真");
            game1.Add("242J005", "高橋 拓真");
            game1.Add("242J006", "田口 薫");
            game1.Add("242J003", "鴇田 千理");
            game1.Add("242J010", "長根 旺生");
            game1.Add("242J009", "平間 翔太");
            game1.Add("242J008", "髙橋 紗弥");
            */

            Console.WriteLine(game1["242J011"]);

        }
    }
}
