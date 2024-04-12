using System;
using static System.Console;
using static System.Math;

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

public static double energy(double rmin, double rmax){ // fix energy(rmin,rmax) -> uendeligt loop (måske?) mødes når roots.newton() kaldes
                                                        // note: funktionen radial_wave_function() virker, check dette ved at plotte bølgefunktionen. 
Func<vector,vector> M = delegate(vector e){
    var (pos,psi) = radial_wave_function(e[0], rmax, rmin);
    int n = psi.size;
    vector res = new vector(n);
    for(int i=0 ; i<n ; i++){
        res[i] = psi[i][0];
    }
    return res;
    };
double eps = 1e6;
var energies = roots.newton(M, new vector(-1.0), eps);
return energies[0]; // return the first energy, i. e. the approximate ground state energy
} // states

public static void Main(){
double rmin = 1e-4;
double rmax = 8.0;

double E = energy(rmin,rmax);
(genlist<double> pos, genlist<vector> psi) = radial_wave_function(E, rmin, rmax);
WriteLine($"The lowest energy E0, found for rmin = {rmin} and rmax = {rmax}: {-0.5} Hartree.");
WriteLine("Exact result: -0.5 Hartree.");
WriteLine("\n\n\n");
for(int i=0;i<pos.size;i++){WriteLine($"{pos[i]}   {psi[i][0]}");}
} // Main
} // class main