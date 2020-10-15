/*-----------------------------------------------------------
 * This package contains functions for calculating F1, F2, F3
 * --------------------------------------------------------*/

#include <iostream>
#include "Data.h"

int n;

Data::Data(int n_to_set) {
    n = n_to_set;
}

int Data::getN() {
    return n;
}


/** Filling Vector with Number **/
void Data::Vector_Fill(int* A, int a) {
    for (int i = 0; i < n; i++) {
        A[i] = a;
    }
}

/** Filling Vector with Number **/
void Data::Matrix_Fill(int** MA, int a) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            MA[i][j] = a;
        }
    }
}

/** Setting Vector Element **/
void Data::Vector_Set_Element(int* A, int i, int a) {
    A[i] = a;
}

/** Setting Matrix Element **/
void Data::Matrix_Set_Element(int** MA, int i, int j, int a) {
    MA[i][j] = a;
}

/** Multiplying Scalar and Vector **/
int* Data::Mul_Vector_Scalar(int* A, int a) {
    int* R = new int[n];
    for (int i = 0; i < n; i++) {
        R[i] = A[i] * a;
    }
    return R;
}

/** Multiplying Vector and Matrix **/
int* Data::Mul_Vector_Matrix(int* A, int** MA) {
    int* R = new int[n];
    int s;
    for (int i = 0; i < n; i++) {
        s = 0;
        for (int j = 0; j < n; j++) {
            s += A[j] * MA[j][i];
        }
        R[i] = s;
    }
    return R;
}

/** Multiplying Matrix and Matrix **/
int** Data::Mul_Matrix_Matrix(int** MA, int** MB) {
    int** MR = new int*[n];
    int s;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            s = 0;
            for (int k = 0; k < n; k++) {
                s += MA[i][k] * MB[k][j];
            }
            MR[i][j] = s;
        }
    }
    return MR;
}

/** Adding Two Vectors **/
int* Data::Add_Vectors(int* A, int* B) {
    int* R = new int[n];
    for (int i = 0; i < n; i++) {
        R[i] = A[i] + B[i];
    }
    return R;
}

/** Transposing Matrix **/
void Data::Transpose_Matrix(int** MA) {
    int t;
    for (int i = 0; i < n; i++) {
        for (int j = i; j < n; j++) {
            t = MA[i][j];
            MA[i][j] = MA[j][i];
            MA[j][i] = t;
        }
    }
}

 /** Sorting Vector **/
void Data::Sort_Vector(int* A) {
    int t;
    for (int i = 0; i < n; i++) {
        for (int j = i; j < n; j++) {
            if (A[i] > A[j]) {
                t = A[i];
                A[i] = A[j];
                A[j] = t;
            }
        }
    }
}

/** Sorting Matrix **/
void Data::Sort_Matrix(int** MA) {
    int t;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            for (int k = j; k < n; k++) {
                if (MA[i][j] > MA[i][k]) {
                    t = MA[i][j];
                    MA[i][j] = MA[i][k];
                    MA[i][k] = t;
                }
            }
        }
    }
}

/** Finding MAX in Vector **/
int Data::Vector_Max(int* A) {
    int r = A[0];
    for (int i = 1; i < n; i++) {
        if (r < A[i]) {
            r = A[i];
        }
    }
    return r;
}

/** Printing Vector on Screen **/
void Data::Vector_Print(int* A) {
    for (int i = 0; i < n; i++) {
        std::cout << A[i] << " ";
    }
    std::cout << "\n";
}

/** Printing Matrix on Screen **/
void Data::Matrix_Print(int** MA) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            std::cout << MA[i][j] << " ";
        }
        std::cout << "\n";
    }
    std::cout << "\n";
}

/** Calculating F1: E = MAX(A)*(X+B*(MA*MD)+C) **/
int* Data::Func1(int* A, int* B, int* C, int* X, int** MA, int** MD) {
    int** MR = Mul_Matrix_Matrix(MA, MD);
    int* D = Mul_Vector_Matrix(B, MR);
    int* E = Add_Vectors(X, D);
    D = Add_Vectors(E, C);
    int m = Vector_Max(A);
    E = Mul_Vector_Scalar(D, m);
    delete D;
    delete MR;
    return E;
}

/** Calculating F2: ML = SORT(TRANS(MF)*MK) **/
int** Data::Func2(int** MF, int** MK) {
    Transpose_Matrix(MF);
    int** ML = Mul_Matrix_Matrix(MF, MK);
    Sort_Matrix(ML);
    return ML;
}

/** Calculating F3: S = SORT(O*MO)*(MS*MT) **/
int* Data::Func3(int* O, int** MO, int** MS, int** MT) {
    int* R = Mul_Vector_Matrix(O, MO);
    int** MR = Mul_Matrix_Matrix(MS, MT);
    Sort_Vector(R);
    int* S = Mul_Vector_Matrix(R, MR);
    return S;
}
