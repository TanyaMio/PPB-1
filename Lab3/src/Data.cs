/*-----------------------------------------------------------
 * This package contains functions for calculating F1, F2, F3
 * --------------------------------------------------------*/

using System;

namespace PPB_Lab_3
{
    public class Data
    {
        readonly int _n;

        public Data(int nToSet){
            _n = nToSet;
        }

        public int GetN(){
            return _n;
        }
        

        /** Reading Vector from input **/
        public void Vector_Input(int[] A){
            for(int i = 0; i < _n; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
        }

        /** Reading Matrix from input **/
        public void Matrix_Input(int[,] MA){
            for(int i = 0; i < _n; i++){
                for(int j = 0; j < _n; j++){
                    MA[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
        }

        /** Filling Vector with Number **/
        public void Vector_Fill(int[] A, int a){
            for(int i = 0; i < _n; i++){
                A[i] = a;
            }
        }

        /** Filling Vector with Number **/
        public void Matrix_Fill(int[,] MA, int a){
            for(int i = 0; i < _n; i++){
                for(int j = 0; j < _n; j++){
                    MA[i, j] = a;
                }
            }
        }

        /** Setting Vector Element **/
        public void Vector_Set_Element(int[] A, int i, int a){
            A[i] = a;
        }

        /** Setting Matrix Element **/
        public void Matrix_Set_Element(int[,] MA, int i, int j, int a){
            MA[i, j] = a;
        }

        /** Multiplying Scalar and Vector **/
        public int[] Mul_Vector_Scalar(int[] A, int a){
            int[] R = new int[_n];
            for(int i = 0; i < _n; i++){
                R[i] = A[i] * a;
            }
            return R;
        }

        /** Multiplying Vector and Matrix **/
        public int[] Mul_Vector_Matrix(int[] A, int[,] MA){
            int[] R = new int[_n];
            int s;
            for(int i = 0; i < _n; i++){
                s = 0;
                for(int j = 0; j < _n; j++){
                    s += A[j] * MA[j, i];
                }
                R[i] = s;
            }
            return R;
        }

        /** Multiplying Matrix and Matrix **/
        public int[,] Mul_Matrix_Matrix(int[,] MA, int[,] MB){
            int[,] MR = new int[_n, _n];
            int s;
            for(int i = 0; i < _n; i++){
                for(int j = 0; j < _n; j++){
                    s = 0;
                    for(int k = 0; k < _n; k++){
                        s += MA[i, k] * MB[k, j];
                    }
                    MR[i, j] = s;
                }
            }
            return MR;
        }

        /** Adding Two Vectors **/
        public int[] Add_Vectors(int[] A, int[] B){
            int[] R = new int[_n];
            for(int i = 0; i < _n; i++){
                R[i] = A[i] + B[i];
            }
            return R;
        }

        /** Transposing Matrix **/
        public void Transpose_Matrix(int[,] MA){
            int t;
            for(int i = 0; i < _n; i++){
                for(int j = i; j < _n; j++){
                    t = MA[i, j];
                    MA[i, j] = MA[j, i];
                    MA[j, i] = t;
                }
            }
        }

        /** Sorting Vector **/
        public void Sort_Vector(int[] A){
            int t;
            for(int i = 0; i < _n; i++){
                for(int j = i; j < _n; j++){
                    if(A[i] > A[j]){
                        t = A[i];
                        A[i] = A[j];
                        A[j] = t;
                    }
                }
            }
        }

        /** Sorting Matrix **/
        public void Sort_Matrix(int[,] MA) {
            int t;
            for(int i = 0; i < _n; i++){
                for(int j = 0; j < _n; j++){
                    for(int k = j; k < _n; k++){
                        if(MA[i, j] > MA[i, k]){
                            t = MA[i, j];
                            MA[i, j] = MA[i, k];
                            MA[i, k] = t;
                        }
                    }
                }
            }
        }

        /** Finding MAX in Vector **/
        public int Vector_Max(int[] A){
            int r = A[0];
            for(int i = 1; i < _n; i++){
                if (r < A[i]){
                    r = A[i];
                }
            }
            return r;
        }

        /** Printing Vector on Screen **/
        public void Vector_Print(int[] A){
            for(int i = 0; i < _n; i++){
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
        }

        /** Printing Matrix on Screen **/
        public void Matrix_Print(int[,] MA){
            for(int i = 0; i < _n; i++){
                for(int j = 0; j < _n; j++){
                    Console.Write(MA[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /** Calculating F1: E = MAX(A)*(X+B*(MA*MD)+C) **/
        public int[] Func1(int[] A, int[] B, int[] C, int[] X, int[,] MA, int[,] MD){
            int[,] MR = Mul_Matrix_Matrix(MA, MD);
            int[] D = Mul_Vector_Matrix(B, MR);
            int[] E = Add_Vectors(X, D);
            D = Add_Vectors(E, C);
            int m = Vector_Max(A);
            E = Mul_Vector_Scalar(D, m);
            return E;
        }

        /** Calculating F2: ML = SORT(TRANS(MF)*MK) **/
        public int[,] Func2(int[,] MF, int[,] MK){
            Transpose_Matrix(MF);
            int[,] ML = Mul_Matrix_Matrix(MF, MK);
            Sort_Matrix(ML);
            return ML;
        }

        /** Calculating F3: S = SORT(O*MO)*(MS*MT) **/
        public int[] Func3(int[] O, int[,] MO, int[,] MS, int[,] MT){
            int[] R = Mul_Vector_Matrix(O, MO);
            int[,] MR = Mul_Matrix_Matrix(MS, MT);
            Sort_Vector(R);
            int[] S = Mul_Vector_Matrix(R, MR);
            return S;
        }
    }
}