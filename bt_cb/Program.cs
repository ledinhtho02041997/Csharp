using System;
using System.Text.RegularExpressions;

namespace bt_cb
{

    class Program
    {
        static void Main(string[] args)
        {
            string kq="";
            int[] mang = new int[1000];
            int k =Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            //Console.WriteLine(s.Substring(5,1));//lấy 1 tự từ xâu thành xâu   
            int i = 0;int tg = 0;
            for (int j=0;j<s.Length;j++)
                if (char.IsDigit(s[j]))
                    kq = kq + s.Substring(j, 1);
            for (i=0;i<kq.Length;i++) mang[i] = Convert.ToInt32(kq.Substring(i, 1));
            for (i=0;i<kq.Length-1;i++) 
                for (int j=i+1;j<kq.Length;j++)
                if (mang[i]>mang[j])
                    {
                     tg = mang[i];
                    mang[i] = mang[j];
                        mang[j] = tg;
                    }
            i = 1;
            if (mang[1] == 0)
                while (mang[i] == 0) i++; 
            {
                tg = mang[1];
                mang[1] = mang[i];
                mang[i] = tg;
            }
            for (i = 0; i < k; i++) Console.Write(mang[i]);
            Console.ReadKey();
        }
    }
}
