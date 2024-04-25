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

  double eps1 = 0.0;
  Func<double,vector,vector> newtonian_motion = delegate(double t, vector y){
    double y0 = y[0], y1 = y[1];
    return new vector(y1, 1 - y0 + eps1 * y0 * y0);
  };
  double eps2 = 0.01;
  Func<double,vector,vector> relativistic_motion = delegate(double t, vector y){
    double y0 = y[0], y1 = y[1];
    return new vector(y1, 1 - y0 + eps2 * y0 * y0);
  };
  vector init1 = new vector(1, 0);
  vector init2 = new vector(1, -0.5);
  Func<double,vector> f_circular = RK.ode_interpolant(newtonian_motion, (0,10), init1);
  Func<double,vector> f_eliptical = RK.ode_interpolant(newtonian_motion, (0,10), init2);
  Func<double,vector> f_rel = RK.ode_interpolant(relativistic_motion, (0,10), init2);

  for(double φ=0.0 ; φ<10 ; φ+=1.0/16){
    double u = f_circular(φ)[0], up = f_circular(φ)[1];
    WriteLine($"{(1/u)*Cos(φ)} {(1/u)*Sin(φ)}");
  }
  WriteLine("\n\n\n");
  for(double φ=0.0 ; φ<10 ; φ+=1.0/16){
    double u = f_eliptical(φ)[0], phi = f_eliptical(φ)[1];
    WriteLine($"{(1/u)*Cos(φ)} {(1/u)*Sin(φ)}");
  }
  WriteLine("\n\n\n");
  for(double φ=0.0 ; φ<10 ; φ+=1.0/16){
    double u = f_rel(φ)[0], phi = f_rel(φ)[1];
    WriteLine($"{(1/u)*Cos(φ)} {(1/u)*Sin(φ)}");
  }
} // Main
} // class main

