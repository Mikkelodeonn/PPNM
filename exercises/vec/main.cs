using System;
using static System.Console;
using static System.Math;

class main{

	static int Main(){

		vec v = new vec(1,2,3);
		vec u = new vec(4,5,6);

		v.print("Vector v = ");
		u.print("Vector u = ");

		vec sum = u + v;
		sum.print("u + v = ");

		vec diff = u - v;
		diff.print("u - v = ");
		
		double c = 3;
		vec prod = c * v; 
		prod.print("c * v = ");

		vec neg = -v;
		neg.print("-v = ");

		WriteLine("");

		double dot_product = vec.dot(u,v);
		WriteLine($"Dot product of u and v: {dot_product}\n");

		double norm = vec.norm(u);
		WriteLine($"Norm of u: {norm}\n");

		if(u.approx(v)){
		
			WriteLine($"u is approximately equal to v\n");
		}		
		else{
			WriteLine($"u is not approximately equal to v\n");
		}

		return 0;
	}
}
