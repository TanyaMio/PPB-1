import Data.Data;
import Threads.Thread_1;
import Threads.Thread_2;
import Threads.Thread_3;

import java.util.concurrent.Semaphore;

/**--------------------------------------------
 * -- Lab 2 Var 12
 * -- F1: E = MAX(A)*(X+B*(MA*MD)+C)
 * -- F2: ML = SORT(TRANS(MF)*MK)
 * -- F3: S = SORT(O*MO)*(MS*MT)
 * -- Diachenko Tetiana IV-81
 * -- Date 24.09.2020
 * --------------------------------------------**/

public class Main {

    private static int n = 1000;
    private static Data data = new Data(n);
    private static Semaphore sem = new Semaphore(1);

    public static void main(String[] args) {

        System.out.println("Lab2 has started.");

	    Thread T1 = new Thread_1(data, sem);
	    Thread T2 = new Thread_2(data, sem);
        Thread T3 = new Thread_3(data, sem);
        T1.setPriority(1);
        T2.setPriority(5);
        T3.setPriority(3);

        T1.start();
        T2.start();
        T3.start();

        try{
            T1.join();
            T2.join();
            T3.join();
        } catch (Exception e){
            System.out.println("Error joining threads.");
        }

        System.out.println("Lab2 has finished.");
    }
}
