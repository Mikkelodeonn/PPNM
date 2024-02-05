using System;
using static System.Console;
using static System.Math;

static class main{
	static double Sin(double x){ 
		return 0; 
		}
	static double x=1.0;
	static string hello = $"hello, x={x}";
	static double times2(double y){
		double x=7;
		WriteLine(x);
		return y*2;
		}

	static int Main(){
		Write($"x={x} Sin(x)={Sin(x)}\n");
		double prod=1;
		for(double x=1;x<10;x+=1){
			Write($"fgamma({x})={sfunc.fgamma(x)} {x-1}!={prod}\n");
			prod*=x;
			}
	return 0;
	}

}



