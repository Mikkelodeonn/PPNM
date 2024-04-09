using System;
using static System.Console;

public class main{

public static vector radial_wave_function(double e, double rmin, double rmax){
vector sch = new vector(rmin - rmin * rmin, 1 - 2 * rmin);
Func<double,vector,vector> schrodinger = (r,y) => {
    vector res = new vector(2);
    res[0] = y[1];
	res[1] = -2*y[0]*(1/r + e);
	return res;
};
double acc = 1e-3;
double eps = 1e-3;
var (x_sol, y_sol) = RK.driver(schrodinger, (rmin,rmax), sch, acc, eps);
return y_sol[0];
} // radial wave function

public static double states(double rmin, double rmax) {
Func<vector,vector> M = delegate(vector e) {
    var res = radial_wave_function(e[0], rmax, rmin);
    return res;
    };
double eps = 1e-3;
var energies = roots.newton(M, new vector(-1.0), eps);
return energies[0];
} // states

public static void Main(){
double rmin = 1e-3;
double rmax = 8;

double E0 = states(rmin, rmax);
WriteLine($"The lowest energy E0, found for rmin = {rmin} and rmax = {rmax}: {E0} Hartree.");
WriteLine("Exact result: -0.5 Hartree.");
} // Main
} // class main