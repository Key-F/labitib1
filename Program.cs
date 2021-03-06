﻿using System;
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
            List<epoha> E = new List<epoha>();
            //work(true);
            //E = work(false);
            int trigger = 0;
            int kol = 1;
            int[] curN; // массив для получения результатов
            do
            {
                int[] vektor = new int[kol];
                PereborVariantov v = new PereborVariantov(kol, 16);
                kol++;
                while (v.GetNext(out curN)) // получили в curN значения индексов
                {
                    for (int i = 0; i < curN.Length; i++)
                    {
                        vektor[i] = curN[i];
                        //perebor(false, curN[i]);
                       // Console.Write(curN[i] + "  ");
                    }
                    if (perebor(false, vektor) == true)
                    {
                        int tekkol = kol - 1; // Истинное значение количества
                    Console.WriteLine("Количество векторов: " + tekkol); 
                    Console.Write("Номера векторов, на которых обучаем: ");
                    for (int i = 0; i < vektor.Length; i++)
                    {
                        Console.Write(vektor[i] + "  ");
                    }
                    Console.WriteLine();

                    trigger = 1;
                    }
                }
            } while (trigger != 1);
            //perebor(false);
            Console.ReadLine();
        }
        
        static List<epoha> work(bool islogistic) // Тут все соеденим
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
                    epoha Ep_ = new epoha(nextw);
                    Ep.Add(Ep_);
                    Ep[k].nomer = k;
                    Ep[k].Y = new int[16];
                    double[] tempW = nextw.ToArray();  
                    for (int i = 0; i < 16; i++)
                    {
                        net1[i] = paramsNS.net(tempW, X[i]);
                        int outz = paramsNS.Outzn(net1[i]);
                        Ep[k].Y[i] = outz;
                    }
                    Ep[k].E = paramsNS.totalerror(Ep[k].Y, F);

                    if (Ep[k].E != 0)
                    {                        
                        for (int i = 0; i < 16; i++)
                        {
                            net1[i] = paramsNS.net(tempW, X[i]);
                            int outz = paramsNS.Outzn(net1[i]);
                            dlta[i] = paramsNS.delta(F[i], Ep[k].Y[i]);
                            nextw = paramsNS.pereshetW(tempW, X[i], net1[i], 0.3, dlta[i], islogistic);                     
                        }
                    }
                    prost = Ep[k].E;
                    Ep[k].print();
                    k++;                                      
                } while (prost != 0);
                return Ep;
            
        }
        static bool perebor(bool islogistic, int[] vektor)
        {
            int kolvektorov = 0; // Количество векторов, на которых происходит обучение

            List<int[]> X = function.getx(4); // Наборы аргументов
            int[] F = function.getF(X); // Получили функцию от 4х переменных

            

            
            
            double prost = 1; // Штука для останоки
           
            
            do 
            {
                //kolvektorov++;
                kolvektorov = vektor.Length;
                int k = 0; // Счетчик эпох
                //List<int[][]> combination = new List<int[][]>(); // Список, хранящий текущую комбинацию аргументов + их номер  
                //combination = function.getx2(kolvektorov, 16); // получаем набор векторов, перебрать все варианты в kolvektorov из 16
                int[] combination = vektor; // Получаем массив индексов наборов, которые будем использовать
            
                List<epoha> Ep = new List<epoha>();
            double[] dlta = new double[kolvektorov];
            double[] net1 = new double[kolvektorov];
            double[] nextw = new double[5] { 0, 0, 0, 0, 0 }; // Значения для весов следующей эпохи            
            do
            {
                
                epoha Ep_ = new epoha(nextw);
                Ep.Add(Ep_);
                Ep[k].nomer = k;
                Ep[k].Y = new int[kolvektorov];
                
                double[] tempW = nextw.ToArray();
                 
                for (int i = 0; i < kolvektorov; i++)
                {
                    net1[i] = paramsNS.net(tempW, X[combination[i]]); // считаем от нужной комбинации
                    int outz = paramsNS.Outzn(net1[i]);
                    Ep[k].Y[i] = outz;
                }
                int[] newf = new int[kolvektorov];
                for (int i = 0; i < kolvektorov; i++)
                    newf[i] = F[combination[i]];      // Новая функция, только на нужных наборах
                {

                }
                Ep[k].E = paramsNS.totalerror(Ep[k].Y, newf);

                if (Ep[k].E != 0)
                {                  
                    for (int i = 0; i < kolvektorov; i++)
                    {
                        net1[i] = paramsNS.net(tempW, X[combination[i]]);
                        int outz = paramsNS.Outzn(net1[i]);
                        dlta[i] = paramsNS.delta(newf[i], Ep[k].Y[i]);
                        nextw = paramsNS.pereshetW(tempW, X[combination[i]], net1[i], 0.3, dlta[i], islogistic);                        
                    }
                    
                }
                prost = Ep[k].E;
                //Ep[k].print();
                k++;               
                //if (Ep[k].E == 0) Ep[k].print();
            } while ((k < 200)&&(prost != 0));
            
              
               
            if (function.test(combination, F, Ep[k-1].W, X) == true)
            {
                Ep[k-1].print();
                return true;

            }
            else return false;
        } while (prost != 0);

         }
      }
   }
        
      

