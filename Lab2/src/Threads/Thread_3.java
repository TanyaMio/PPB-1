package Threads;
/** -- F3: S = SORT(O*MO)*(MS*MT) **/

import Data.Data;

import java.util.concurrent.Semaphore;

public class Thread_3 extends Thread{
    private Data data;
    private Semaphore sem;
    private int n;

    public Thread_3(Data d, Semaphore s){
        this.data = d;
        this.sem = s;
        this.n = d.getN();
    }

    public void run() {
        System.out.println("-- T3 has started.");
        int f = 1;
        int[] O = new int[n];
        int[] S;
        int[][] MO = new int[n][n];
        int[][] MS = new int[n][n];
        int[][] MT = new int[n][n];
        String ans;
        try {
            if(n < 7){
                sleep(200);
                System.out.println("-- T3 is waiting for console.");
                sem.acquire();
                System.out.println("-- T3 is using console.");
                System.out.println("-- F3: S = SORT(O*MO)*(MS*MT)");
                System.out.println("Do you want to enter elements manually? (if no then everything will be filled with " + f + " (y/n)");
                ans = data.getScanner().next();
                if(ans.equals("y")){
                    System.out.println("Input elements of vector O one-by-one:");
                    data.Vector_Input(O);
                    System.out.println("Input elements of matrix MO one-by-one:");
                    data.Matrix_Input(MO);
                    System.out.println("Input elements of matrix MS one-by-one:");
                    data.Matrix_Input(MS);
                    System.out.println("Input elements of matrix MT one-by-one:");
                    data.Matrix_Input(MT);
                    sem.release();
                    System.out.println("\n\n-- T3 has left console.");
                } else {
                    sem.release();
                    System.out.println("-- T3 has left console.");
                    data.Vector_Fill(O, f);
                    data.Matrix_Fill(MO, f);
                    data.Matrix_Fill(MS, f);
                    data.Matrix_Fill(MT, f);
                }
            } else {
                data.Vector_Fill(O, f);
                data.Matrix_Fill(MO, f);
                data.Matrix_Fill(MS, f);
                data.Matrix_Fill(MT, f);
            }
            S = data.Func3(O, MO, MS, MT);
            sleep(1500);

            if(n < 7){
                System.out.println("-- T3 is waiting for console.");
                sem.acquire();
                System.out.println("-- T3 is using console.\n-- F3: S = SORT(O*MO)*(MS*MT)");
                data.Vector_Print(S);
                System.out.println("\n");
                sem.release();
                System.out.println("-- T3 has left console.");
            }

            System.out.println("-- T3 has finished.");

        } catch (InterruptedException e) {
            System.out.println("-- T3 has encountered an Interruption Exception.");
        }
    }
}
