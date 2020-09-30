package Threads;
/** -- F2: ML = SORT(TRANS(MF)*MK) **/

import Data.Data;

import java.util.concurrent.Semaphore;

public class Thread_2 extends Thread{
    private Data data;
    private Semaphore sem;
    private int n;

    public Thread_2 (Data d, Semaphore s){
        this.data = d;
        this.sem = s;
        this.n = d.getN();
    }

    public void run() {
        System.out.println("-- T2 has started.");
        int f = 1;
        int[][] MF = new int[n][n];
        int[][] MK = new int[n][n];
        int[][] ML;
        String ans;
        try {
            if(n < 7){
                sleep(200);
                System.out.println("-- T2 is waiting for console.");
                sem.acquire();
                System.out.println("-- T2 is using console.");
                System.out.println("-- F2: ML = SORT(TRANS(MF)*MK)");
                System.out.println("Do you want to enter elements manually? (if no then everything will be filled with " + f + " (y/n)");
                ans = data.getScanner().next();
                if(ans.equals("y")){
                    System.out.println("Input elements of matrix MF one-by-one:");
                    data.Matrix_Input(MF);
                    System.out.println("Input elements of matrix MK one-by-one:");
                    data.Matrix_Input(MK);
                    sem.release();
                    System.out.println("\n\n-- T2 has left console.");
                } else {
                    sem.release();
                    System.out.println("-- T2 has left console.");
                    data.Matrix_Fill(MF, f);
                    data.Matrix_Fill(MK, f);
                }
            } else {
                data.Matrix_Fill(MF, f);
                data.Matrix_Fill(MK, f);
            }
            ML = data.Func2(MF, MK);
            sleep(1500);

            if(n < 7){
                System.out.println("-- T2 is waiting for console.");
                sem.acquire();
                System.out.println("-- T2 is using console.\n-- F2: ML = SORT(TRANS(MF)*MK)");
                data.Matrix_Print(ML);
                System.out.println("\n");
                sem.release();
                System.out.println("-- T2 has left console.");
            }

            System.out.println("-- T2 has finished.");

        } catch (InterruptedException e) {
            System.out.println("-- T2 has encountered an Interruption Exception.");
        }
    }
}
