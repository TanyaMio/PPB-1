using System;
using System.Threading;

/*--------------------------------------------
 * -- Lab 3 Var 12
 * -- F1: E = MAX(A)*(X+B*(MA*MD)+C)
 * -- F2: ML = SORT(TRANS(MF)*MK)
 * -- F3: S = SORT(O*MO)*(MS*MT)
 * -- Diachenko Tetiana IV-81
 * -- Date 08.10.2020
 * --------------------------------------------*/

namespace PPB_Lab_3
{
    internal class Lab3
    {
        static Data data = new Data(1000);
        static Semaphore sem = new Semaphore(1, 1);
        
        public static void Main(string[] args)
        {
            Console.WriteLine("-- Lab3 has started.");
            
            Thread T1 = new Thread(Thread1);
            T1.Priority = ThreadPriority.AboveNormal;

            Thread T2 = new Thread(Thread2);
            T2.Priority = ThreadPriority.BelowNormal;
            
            Thread T3 = new Thread(Thread3);
            T3.Priority = ThreadPriority.Normal;
            
            T1.Start();
            T2.Start();
            T3.Start();

            T1.Join();
            T2.Join();
            T3.Join();
            
            Console.WriteLine("-- Lab3 has finished.");
        }

        static void Thread1()
        {
            Console.WriteLine("-- T1 has started.");
            int n = data.GetN();
            int f = 1;
            int[] A = new int[n];
            int[] B = new int[n];
            int[] C = new int[n];
            int[] X = new int[n];
            int[,] MA = new int[n, n];
            int[,] MD = new int[n, n];
            int[] E;
            String ans;
            if(n < 7){
                Thread.Sleep(200);
                Console.WriteLine("-- T1 is waiting for console.");
                sem.WaitOne();
                    Console.WriteLine("-- T1 is using console.");
                    Console.WriteLine("-- F1: E = MAX(A)*(X+B*(MA*MD)+C)");
                    Console.WriteLine("Do you want to enter elements manually? (if no then everything will be filled with " + f + " (y/n)");
                    ans = Console.ReadLine();
                    if(String.Compare(ans, "y", StringComparison.Ordinal) == 0){
                        Console.WriteLine("Input elements of vector A one-by-one:");
                        data.Vector_Input(A);
                        Console.WriteLine("Input elements of vector B one-by-one:");
                        data.Vector_Input(B);
                        Console.WriteLine("Input elements of vector C one-by-one:");
                        data.Vector_Input(C);
                        Console.WriteLine("Input elements of vector X one-by-one:");
                        data.Vector_Input(X);
                        Console.WriteLine("Input elements of matrix MA one-by-one:");
                        data.Matrix_Input(MA);
                        Console.WriteLine("Input elements of matrix MD one-by-one:");
                        data.Matrix_Input(MD);
                    } else {
                        data.Vector_Fill(A, f);
                        data.Vector_Fill(B, f);
                        data.Vector_Fill(C, f);
                        data.Vector_Fill(X, f);
                        data.Matrix_Fill(MA, f);
                        data.Matrix_Fill(MD, f);
                    }
                sem.Release(); 
                Console.WriteLine("\n\n-- T1 has left console.");
            } else {
                data.Vector_Fill(A, f);
                data.Vector_Fill(B, f);
                data.Vector_Fill(C, f);
                data.Vector_Fill(X, f);
                data.Matrix_Fill(MA, f);
                data.Matrix_Fill(MD, f);
            }
            E = data.Func1(A, B, C, X, MA, MD);
            Thread.Sleep(1500);

            if(n < 7){
                Console.WriteLine("-- T1 is waiting for console.");
                sem.WaitOne();
                    Console.WriteLine("-- T1 is using console.\n-- F1: E = MAX(A)*(X+B*(MA*MD)+C)");
                    data.Vector_Print(E);
                    Console.WriteLine("\n");
                sem.Release();
                Console.WriteLine("-- T1 has left console.");
            }

            Console.WriteLine("-- T1 has finished.");
        }

        static void Thread2()
        {
            Console.WriteLine("-- T2 has started.");
            int n = data.GetN();
            int f = 1;
            int[,] MF = new int[n, n];
            int[,] MK = new int[n, n];
            int[,] ML;
            String ans;
            if(n < 7){
                Thread.Sleep(200);
                Console.WriteLine("-- T2 is waiting for console.");
                sem.WaitOne();
                    Console.WriteLine("-- T2 is using console.");
                    Console.WriteLine("-- F2: ML = SORT(TRANS(MF)*MK)");
                    Console.WriteLine("Do you want to enter elements manually? (if no then everything will be filled with " + f + " (y/n)");
                    ans = Console.ReadLine();
                    if(String.Compare(ans, "y", StringComparison.Ordinal) == 0){
                        Console.WriteLine("Input elements of matrix MF one-by-one:");
                        data.Matrix_Input(MF);
                        Console.WriteLine("Input elements of matrix MK one-by-one:");
                        data.Matrix_Input(MK);
                    } else {
                        data.Matrix_Fill(MF, f);
                        data.Matrix_Fill(MK, f);
                    }
                sem.Release();
                Console.WriteLine("-- T2 has left console.");
            } else {
                data.Matrix_Fill(MF, f);
                data.Matrix_Fill(MK, f);
            }
            ML = data.Func2(MF, MK);
            Thread.Sleep(1500);

            if(n < 7){
                Console.WriteLine("-- T2 is waiting for console.");
                sem.WaitOne();
                    Console.WriteLine("-- T2 is using console.\n-- F2: ML = SORT(TRANS(MF)*MK)");
                    data.Matrix_Print(ML);
                    Console.WriteLine("\n");
                sem.Release();
                Console.WriteLine("-- T2 has left console.");
            }

            Console.WriteLine("-- T2 has finished.");
        }

        static void Thread3()
        {
            Console.WriteLine("-- T3 has started.");
            int f = 1;
            int n = data.GetN();
            int[] O = new int[n];
            int[] S;
            int[,] MO = new int[n, n];
            int[,] MS = new int[n, n];
            int[,] MT = new int[n, n];
            String ans;
            if(n < 7){
                Thread.Sleep(200);
                Console.WriteLine("-- T3 is waiting for console.");
                sem.WaitOne();
                    Console.WriteLine("-- T3 is using console.");
                    Console.WriteLine("-- F3: S = SORT(O*MO)*(MS*MT)");
                    Console.WriteLine("Do you want to enter elements manually? (if no then everything will be filled with " + f + " (y/n)");
                    ans = Console.ReadLine();
                    if(String.Compare(ans, "y", StringComparison.Ordinal) == 0){
                        Console.WriteLine("Input elements of vector O one-by-one:");
                        data.Vector_Input(O);
                        Console.WriteLine("Input elements of matrix MO one-by-one:");
                        data.Matrix_Input(MO);
                        Console.WriteLine("Input elements of matrix MS one-by-one:");
                        data.Matrix_Input(MS);
                        Console.WriteLine("Input elements of matrix MT one-by-one:");
                        data.Matrix_Input(MT);
                    } else {
                        data.Vector_Fill(O, f);
                        data.Matrix_Fill(MO, f);
                        data.Matrix_Fill(MS, f);
                        data.Matrix_Fill(MT, f);
                    }
                sem.Release();
                Console.WriteLine("\n\n-- T3 has left console.");
            } else {
                data.Vector_Fill(O, f);
                data.Matrix_Fill(MO, f);
                data.Matrix_Fill(MS, f);
                data.Matrix_Fill(MT, f);
            }
            S = data.Func3(O, MO, MS, MT);
            Thread.Sleep(1500);

            if(n < 7){
                Console.WriteLine("-- T3 is waiting for console.");
                sem.WaitOne();
                    Console.WriteLine("-- T3 is using console.\n-- F3: S = SORT(O*MO)*(MS*MT)");
                    data.Vector_Print(S);
                    Console.WriteLine("\n");
                sem.Release();
                Console.WriteLine("-- T3 has left console.");
            }
            Console.WriteLine("-- T3 has finished.");
        }
    }
}