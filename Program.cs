using System;
using System.Collections.Generic;
using System.Linq;

namespace ThuatToanD3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.Write("Nhap so n: ");
            n = int.Parse(Console.ReadLine());
            if (n <= 0 || n > 10)
            {
                Console.WriteLine("Nhap so tu 1 den n < 10");
                Console.ReadKey();
                return;
            }
            int[,] arr = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = random.Next(10, 100);
                }
            }

            Console.WriteLine("Xuat ra man hinh ma tran ngau nhien");
            Print(arr, n);

            Console.WriteLine("Xuat ra man hinh cac bo giong nhau");
            BoGiongNhau(arr, n);
            Console.WriteLine("Xuat ra man hinh ma tran da sap xep");
            PrintOrder(arr, n);
            Console.ReadKey();
        }

        static void BoGiongNhau(int[,] arr, int n)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp.Add(arr[i, j]);
                }
            }
            var dis = temp.Distinct().OrderBy(x => x).ToList();

            foreach (var item in dis)
            {
                var find = temp.Where(x => x == item).ToList()?? new List<int>();
                if(find.Count >= 2)
                {
                    Console.WriteLine("So {0} xuat hien {1} lan", item, find.Count);
                }
            }
            Console.WriteLine();
        }
        static void Print(int[,] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintOrder(int[,] arr, int n)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp.Add(arr[i, j]);
                }
            }
            temp = temp.OrderBy(x => x).ToList();
            int index = 0;
            int k = 0;
            int[,] a = new int[n, n];
            foreach (var item in temp)
            {
                if (k < n)
                {
                    a[index, k] = item;
                    k++;
                }
                else
                {
                    index++;
                    k = 0;
                    a[index, k++] = item;
                }
            }

            Print(a, n);
        }
    }
}
