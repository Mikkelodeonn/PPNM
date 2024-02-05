using System;
using static System.Console;
using static System.Math;

static class main{

	static int Main(){
		double num = 2;
		double sqrt = Math.Sqrt(num);
		
		Write("TASK 1:\n\n");

		Write($"The squareroot of {num} is {sqrt}.\n");
		Write($"To check: the squareroot squared equals {sqrt*sqrt}\n");

		double power = 0.2;

		Write($"{num} to the power of {power} equals {Math.Pow(num,power)}.\n");
	
		double e = Math.Exp(1);

		Write($"Eulers number to the power of pi is equal to {Math.Exp(PI)}\n");

		Write($"Pi to the power of Eulers number is equal to {Math.Pow(PI,e)}\n");

		Write("\nTASK 2:\n\n");

		double prod=1;
		for(double x=1;x<11;x+=1){
			Write($"fgamma({x})={sfunc.fgamma(x)} {x-1}!={prod}\n");
			prod*=x;
			}

		Write("\nTASK 3:\n\n");

		for(double x=1;x<11;x+=1){
			Write($"lngamma({x})={sfunc.lngamma(x)}\n");
			}
		

	return 0;
	}

}



