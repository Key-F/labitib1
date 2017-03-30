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
        //public int[] X; // Входной сигнал
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
    
        public epoha(double[] w)
        {
            double[] W = w.ToArray(); ;
           
        }
    }
}
