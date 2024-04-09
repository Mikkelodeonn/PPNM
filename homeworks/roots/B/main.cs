using System;
using static System.Console;

public class main{

public static (genlist<double>, genlist<vector>) radial_wave_function(double e, double rmin, double rmax){
vector sch = new vector(rmin - rmin * rmin, 1 - 2 * rmin);
Func<double,vector,vector> schrodinger = (r,y) => {
    vector res = new vector(2);
    res[0] = y[1];
	res[1] = -2*y[0]*(1/r + e);
	return res;
};
double acc = 1e-3;
double eps = 1e-3;
var (pos, wave_function) = RK.driver(schrodinger, (rmin,rmax), sch, acc, eps);
return (pos, wave_function);
} // radial wave function



public static void Main(){
double rmin = 1e-3;
double rmax = 8;

(genlist<double> a, genlist<vector> b) = radial_wave_function(1, rmin, rmax);
WriteLine($"The lowest energy E0, found for rmin = {rmin} and rmax = {rmax}: {a[0]} Hartree.");
WriteLine("Exact result: -0.5 Hartree.");
WriteLine("\n\n\n");
for(int i=0;i<a.size;i++){WriteLine($"{a[i]}   {b[i][0]}    {b[i][1]}");}
} // Main
} // class main