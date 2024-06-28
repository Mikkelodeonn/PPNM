using System;
using static System.Console;
using static System.Math;
public class main{
public static (genlist<double>, genlist<vector>) radial_wave_function(double e, double rmin, double rmax, double eps, double acc){
vector boundary_conditions = new vector(rmin - rmin * rmin, 1 - 2 * rmin); 
Func<double,vector,vector> schrodinger = (r,y) => {
    vector res = new vector(2);
    res[0] = y[1];
	res[1] = -2*y[0]*(1/r + e);
	return res;
};
//double acc = 1e-3;
//double eps = 1e-3;
var (pos, wave_function) = RK.driver(schrodinger, (rmin,rmax), boundary_conditions, eps:eps, acc:acc);
return (pos, wave_function);
} // radial wave function

public static double energy(double rmin, double rmax, double eps, double acc){ 
Func<vector,vector> M = delegate(vector e){
    var (r,psi) = radial_wave_function(e[0], rmin, rmax, acc:acc, eps:eps);
    vector res = new vector(1);
	res[0]=psi[psi.size-1][0];
    return res;
    };
//eps = 1e-2;
var energies = roots.newton(M, new vector(-1.0), eps);
return energies[0]; // return the first energy, i. e. the approximate ground state energy
} // energy

public static void Main(){
double rmin = 1e-4;
double rmax = 8.0;
double eps = 1e-2;
double acc = 0.01;

double E = energy(rmin,rmax,eps,acc);
var (r,psi) = radial_wave_function(E, rmin, rmax,eps,acc);
WriteLine($"The ground state energy found for rmin = {rmin} and rmax = {rmax} with acc = {acc}:");
WriteLine($"Calculated:    {E} Hartree");
WriteLine("Exact:         -0.5 Hartree (given in exercise).");
WriteLine("\n\n\n");
for(int i=0;i<r.size;i++){WriteLine($"{r[i]}    {psi[i][0]}");}
WriteLine("\n\n\n");
for(int i=0;i<r.size;i++){WriteLine($"{r[i]}    {r[i]*Exp(-r[i])}");}
WriteLine("\n\n\n");
for(double R=0.5 ; R>1e-4 ; R-=1.0/32){
    double E_rmin = energy(R,rmax,eps=1e-2,acc=0.01);
    WriteLine($"{R} {E_rmin}");
    }
WriteLine("\n\n\n");
for(double R=2.0;R<8.0;R+=1.0/8){
    double E_rmax = energy(rmin,R,eps=1e-2,acc=0.01);
    WriteLine($"{R} {E_rmax}");
    }
WriteLine("\n\n\n");
for(double Eps=10 ; Eps>=1e-6 ; Eps-=1.0/16){
    double E_eps = energy(rmin,rmax,eps=Eps,acc=0.01);
    WriteLine($"{Eps} {E_eps}");
    }
WriteLine("\n\n\n");
for(double Acc=10 ; Acc>=1e-6 ; Acc-=1.0/16){
    double E_acc = energy(rmin,rmax,eps=1e-2,acc=Acc);
    WriteLine($"{Acc} {E_acc}");
    }
} // Main
} // class main
