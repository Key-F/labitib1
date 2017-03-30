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
            work(true);
            work(false);
            //work(true);
            Console.ReadLine();
        }
         
        static void work(bool islogistic) // Тут все соеденим
        {
            int k = 0; // Счетчик эпох
            double prost = 1; // Штука для останоки
            List<epoha> Ep = new List<epoha>();
            List<int[]> X = function.getx(4);
            int[] F = function.getF(X);
            double[] dlta = new double[16];
            double[] net1 = new double[16];
            double[] nextw = new double[5] { 0, 0, 0, 0, 0 }; // Значения для весов следующей эпохи            
                do
                {
                    //if (k > 15) Console.ReadLine();
                    epoha Ep_ = new epoha(nextw);
                    Ep.Add(Ep_);
                    Ep[k].nomer = k;
                    Ep[k].Y = new int[16];
                    //double[] tempW = Ep[k].W.ToArray();
                    double[] tempW = nextw.ToArray();
                    //double[] tempW = Ep[k].W;  
                    for (int i = 0; i < 16; i++)
                    {
                        net1[i] = paramsNS.net(tempW, X[i]);
                        int outz = paramsNS.Outzn(net1[i]);
                        Ep[k].Y[i] = outz;
                    }
                    Ep[k].E = paramsNS.totalerror(Ep[k].Y, F);

                    if (Ep[k].E != 0)
                    {
                        //epoha Epnext = new epoha(tempW, Ep[k].E);
                        //epoha Epnext = new epoha(Ep[k].W, Ep[k].E);
                        // Epnext.W = new double[5];
                        for (int i = 0; i < 16; i++)
                        {
                            net1[i] = paramsNS.net(tempW, X[i]);
                            int outz = paramsNS.Outzn(net1[i]);

                            dlta[i] = paramsNS.delta(F[i], Ep[k].Y[i]);


                            nextw = paramsNS.pereshetW(tempW, X[i], net1[i], 0.3, dlta[i], islogistic);
                            //double[] bb = paramsNS.pereshetW(Epnext.W, X[i], net1, 0.3, dlta, islogistic);

                        }
                        //Ep[k].print();
                        
                        

                        //Ep.Add(Epnext);
                        // double[] w = paramsNS.pereshetW(Ep[k].W, X[i], );
                    }
                    prost = Ep[k].E;
                    Ep[k].print();
                    k++;
                    
                    


                } while (prost != 0);
            
        }
    
   
    }
}
