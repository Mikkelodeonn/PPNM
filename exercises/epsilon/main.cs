using System;
using static System.Console;
using static System.Math;

class main{
	
	public static int Main(){

              // Task 1: Maximum/minimum representable integers.

	WriteLine("\nTask 1: Max/min representable integers\n");

	int i = 1; while(i + 1 > i) { i++; }
	WriteLine($"Maximum representable integer: {i}");
	
	int j = 1; while(j - 1 < j) { j--; }
	WriteLine($"Minimum representable integer: {j}");

		// Task 2: The machine Epsilon.

        WriteLine("\nTask 2: Machine epsilon\n");
	
	double x=1; 
	while(1+x!=1){x/=2;} 
	x*=2;
	WriteLine($"Double machine epsilon: {x}");
	double check_double = System.Math.Pow(2,-52);
	WriteLine($"Check: 2⁻⁵² = {check_double}");	

	float y=1F;	
	while((float)(1F+y) != 1F){y/=2F;} 
	y*=2F;
	WriteLine($"Float machine epsilon: {y}");
	double check_float = System.Math.Pow(2,-23);
	WriteLine($"Check: 2⁻²³ = {check_float}");

		// Task 3: "tiny-epsilon".

        WriteLine("\nTask 3: tiny-epsilon\n");

	double epsilon = System.Math.Pow(2,-52);
	double tiny = epsilon/2;
	double a = 1+tiny+tiny;
	double b = tiny+tiny+1;
	Write($"a==b ? {a==b}\n");
	Write($"a>1  ? {a>1}\n");
	Write($"b>1  ? {b>1}\n");

	WriteLine("a==b returns false due to rounding errors in doubles, they cannot be precisely represented within the memory of the computer, therefore they end up being different.\n");
	WriteLine("a>1 returns false because tiny is essentially rounded to yield nothing compared to 1. 1 + nothing + nothing = 1, which is not sharply greater than 1.\n");
	WriteLine("b>1 returns true because tiny has value compared to nothing which means that adding 1 to it after the fact yields a value greater than 1.\n");

	WriteLine("\nConclusion: Due to double-precision rounding errors, the '==', '<' and '>' operations cannot be trusted to yield an exact result when dealing with floats/doubles.\n");

	
	
		// Task 4: Comparing doubles: Introduction

        WriteLine("\nTask 4: Comparing doubles, introduction\n");

	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;

	WriteLine($"d1={d1:e15}");
	WriteLine($"d2={d2:e15}");
	WriteLine($"d1==d2 ? => {d1==d2}");	

		// Task 5: Comparing doubles: Task

	WriteLine("\nTask 5: Comparing doubles, task\n");

	bool comparison = approx(d1,d2);

	WriteLine($"d1 and d2 are approximately the same: {comparison}");

	return 0;
	}

public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
	if(Abs(b-a) <= acc) return true;
	if(Abs(b-a) <= Max(Abs(a),Abs(b))*eps) return true;
	return false;
	}



}
