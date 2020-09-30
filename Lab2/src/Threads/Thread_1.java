package Threads;
/** F1: E = MAX(A)*(X+B*(MA*MD)+C) **/

import Data.Data;

import java.util.concurrent.Semaphore;

public class Thread_1 extends Thread {

    private Data data;
    private Semaphore sem;
    private int n;

    public Thread_1(Data d, Semaphore s){
        this.data = d;
        this.sem = s;
        this.n = d.getN();
    }

    public void run() {
        System.out.println("-- T1 has started.");
        int f = 1;
        int[] A = new int[n];
        int[] B = new int[n];
        int[] C = new int[n];
        int[] X = new int[n];
        int[][] MA = new int[n][n];
        int[][] MD = new int[n][n];
        int[] E;
        String ans;
        try {
            if(n < 7){
                sleep(200);
                System.out.println("-- T1 is waiting for console.");
                sem.acquire();
                System.out.println("-- T1 is using console.");
                System.out.println("-- F1: E = MAX(A)*(X+B*(MA*MD)+C)");
                System.out.println("Do you want to enter elements manually? (if no then everything will be filled with " + f + " (y/n)");
                ans = data.getScanner().next();
                if(ans.equals("y")){
                    System.out.println("Input elements of vector A one-by-one:");
                    data.Vector_Input(A);
                    System.out.println("Input elements of vector B one-by-one:");
                    data.Vector_Input(B);
                    System.out.println("Input elements of vector C one-by-one:");
                    data.Vector_Input(C);
                    System.out.println("Input elements of vector X one-by-one:");
                    data.Vector_Input(X);
                    System.out.println("Input elements of matrix MA one-by-one:");
                    data.Matrix_Input(MA);
                    System.out.println("Input elements of matrix MD one-by-one:");
                    data.Matrix_Input(MD);
                    sem.release();
                    System.out.println("\n\n-- T1 has left console.");
                } else {
                    sem.release();
                    System.out.println("-- T1 has left console.");
                    data.Vector_Fill(A, f);
                    data.Vector_Fill(B, f);
                    data.Vector_Fill(C, f);
                    data.Vector_Fill(X, f);
                    data.Matrix_Fill(MA, f);
                    data.Matrix_Fill(MD, f);
                }
            } else {
                data.Vector_Fill(A, f);
                data.Vector_Fill(B, f);
                data.Vector_Fill(C, f);
                data.Vector_Fill(X, f);
                data.Matrix_Fill(MA, f);
                data.Matrix_Fill(MD, f);
            }
            E = data.Func1(A, B, C, X, MA, MD);
            sleep(1500);

            if(n < 7){
                System.out.println("-- T1 is waiting for console.");
                sem.acquire();
                System.out.println("-- T1 is using console.\n-- F1: E = MAX(A)*(X+B*(MA*MD)+C)");
                data.Vector_Print(E);
                System.out.println("\n");
                sem.release();
                System.out.println("-- T1 has left console.");
            }

            System.out.println("-- T1 has finished.");

        } catch (InterruptedException e) {
            System.out.println("-- T1 has encountered an Interruption Exception.");
        }
    }
}
