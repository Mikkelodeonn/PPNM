using System;
//using static System.complex;
//using static System.cmath;
//using static System.Math;
using static System.Console;
using System.Numerics;

class main{

public static int Main(){

	complex i = new complex(0,1);


	complex a = cmath.sqrt(cmath.pow(i,2));
	WriteLine($"The squareroot of -1 is: {a}");
	WriteLine($"Check with approx function: {cmath.approx(1, a/i)}\n");

	complex b = cmath.sqrt(i);
	WriteLine($"The squareroot of i is: {b}");
	WriteLine($"Check with approx function: {cmath.approx(1/(Math.Sqrt(2)), b-i/(Math.Sqrt(2)))}\n");

	complex c = cmath.exp(i);
	WriteLine($"exp(i) = {c}");
	WriteLine($"Check with approx function: {cmath.approx(0.540302305868, c-0.841470984807*i)}\n");

	complex d = cmath.exp(i*Math.PI);
	WriteLine($"exp(i*pi) = {d}");
	WriteLine($"Check with approx function: {cmath.approx(-1, d)}\n");

	complex e = cmath.pow(i,i);
	WriteLine($"i to the power of i is: {e}");
	WriteLine($"Check with approx function: {cmath.approx(0.207879576350, e)}\n");

	complex f = cmath.log(i);
	WriteLine($"ln(i) = {f}");
	WriteLine($"Check with approx function: {cmath.approx(Math.PI/2,f/i)}\n");

	complex g = cmath.sin(i*Math.PI);
	WriteLine($"sin(i*pi) = {g}");
	WriteLine($"Check with approx function: {cmath.approx(11.548739357257,g/i)}\n");

return 0;
} // Main
} // main
