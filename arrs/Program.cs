using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace arrs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //путь
            string inputpath = "D:\\SolutionsForSpaceApp\\2029\\input.txt";
            string outputpath = "D:\\SolutionsForSpaceApp\\2029\\output.txt";

            //создание файлов
            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();

            //переменная для обьвления размера массива#1
            int a;
            using (var readera = new StreamReader(inputpath))
            {
                a = Convert.ToInt32(readera.ReadLine());  // записываем в переменную
            };
            //запись в строку содержимого 2 строки файла
            string secondLine;
            using (var readersecond = new StreamReader(inputpath))
            {
                readersecond.ReadLine(); //пропуск 1 строки
                secondLine = readersecond.ReadLine();  // записываем в переменную
            }

            //запись из строки в массив строк с разделением
            string[] secondlineforint = secondLine.Split(' ');

            int[] A;
            A = new int[Convert.ToInt32(a)];
            List<int> B = new List<int>();

            //запись в массив из строки
            int count = 0;
            foreach (var s in secondlineforint)
            {
                if (count <= a)
                {
                    A[count] = Convert.ToInt32(s);
                    count++;
                }
            }
            for (int i = 0; i < A.Length; i++)
            {
                B.Add(A[i]);
            }

            for (int i = 0; i < B.Count; i++)
            {
                for (int j = 0; j < B.Count; j++)
                {
                    if (B[i] == B[j])
                    {
                        B.RemoveAt(j);
                    }
                }
            }


            using (var writer = new StreamWriter(outputpath))
            {
                writer.WriteLine(B.Count); 
                writer.Write(string.Join(" ", B)); 
            }
            


        }
    }
}
