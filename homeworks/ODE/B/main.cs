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
  Func <double,vector> F_interpolant = RK.ode_interpolant(F, (start,stop), ystart);
  Func <double,vector> f_interpolant = RK.ode_interpolant(f, (start,stop), ystart);

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

  double eps = 0.0;
  Func<double,vector,vector> newtonian_motion = delegate(double t, vector y){
    double y0 = y[0], y1 = y[1];
    return new vector(y1, 1 - y0 + eps * y0 * y0);
  };
  vector init1 = new vector(1, 0);
  vector init2 = new vector(1, -0.5);
  Func<double,vector> f_circular = RK.ode_interpolant(newtonian_motion, (0,36), init1);
  Func<double,vector> f_eliptical = RK.ode_interpolant(newtonian_motion, (0,36), init2);

  for(double i=0.0 ; i<36 ; i+=1.0/16){
    double u = f_eliptical(i)[0], phi = f_eliptical(i)[1];
    WriteLine($"{(1/u)*Cos(phi)} {(1/u)*Sin(phi)}");
  }
  WriteLine("\n\n\n");
  for(double i=0.0 ; i<36 ; i+=1.0/16){
    double u = f_circular(i)[0], phi = f_circular(i)[1];
    WriteLine($"{(1/u)*Cos(phi)} {(1/u)*Sin(phi)}");
  }
   
} // Main
} // class main

