using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class main{

public static void Main(){

	double b=0.25, c=5;
    double k=10, m=10;

	Func<double,vector,vector> F = delegate(double t,vector y){ // implementation of scipy example of damped pendulum
        double theta=y[0], omega=y[1];
		return new vector(omega, -b * omega - c * Sin(theta));
	};
    
    Func<double,vector,vector> f = delegate(double t, vector x){ // implementation of simple harmonic oscillator
        double pos = x[0], vel=x[1];
        return new vector(vel, -(k/m) * pos);
    };

	double start=0, stop=10;
	vector ystart = new vector(PI-0.1,0.0);
	var (x_damped,y_damped) = RK.driver(F,(start,stop),ystart);
    var (x_simple,y_simple) = RK.driver(f,(start,stop),ystart);

	for(int i=0;i<x_damped.size;i++)
		WriteLine($"{x_damped[i]} {y_damped[i][0]}"); // omega(t) (damped)
    WriteLine("\n\n\n");
    for(int i=0;i<x_damped.size;i++)
		WriteLine($"{x_damped[i]} {y_damped[i][1]}"); // theta(t) (damped)
    WriteLine("\n\n\n");
    for(int i=0;i<x_simple.size;i++)
		WriteLine($"{x_simple[i]} {y_simple[i][0]}"); // position(t) (simple)
    WriteLine("\n\n\n");
    for(int i=0;i<x_simple.size;i++)
		WriteLine($"{x_simple[i]} {y_simple[i][1]}"); // velocity(t) (simple)


 
    } // Main
} // class main

