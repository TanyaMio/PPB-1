--------------------------------
-- Lab 1 Var 12
-- F1: E = MAX(A)*(X+B*(MA*MD)+C)
-- F2: ML = SORT(TRANS(MF)*MK)
-- F3: S = SORT(O*MO)*(MS*MT)
-- Diachenko Tetiana IV-81
-- Date 10.09.2020
---------------------------------

with Data, Text_IO, Ada.Integer_Text_IO, System.Multiprocessors, Ada.Synchronous_Task_Control;
use Text_IO, Ada.Integer_Text_IO, System.Multiprocessors, Ada.Synchronous_Task_Control;

procedure Lab1 is

	n: Integer := 3;
	package data_1 is new data(n);
	use data_1;

	SO1: Suspension_object;
	SO2: Suspension_object;
	SO3: Suspension_object;

	task T1 is
		pragma Priority(1);
		pragma Storage_Size(1000000);
		pragma CPU(1);
	end;
	task body T1 is
		A,B,C,X,E: Vector;
		f: Integer := 1;
		MA,MD: Matrix;
	begin
		Put_Line("T1 started.");
		delay(0.2);
		New_Line;
		Put_Line("-- F1: E = MAX(A)*(X+B*(MA*MD)+C) --");
		Put_Line("Input elements of vector A one-by-one:");
		Vector_Input(A);
		Put_Line("Input elements of vector B one-by-one:");
		Vector_Input(B);
		Put_Line("Input elements of vector C one-by-one:");
		Vector_Input(C);
		Put_Line("Input elements of vector X one-by-one:");
		Vector_Input(X);
		Put_Line("Input elements of matrix MA one-by-one:");
		Matrix_Input(MA);
		Put_Line("Input elements of matrix MD one-by-one:");
		Matrix_Input(MD);
		New_Line;
		New_Line;
		Set_True(SO2);

		E := Func1(A,B,C,X,MA,MD);

		if n < 7 then
			Suspend_Until_True(SO1);
			Set_False(SO1);
			Put_Line("-- F1: E = MAX(A)*(X+B*(MA*MD)+C) --");
			Vector_Print(E);
			New_Line;
			New_Line;
			Set_True(SO2);
		end if;

		Put_Line("T1 finished.");
	end T1;


	task T2 is
		pragma Priority(5);
		pragma Storage_Size(1000000);
		pragma CPU(2);
	end;
	task body T2 is
		f: Integer := 1;
		MF,MK,ML: Matrix;
	begin
		Put_Line("T2 started.");
		Suspend_Until_True(SO2);
		Set_False(SO2);
		New_Line;
		Put_Line("-- F2: ML = SORT(TRANS(MF)*MK) --");
		Put_Line("Input elements of matrix MF one-by-one:");
		Matrix_Input(MF);
		Put_Line("Input elements of matrix MK one-by-one:");
		Matrix_Input(MK);
		New_Line;
		New_Line;
		Set_True(SO3);


		ML := Func2(MF,MK);

		if n < 7 then
			Suspend_Until_True(SO2);
			Set_False(SO2);
			Put_Line("-- F2: ML = SORT(TRANS(MF)*MK) --");
			Matrix_Print(ML);
			New_Line;
			New_Line;
			Set_True(SO3);
		end if;

		Put_Line("T2 finished.");
	end T2;


task T3 is
	pragma Priority(3);
		pragma Storage_Size(1000000);
		pragma CPU(3);
	end;
	task body T3 is
		f: Integer := 1;
		O,S: Vector;
		MO,MS,MT: Matrix;
	begin
		Put_Line("T3 started.");
		Suspend_Until_True(SO3);
		Set_False(SO3);
		New_Line;
		Put_Line("-- F3: S = SORT(O*MO)*(MS*MT) --");
		Put_Line("Input elements of vector O one-by-one:");
		Vector_Input(O);
		Put_Line("Input elements of matrix MO one-by-one:");
		Matrix_Input(MO);
		Put_Line("Input elements of matrix MS one-by-one:");
		Matrix_Input(MS);
		Put_Line("Input elements of matrix MT one-by-one:");
		Matrix_Input(MT);
		Set_True(SO1);

		S := Func3(O,MO,MS,MT);

		if n < 7 then
			Suspend_Until_True(SO3);
			Set_False(SO3);
			Put_Line("-- F3: S = SORT(O*MO)*(MS*MT) --");
			Vector_Print(S);
			New_Line;
			New_Line;
			Set_True(SO1);
		end if;

		Put_Line("T3 finished.");
	end T3;

begin
	Put_Line("Lab 1 started.");
end Lab1;