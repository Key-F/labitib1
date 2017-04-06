using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itiblab1
{
    class function
    {
        public static bool ConvertTntToBool(int x)
        {
            if ((x != 0) && (x != 1)) throw new System.ArgumentException("Значение аргументов не равно 1 или 0");
            if (x == 1) return true;            
            else return false;
        }
        public static int ConvertBoolToInt(bool x)
        {
            if ((x != false) && (x != true)) throw new System.ArgumentException("Значение аргументов не равно true или false");
            if (x == true) return 1;
            else return 0;
        }
        public static bool countfunc(bool x1, bool x2, bool x3, bool x4)
        {
            
            return !(!x3 && x4 && (!x1 || x2));
        }
        public static int[] getF(List<int[]> X) // Получаем значение функции на наборах
        {
            int[] F = new int[X.Count];
            for (int i = 0; i < X.Count; i++)
            {
                bool temp = countfunc(ConvertTntToBool(X[i][0]), ConvertTntToBool(X[i][1]), ConvertTntToBool(X[i][2]), ConvertTntToBool(X[i][3]));
                F[i] = Convert.ToInt32(temp);
            }
            return F;
        }
        public static List<int[]> getx(int n) // лучше список векторов
        {
            string temp; // Переменная для приписывания слева нулей  
            char[] temp2;
            int kol = Convert.ToInt32(Math.Pow(2, n)); // 2^n
            List<int[]> getx = new List<int[]>();

            for (int i = 0; i < kol; i++)
            {
                int[] temp1 = new int[n]; // массив значений x1, x2, x3, x4 ...
                temp = (Convert.ToString(i, 2));
                if (temp.Length < n)
                {
                    do
                        temp = '0' + temp; // добавляем слева нулей
                    while (temp.Length < n);
                }
                temp2 = temp.ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    temp1[j] = Convert.ToInt32(temp2[j].ToString());
                }

                getx.Add(temp1);
            }

            return getx;
        }


            public static List<int[]> getx2(int n, int kolv) // лучше список векторов, kolv - количество векторов
        {
            string temp; // Переменная для приписывания слева нулей  
            char[] temp2;
            //int kol = Convert.ToInt32(Math.Pow(2, n)); // 2^n
            List<int[]> getx2 = new List<int[]>();
           
          
            for (int i = 0; i < 16; i++)
            {
                int[] temp1 = new int[n]; // массив значений x1, x2, x3, x4 ...
                temp = (Convert.ToString(i, 2));
                if (temp.Length < n)
                {
                    do
                        temp = '0' + temp; // добавляем слева нулей
                    while (temp.Length < n);                                      
                }
                temp2 = temp.ToCharArray(); 
                for (int j = 0; j < n; j++)
                {
                    temp1[j] = Convert.ToInt32(temp2[j].ToString());
                }

                getx2.Add(temp1);    
                
            }
            List<int[]> getx3 = new List<int[]>();
            int[] curN; // массив для получения результатов
            PereborVariantov v = new PereborVariantov(kolv, 16);
            while (v.GetNext(out curN)) // получили в curN значения индексов
            {
                for (int i = 0; i < curN.Length; i++) getx3.Add(getx2[curN[i]]);
                Console.WriteLine();
            }
            return getx3;
             
             
        }
    }
}
