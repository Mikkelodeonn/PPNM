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
	WriteLine($"The squareroot of -1 is: {a}\n");
	//WriteLine($"Check: {complex.approx(a/i,1)}\n");

	complex b = cmath.sqrt(i);
	WriteLine($"The squareroot of i is: {b}\n");
	//WriteLine($"Check: {cmath.approx(b, 1/(Math.Sqrt(2)) + i/(Math.Sqrt(2)))}\n");

	complex c = cmath.exp(i);
	WriteLine($"exp(i) = {c}\n");
	//WriteLine($"Check: {c,(0.54+0.84*i)}\n");

	complex d = cmath.exp(i*Math.PI);
	WriteLine($"exp(i*pi) = {d}\n");
	//WriteLine($"Check: {cmath.approx(d,-1)}\n");

	complex e = cmath.pow(i,i);
	WriteLine($"i to the power of i is: {e}\n");
	//WriteLine($"Check: {cmath.approx(e,0,208)}\n");

	complex f = cmath.log(i);
	WriteLine($"ln(i) = {f}\n");
	//WriteLine($"Check: {f,i*Math.PI/2}\n");

	complex g = cmath.sin(i*Math.PI);
	WriteLine($"sin(i*pi) = {g}\n");
	//WriteLine($"Check: {cmath.approx(g,11.55*i)}\n");

return 0;
} // Main
} // main
