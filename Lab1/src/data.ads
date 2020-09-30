generic
	n: Integer;

package Data is

	-------Vector and Matrix types declaration
	type Vector is private;
	type Matrix is private;


	-----Read Vector from Input
	procedure Vector_Input(A: out Vector);

	-----Read Matrix from Input
	procedure Matrix_Input(MA: out Matrix);

	-----Fill Vector with Number
	procedure Vector_Fill(A: out Vector; b: Integer);

	-----Fill Matrix with Number
	procedure Matrix_Fill(MA: out Matrix; a: Integer);

	-----Set Vector Element
	procedure Vector_Set_Element(A: out Vector; i,b: Integer);

	-----Set Matrix Element
	procedure Matrix_Set_Element(MA: out Matrix; i,j,a: Integer);

	-----Multiply Scalar and Vector
	function Mul_Vector_Scalar(A: in Vector; b: Integer) return Vector;

	-----Multiply Vector and Matrix
	function Mul_Vector_Matrix(A: in Vector; MA: in Matrix) return Vector;

	-----Multiply Matrix and Matrix
	function Mul_Matrix_Matrix(MA,MB: in Matrix) return Matrix;

	-----Add Two Vectors
	function Add_Vectors(A,B: in Vector) return Vector;

	-----Transpose Matrix
	procedure Transpose_Matrix(MA: in out Matrix);

	-----Sort Vector
	procedure Sort_Vector(A: in out Vector);

	-----Sort Matrix
	procedure Sort_Matrix(MA: in out Matrix);

	-----Find MAX in Vector
	function Vector_Max(A: in Vector) return Integer;

	-----Print Vector on Screen
	procedure Vector_Print(A: in Vector);

	-----Print Matrix on Screen
	procedure Matrix_Print(MA: in Matrix);

	-----Calculate F1: E = MAX(A)*(X+B*(MA*MD)+C)
	function Func1(A,B,C,X: in Vector; MA,MD: in Matrix) return Vector;

	-----Calculate F2: ML = SORT(TRANS(MF)*MK)
	function Func2(MF,MK: in out Matrix) return Matrix;

	-----Calculate F3: S = SORT(O*MO)*(MS*MT)
	function Func3(O: in Vector; MO,MS,MT: in Matrix) return Vector;


	------Definition of Vector and Matrix types
	private
	type Vector is array (1..n) of Integer;
	type Matrix is array (1..n) of Vector;

end Data;