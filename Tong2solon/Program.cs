using System;
using System.Text;

namespace Tong2solon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập số thứ nhất: ");
            string so1 = Console.ReadLine();
            Console.Write("Nhập số thứ hai: ");
            string so2 = Console.ReadLine();
           // Console.WriteLine(Int32.Parse( Convert.ToString(so1[so1.Length - 1])));

            while (so1.Length != so2.Length)
            {
                if (so1.Length > so2.Length) so2 = "0" + so2;
                else so1 = "0" + so1;
            }
            
            string kq = ""; int du = 0; int tong = 0;

            while (so1.Length > 0 || so2.Length > 0)
            {
                //if (so1.Length == 0) so1 = "0";
                //if (so2.Length == 0) so1 = "0";
                
                int a = Convert.ToInt32(so1.Substring(so1.Length-1));
                int b = Convert.ToInt32(so2.Substring(so2.Length - 1));
                tong = (a + b + du) % 10;
                du = (a + b+ du) / 10;
                
                kq = tong + kq;

                so1 = so1.Substring(0, so1.Length - 1);
                so2 = so2.Substring(0, so2.Length - 1);
                if (so1.Length == 0&& du>0) kq = du + kq;

            }
            Console.WriteLine("kết quả: "+kq);
            Console.ReadKey();
        }
    }
}
