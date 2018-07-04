using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GetHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();


            //Class3 cc = new Class3(2, 3);
            //Class3 cc2 = new Class3(1, 4);
            //Class3 cc3 = new Class3(3, 3);
            //ht.Add(cc, "test1");
            //ht.Add(cc2, "test2");
            //ht.Add(cc3, "test3");
            //cc.x = 5;  
            //foreach (var item in ht.Keys)
            //{
            //    Console.WriteLine(item.ToString());
            //    Console.WriteLine(ht[item]);
            //}

            var a = GetMd5Str("ASDASDASDASDASDASDASDASDASD");

            Console.WriteLine(a);
            Console.Read();  
        }

        public static string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
    }

    class Class3
    {
        public int x;
        int y;
        public Class3(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override int GetHashCode()
        {
            Console.WriteLine("判断hashcode");
            return x + y;
        }
        public override bool Equals(object obj)
        {
            Console.WriteLine("判断equals");
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return x.ToString() + y.ToString();
        }
    }  
}
