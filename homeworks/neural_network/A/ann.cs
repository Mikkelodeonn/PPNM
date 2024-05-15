using System;
using static System.Math;
using static System.Console;
public class ann{
public int n; /* number of hidden neurons */
public Func<double,double> f; /* activation function */
public vector p; /* network parameters */
public vector A; /* lower left corner */
public vector B; /* upper right corner  */
public int N=1000;
public ann(int n){ /* constructor */
    f = x => x*Exp(-x*x);
    this.n = n;
    this.p = new vector(3*n);
    this.A = new vector(3*n);
    this.B = new vector(3*n);
} // ann
public double response(double x){ /* return the response of the network to the input signal x */
    double sum = 0;
    for(int i=0 ; i<n ; i++){
        double a = p[3*i];
        double b = p[3*i+1];           
        double w = p[3*i+2];  
        sum += w * f((x-a)/b);
    }
    return sum;
} // response
public void train(vector x, vector y){ /* train the network to interpolate the given table {x,y} */
    int ncalls = 0;
    Func<vector,double> cost_function = u => {
        ncalls++;
	vector pold=p.copy();
        p = u;
        double sum = 0;
        for(int i=0 ; i<x.size ; i++){
            sum += Pow(response(x[i])-y[i],2);
        }
	p=pold;
        return sum;///x.size;
    };
p.print("parameters before training:",file:Console.Error);
System.Console.Error.Write($"\ncost function before training: {cost_function(p)}\n");
p=rndmin.go(cost_function,A,B,N);
p.print("\nparameters after random opt:",file:Console.Error);
System.Console.Error.Write($"\ncost function after random opt: {cost_function(p)}\n");
int steps=simplex.downhill(cost_function, ref p,sizegoal:1e-5);
p.print("\nparameters after simplex downhill opt:",file:Console.Error);
System.Console.Error.Write($"\ncost function after simplex downhill opt: {cost_function(p)}\n");
System.Console.Error.Write($"\nsimplex steps: {steps}\n");
//p = minimize.newton(cost_function, p, acc:1e-5);
//p.print("train: p after newton:",file:Console.Error);
//System.Console.Error.Write($"train: cost after newton: {cost_function(p)}\n");
} // train
} // class ann
