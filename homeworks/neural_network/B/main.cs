using System;
using static System.Console;
using static System.Math;
public class main{
public static void Main(){

Func<double,double> g = x => {return Cos(5*x-1) * Exp(-x*x);};
Func<double,double> g_derivative = x => {return (-5*Sin(5*x-1) -2*x*Cos(5*x-1))*Exp(-x*x);};
Func<double,double> g_double_derivative = x => {return ((4*x*x-27)*Cos(5*x-1) + 20*x*Sin(5*x-1))*Exp(-x*x);};


int n = 6;
var ann = new ann(n);
int points = 20;
var xs = new vector(points);
var ys = new vector(points);
double a = -1, b = 1;


for(int i=0 ; i<points ; i++){ // constructing tabulated values {x,g(x)}
	xs[i] = a + (b - a) * i / (points - 1); 
	ys[i] = g(xs[i]);
	WriteLine($"{xs[i]} {ys[i]}");
}
WriteLine("\n\n\n");

for(int i=0 ; i<ann.n ; i++){ // constructing the start vector p (a1,b1,w1,a2,b2,w2,...,an,bn,wn)
	ann.p[3*i] = a + (b - a) * i / (ann.n - 1); 
	ann.A[3*i] = a - (b - a)/2;
	ann.B[3*i] = b + (b - a)/2;
	ann.p[3*i+1] = 1; 
	ann.A[3*i+1] = 0.01; 
	ann.B[3*i+1] = 10; 
	ann.p[3*i+2] = 1; 
	ann.A[3*i+2] = -10; 
	ann.B[3*i+2] = 10; 
}
ann.N=100000;
//ann.p.print("ann.p (before training):",file:Console.Error);
//ann.A.print("ann.A (before training):",file:Console.Error);
//ann.B.print("ann.B (before training):",file:Console.Error);
//Error.WriteLine($"ann.n = {ann.n}");
ann.train(xs,ys); // training the network
//ann.p.print("ann.p (after training):",file:Console.Error);

for(double xj = a; xj <= b; xj += 1.0/64){ // fitting the function to the tabulated values
	WriteLine($"{xj} {ann.response(xj)}");
}
WriteLine("\n\n\n");
for(int i=0 ; i<points ; i++){ // constructing tabulated values {x,g(x)}
	xs[i] = a + (b - a) * i / (points - 1); 
	ys[i] = g_derivative(xs[i]);
	WriteLine($"{xs[i]} {ys[i]}");
}
WriteLine("\n\n\n");
for(double xj = a; xj <= b; xj += 1.0/64){ // fitting the function to the tabulated values
	WriteLine($"{xj} {ann.derivative(xj)}");
}
WriteLine("\n\n\n");
for(int i=0 ; i<points ; i++){ // constructing tabulated values {x,g(x)}
	xs[i] = a + (b - a) * i / (points - 1); 
	ys[i] = g_double_derivative(xs[i]);
	WriteLine($"{xs[i]} {ys[i]}");
}
WriteLine("\n\n\n");
for(double xj = a; xj <= b; xj += 1.0/64){ // fitting the function to the tabulated values
	WriteLine($"{xj} {ann.double_derivative(xj)}");
}
WriteLine("\n\n\n");
for(double xj = a; xj <= b; xj += 1.0/64){ // fitting the function to the tabulated values
	WriteLine($"{xj} {ann.integral(xj)}");
}
//ann.p.print("ann.p (after):",file:Console.Error);


} // Main
} // class main
