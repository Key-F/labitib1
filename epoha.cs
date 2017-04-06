using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itiblab1
{
    class epoha
    {
        public int nomer;
        public int[] Y; // Выходной сигнал
        public double[] W; // Вектор весов
        public double E; // Суммарная ошибка

        /*public epoha(int n) 
        {
             nomer = 0;
             int[] X = new int[n]; // Входной сигнал
             int[] Y = new int[n]; ; // Выходной сигнал
             double[] W = new double[n + 1]; // Вектор весов, один для w0
             E = 0; 
        }*/
        public epoha() { }
       

        public void print() 
        {
            Console.WriteLine("Номер эпохи:" + nomer);
            Console.Write("Y: ");
            for (int i = 0; i < Y.Length; i++) Console.Write(Convert.ToString(Y[i]) + "  ");
            Console.WriteLine();
            Console.Write("W: ");
            for (int i = 0; i < W.Length; i++) Console.Write(Convert.ToString(W[i]) + "  ");
            Console.WriteLine();
            Console.WriteLine("E: " + E);
            Console.WriteLine();
        }
    
        public epoha(double[] w, double e)
        {
            E = e;
            W = w.ToArray(); 
           
        }
        public epoha(double[] w)
        {

            W = w.ToArray(); 

        }
    }
}

