class Data
{
public:
    int getN();
    Data(int n_to_set);
    void Vector_Fill(int* A, int a);
    void Matrix_Fill(int** MA, int a);
    void Vector_Set_Element(int* A, int i, int a);
    void Matrix_Set_Element(int** MA, int i, int j, int a);
    void Vector_Print(int* A);
    void Matrix_Print(int** MA);
    int* Func1(int* A, int* B, int* C, int* X, int** MA, int** MD);
    int** Func2(int** MF, int** MK);
    int* Func3(int* O, int** MO, int** MS, int** MT);
private:
    int n;
    int* Mul_Vector_Scalar(int* A, int a);
    int* Mul_Vector_Matrix(int* A, int** MA);
    int** Mul_Matrix_Matrix(int** MA, int** MB);
    int* Add_Vectors(int* A, int* B);
    void Transpose_Matrix(int** MA);
    void Sort_Vector(int* A);
    void Sort_Matrix(int** MA);
    int Vector_Max(int* A);
};