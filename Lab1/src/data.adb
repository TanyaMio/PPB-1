--------------Package Data, body-------------
with Text_IO, Ada.Integer_Text_IO;
use Text_IO, Ada.Integer_Text_IO;

package body Data is

-----Read Vector from Input
procedure Vector_Input(A: out Vector) is
begin
	for i in 1..n loop
		Get(A(i));
	end loop;
	New_Line;
end Vector_Input;

-----Read Matrix from Input
procedure Matrix_Input(MA: out Matrix) is
begin
	for i in 1..n loop
		for j in 1..n loop
			Get(MA(i)(j));
		end loop;
		New_Line;
	end loop;
end Matrix_Input;


-----Fill Vector with Number
procedure Vector_Fill(A: out Vector; b: Integer) is
begin
	for i in 1..n loop
		A(i) := b;
	end loop;
end Vector_Fill;


-----Fill Matrix with Number
procedure Matrix_Fill(MA: out Matrix; a: Integer) is
begin
	for i in 1..n loop
		for j in 1..n loop
			MA(i)(j) := a;
		end loop;
	end loop;
end Matrix_Fill;


-----Set Vector Element
procedure Vector_Set_Element(A: out Vector; i,b: Integer) is
begin
	A(i) := b;
end Vector_Set_Element;


-----Set Matrix Element
procedure Matrix_Set_Element(MA: out Matrix; i,j,a: Integer) is
begin
	MA(i)(j) := a;
end Matrix_Set_Element;


-----Multiply Scalar and Vector
function Mul_Vector_Scalar(A: in Vector; b: Integer) return Vector is
	R: Vector;
begin
	for i in 1..n loop
		R(i) := A(i)*b;
	end loop;
	return R;
end Mul_Vector_Scalar;


-----Multiply Vector and Matrix
function Mul_Vector_Matrix(A: in Vector; MA: in Matrix) return Vector is
	R: Vector;
	s: Integer;
begin
	for i in 1..n loop
		s := 0;
		for j in 1..n loop
			s := s + A(j)*MA(j)(i);
		end loop;
		R(i) := s;
	end loop;
	return R;
end Mul_Vector_Matrix;


-----Multiply Matrix and Matrix
function Mul_Matrix_Matrix(MA,MB: in Matrix) return Matrix is
	MR: Matrix;
	s: Integer;
begin
	for i in 1..n loop
		for j in 1..n loop
			s := 0;
			for k in 1..n loop
				s := s + MA(i)(k)*MB(k)(j);
			end loop;
			MR(i)(j) := s;
		end loop;
	end loop;
	return MR;
end Mul_Matrix_Matrix;


-----Add Two Vectors
function Add_Vectors(A,B: in Vector) return Vector is
	R: Vector;
begin
	for i in 1..n loop
		R(i) := A(i) + B(i);
	end loop;
	return R;
end Add_Vectors;


-----Transpose Matrix
procedure Transpose_Matrix(MA: in out Matrix) is
	t: Integer;
begin
	for i in 1..n loop
		for j in i..n loop
			t := MA(i)(j);
			MA(i)(j) := MA(j)(i);
			MA(j)(i) := t;
		end loop;
	end loop;
end Transpose_Matrix;


-----Sort Vector
procedure Sort_Vector(A: in out Vector) is
	t: Integer;
begin
	for i in 1..n loop
		for j in i..n loop
			if A(i) > A(j) then
				t := A(i);
				A(i) := A(j);
				A(j) := t;
			end if;
		end loop;
	end loop;
end Sort_Vector;


-----Sort Matrix
procedure Sort_Matrix(MA: in out Matrix) is
	t: Integer;
begin
	for i in 1..n loop
		for j in 1..n loop
			for k in j..n loop
				if MA(i)(j) > MA(i)(k) then
					t := MA(i)(j);
					MA(i)(j) := MA(i)(k);
					MA(i)(k) := t;
				end if;
			end loop;
		end loop;
	end loop;
end Sort_Matrix;


-----Find MAX in Vector
function Vector_Max(A: in Vector) return Integer is
	r: Integer;
begin
	r := A'First;
	for i in 1..n loop
		if r < A(i) then
			 r := A(i);
		end if;
	end loop;
	return r;
end Vector_Max;


-----Print Vector on Screen
procedure Vector_Print(A: in Vector) is
begin
	for i in 1..n loop
		Put(A(i));
		Put(" ");
	end loop;
end Vector_Print;


-----Print Matrix on Screen
procedure Matrix_Print(MA: in Matrix) is
begin
	for i in 1..n loop
		for j in 1..n loop
			Put(MA(i)(j));
			Put(" ");
		end loop;
		New_Line;
	end loop;
end Matrix_Print;


-----Calculate F1: E = MAX(A)*(X+B*(MA*MD)+C)
function Func1(A,B,C,X: in Vector; MA,MD: in Matrix) return Vector is
	MR: Matrix;
	E,D: Vector;
	n: Integer;
begin
	MR := Mul_Matrix_Matrix(MA, MD);
	D := Mul_Vector_Matrix(B, MR);
	E := Add_Vectors(X, D);
	D := Add_Vectors(E, C);
	n := Vector_Max(A);
	E := Mul_Vector_Scalar(D, n);
	return E;
end Func1;


-----Calculate F2: ML = SORT(TRANS(MF)*MK)
function Func2(MF,MK: in out Matrix) return Matrix is
	ML: Matrix;
begin
	Transpose_Matrix(MF);
	ML := Mul_Matrix_Matrix(MF, MK);
	Sort_Matrix(ML);
	return ML;
end Func2;


-----Calculate F3: S = SORT(O*MO)*(MS*MT)
function Func3(O: in Vector; MO,MS,MT: in Matrix) return Vector is
	S, R: Vector;
	MR: Matrix;
begin
	R := Mul_Vector_Matrix(O, MO);
	MR := Mul_Matrix_Matrix(MS, MT);
	Sort_Vector(R);
	S := Mul_Vector_Matrix(R, MR);
	return S;
end Func3;

end Data;