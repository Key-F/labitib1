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
        }
         
        static void work(bool islogistic) // Тут все соеденим
        {
            int k = 0; // Счетчик эпох
            List<epoha> Ep = new List<epoha>();
            //Ep[0].W = new double[5] { 0, 0, 0, 0, 0 };
            //int E = 1; // Пусть пока будет 1
            List<int[]> X = function.getx(4);
            int[] F = function.getF(X);
            do
            {
                epoha Ep_ = new epoha();
                
                Ep.Add(Ep_);
                Ep[0].W = new double[5] { 0, 0, 0, 0, 0 };
                Ep[k].nomer = k;
                Ep[k].Y = new int[16];
                double[] tempW = Ep[k].W;  
                for (int i = 0; i < 16; i++)
                {
                    double net1 = paramsNS.net(tempW, X[i]);
                    int outz = paramsNS.Outzn(net1);
                    
                    Ep[k].Y[i] = outz;
                    double dlta = paramsNS.delta(F[i], Ep[k].Y[i]);                  
                }
                Ep[k].E = paramsNS.totalerror(Ep_.Y, F);

                if (Ep[k].E != 0)
                {
                     epoha Epnext = new epoha(Ep[k].W);
                     Epnext.W = new double[5];
                     for (int i = 0; i < 16; i++)
                {
                    double net1 = paramsNS.net(tempW, X[i]);
                    int outz = paramsNS.Outzn(net1);
                    
                    double dlta = paramsNS.delta(F[i], Ep[k].Y[i]);


                    double[] bb = paramsNS.pereshetW(Epnext.W, X[i], net1, 0.3, dlta, islogistic);
                    
                }
                    k++;
                    Ep.Add(Epnext);
                   // double[] w = paramsNS.pereshetW(Ep[k].W, X[i], );
                }
            
               


                    k++;
               // Ep.Add(Ep_);


            } while (Ep[k].E != 0);
        }
    
   
    }
}
