// Lab5.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

/*--------------------------------------------
 * -- Lab 5 Var 12
 * -- F1: E = MAX(A)*(X+B*(MA*MD)+C)
 * -- F2: ML = SORT(TRANS(MF)*MK)
 * -- F3: S = SORT(O*MO)*(MS*MT)
 * -- Diachenko Tetiana IV-81
 * -- Date 05.11.2020
 * --------------------------------------------*/

#include <iostream>
#include <omp.h>
#include <windows.h>
#include "Data.h"

void T1();
void T2();
void T3();

Data data = Data(1000);

int main() 
{
    std::cout << "-- Lab5 has started.\n";
    
	omp_set_num_threads(3);
    #pragma omp parallel sections num_threads(3)
	{
        #pragma omp sections
        {
            #pragma omp section
            {
                T1();
            }
            #pragma omp section
            {
                T2();
            }
            #pragma omp section
            {
                T3();
            }
        }
	}
    std::cout << "-- Lab5 has finished.\n";
}

void T1() {
    std::cout << "-- T1 has started.\n";
    int n = data.getN();
    int f = 1;
    int* A = new int[n];
    int* B = new int[n];
    int* C = new int[n];
    int* X = new int[n];
    int** MA = new int* [n];
    int** MD = new int* [n];
    for (int i = 0; i < n; i++) {
        MA[i] = new int[n];
        MD[i] = new int[n];
    }
    int* E;

    data.Vector_Fill(A, f);
    data.Vector_Fill(B, f);
    data.Vector_Fill(C, f);
    data.Vector_Fill(X, f);
    data.Matrix_Fill(MA, f);
    data.Matrix_Fill(MD, f);

    E = data.Func1(A, B, C, X, MA, MD);
    Sleep(1500);

    if (n < 7) {
        std::cout << "-- F1: E = MAX(A)*(X+B*(MA*MD)+C)\n";
        data.Vector_Print(E);
        std::cout << "\n";
    }

    delete[] A;
    delete[] B;
    delete[] C;
    delete[] X;
    for (int i = 0; i < n; i++) {
        delete[] MA[i];
        delete[] MD[i];
    }
    delete[] MA;
    delete[] MD;
    delete[] E;

    std::cout << "-- T1 has finished.\n";
}


void T2() {
    std::cout << "-- T2 has started.\n";
    int n = data.getN();
    int f = 1;
    int** MF = new int* [n];
    int** MK = new int* [n];
    int** ML;
    for (int i = 0; i < n; i++) {
        MF[i] = new int[n];
        MK[i] = new int[n];
    }

    data.Matrix_Fill(MF, f);
    data.Matrix_Fill(MK, f);

    ML = data.Func2(MF, MK);
    Sleep(1500);

    if (n < 7) {
        std::cout << "-- F2: ML = SORT(TRANS(MF)*MK)\n";
        data.Matrix_Print(ML);
        std::cout << "\n";
    }

    for (int i = 0; i < n; i++) {
        delete[] MF[i];
        delete[] MK[i];
        delete[] ML[i];
    }
    delete[] MF;
    delete[] MK;
    delete[] ML;

    std::cout << "-- T2 has finished.\n";
}

void T3() {
    std::cout << "-- T3 has started.\n";
    int n = data.getN();
    int f = 1;
    int* O = new int[n];
    int* S;
    int** MO = new int* [n];
    int** MS = new int* [n];
    int** MT = new int* [n];
    for (int i = 0; i < n; i++) {
        MO[i] = new int[n];
        MS[i] = new int[n];
        MT[i] = new int[n];
    }

    data.Vector_Fill(O, f);
    data.Matrix_Fill(MO, f);
    data.Matrix_Fill(MS, f);
    data.Matrix_Fill(MT, f);

    S = data.Func3(O, MO, MS, MT);
    Sleep(1500);

    if (n < 7) {
        std::cout << "-- F3: S = SORT(O*MO)*(MS*MT)\n";
        data.Vector_Print(S);
        std::cout << "\n";
    }

    delete[] O;
    delete[] S;
    for (int i = 0; i < n; i++) {
        delete[] MO[i];
        delete[] MS[i];
        delete[] MT[i];
    }
    delete[] MO;
    delete[] MS;
    delete[] MT;

    std::cout << "-- T3 has finished.\n";
}

