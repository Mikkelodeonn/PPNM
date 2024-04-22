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
  Func <double,vector> F_interpolant = RK.ode_interpolant(F,(start,stop), ystart);
  Func <double,vector> f_interpolant = RK.ode_interpolant(f,(start,stop), ystart);

	for(double i=0.0 ; i<10 ; i+=1.0/16)
		WriteLine($"{i} {F_interpolant(i)[0]}"); 
  WriteLine("\n\n\n");
  for(double i=0.0 ; i<10 ; i+=1.0/16)
    WriteLine($"{i} {F_interpolant(i)[1]}"); 
  WriteLine("\n\n\n");
  for(double i=0.0 ; i<10 ; i+=1.0/16)
    WriteLine($"{i} {f_interpolant(i)[0]}"); 
  WriteLine("\n\n\n");
  for(double i=0.0 ; i<10 ; i+=1.0/16)
    WriteLine($"{i} {f_interpolant(i)[1]}"); 
  WriteLine("\n\n\n");
  
   
} // Main
} // class main

