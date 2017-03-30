using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace itiblab1
{
    class Program
    {
        static void Main(string[] args)
        {

           // List<epoha> Ep = new List<epoha>();
           // epoha Ep_ = new epoha();
           // Ep.Add(Ep_);
           // Ep[0].W = new double[5] { 0, 0, 0, 0, 0 };
           // List<int[]> X = function.getx(4);
            //int[] F = function.getF(X);
            work(false);
            Console.ReadLine();
        }
         
        static void work(bool islogistic) // Тут все соеденим
        {
            int k = 0; // Счетчик эпох
            List<epoha> Ep = new List<epoha>();
            List<int[]> X = function.getx(4);
            int[] F = function.getF(X);
            double[] nextw = new double[5] { 0, 0, 0, 0, 0 }; // Значения для весов следующей эпохи
            do
            {
                
                //if (k > 15) Console.ReadLine();
                //if (Ep.Capacity < 1)
                /*{
                    epoha Ep_ = new epoha();
                    Ep.Add(Ep_);
                    Ep[0].W = new double[5] { 0, 0, 0, 0, 0 };
                }*/
                    epoha Ep_ = new epoha(nextw);
                    Ep.Add(Ep_);
                Ep[k].nomer = k;
                Ep[k].Y = new int[16];
                double[] tempW = Ep[k].W.ToArray(); 
                //double[] tempW = Ep[k].W;  
                for (int i = 0; i < 16; i++)
                {
                    double net1 = paramsNS.net(tempW, X[i]);
                    int outz = paramsNS.Outzn(net1);
                    
                    Ep[k].Y[i] = outz;
                    double dlta = paramsNS.delta(F[i], Ep[k].Y[i]);                  
                }
                Ep[k].E = paramsNS.totalerror(Ep[k].Y, F);

                if (Ep[k].E != 0)
                {
                    //epoha Epnext = new epoha(tempW, Ep[k].E);
                     //epoha Epnext = new epoha(Ep[k].W, Ep[k].E);
                    // Epnext.W = new double[5];
                     for (int i = 0; i < 16; i++)
                {
                    double net1 = paramsNS.net(tempW, X[i]);
                    int outz = paramsNS.Outzn(net1);
                    
                    double dlta = paramsNS.delta(F[i], Ep[k].Y[i]);


                    nextw = paramsNS.pereshetW(tempW, X[i], net1, 0.3, dlta, islogistic);
                    //double[] bb = paramsNS.pereshetW(Epnext.W, X[i], net1, 0.3, dlta, islogistic);
                    
                }
                    Ep[k].print();
                    k++;
                    //Ep.Add(Epnext);
                   // double[] w = paramsNS.pereshetW(Ep[k].W, X[i], );
                }
                
            
               
            } while (Ep[k-1].E != 0);
        }
    
   
    }
}
