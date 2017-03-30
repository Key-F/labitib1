using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Math;


namespace itiblab1
{
    class paramsNS:epoha
    {
        
        public static double net(double[] w, int[] x)
        {
            double net = 0;
            for (int i = 0; i < 4; i++)
            {
                net = net + w[i] + x[i];
            }
            return net = net + w[4]; // + w0
        }
    
        public static int Outzn(double net) // f(net)
        {
            if (net > 0)
                return 1;
            else 
                return 0;             
        }
        public static double func(double net)
        {
            return 1 / (1 + Math.Exp(-net));
        }
        public static double delta(double t, double y)
        {
            return t - y;
        }

        public static double deltaporog(double n, double delta, double x)
        {
            return n * delta * x;
        }
        
        public static  double[] pereshetW(double[] w, int[] x, double net_, double nu, double delta_, bool islog)
        {
            //double[] w = w1.ToArray();
            
            if (islog == true)
                for (int i = 0; i < w.Length; i++)
                {
                    if (i == x.Count()) w[i] = w[i] + deltalogist(nu, delta_, net_, 1); // Последний будет для w0
                    else
                    w[i] = w[i] + deltalogist(nu, delta_, net_, x[i]);
                }
            else
                for (int i = 0; i < w.Length; i++)
                {
                    if (i == x.Count()) w[i] = w[i] + deltaporog(nu, delta_, 1); // Последний будет для w0
                    else
                    w[i] = w[i] + deltaporog(nu, delta_, x[i]);
                }
            return w;
        }
        public static double totalerror(int[] Y, int[] F)
        {
            double e = 0;
            for (int i = 0; i < Y.Length; i++) // У Y и F одинаковая длина
                if (Y[i] != F[i]) e++;
            return e;
        }
        public static double deltalogist(double n, double delta, double net, double x)
        {
             return n * delta * Outzn(net) * (1 - Outzn(net)) * x; // Производная от нашей логистической ФА
        }

    }

}
