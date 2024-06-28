using static System.Console;
using static System.Math;
using System;
static class main{
public static int Main(){
WriteLine("Task B: Hydrogen atom, s-wave radial Schrodinger equation on a grid\n");
double R = 10; double deltaR = 0.1;
int n = (int)(R/deltaR-1);
(double E, matrix Q) = EVD.hydrogen_s_wave(R,deltaR);
Func<double,double> f0 = z => 2*z*Exp(-z);
Func<double,double> f2 = z => -z/2*(2-z/2)*Exp(-z/2);
Func<double,double> f3 = z => 1/Sqrt(24)*z*Exp(-z/2);
vector r = new vector(n);
for(int i=0;i<n;i++){ r[i] = deltaR*(i+1); }
WriteLine($"The lowest eigenvalue (i.e. the ground state energy) of Hydrogen is found as\nCalculated: {Round(E,3)} Hartree \nExact: -0.5 Hartree\n\nrmax = {R} Bohr radii\ndr = {deltaR} Bohr radii\n# of points = {R/(deltaR)-1}\n\n");
WriteLine("1st eigenfunction of the hydrogen atom:");
WriteLine($"{0} {0} {0}");
for(int i=0;i<99;i++){
	WriteLine($"{r[i]} {Q[i,0]/Sqrt(deltaR)} {f0(r[i])}");
	}
EVD.bigskip();
WriteLine("2nd eigenfunction of the hydrogen atom:");
WriteLine($"{0} {0} {0}");
for(int i=0;i<r.size;i++){
	WriteLine($"{r[i]} {Q[i,1]/Sqrt(deltaR)} {f2(r[i])}");
	}
EVD.bigskip();
WriteLine("3rd eigenfunction of the hydrogen atom:");
WriteLine($"{0} {0} {0}");
for(int i=0;i<99;i++){
	WriteLine($"{r[i]} {Q[i,2]/Sqrt(deltaR)} {f3(r[i])}");
	}
EVD.bigskip();
WriteLine("4th eigenfunction of the hydrogen atom:");
WriteLine($"{0} {0} {0}");
for(int i=0;i<99;i++){
	WriteLine($"{r[i]} {Q[i,3]/Sqrt(deltaR)} {f0(r[i])}");
	}
EVD.bigskip();
double[] rmax_E0 = {2,3,4,5,6,7,8}; double dr_fixed = 0.1;
foreach(double rmax in rmax_E0){
    (double e0, matrix v) = EVD.hydrogen_s_wave(rmax, dr_fixed);
    WriteLine($"{rmax}  {e0}");
}
EVD.bigskip();
double rmax_fixed = 8; double[] dr_E0 = {0.02, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3};
foreach(double dr in dr_E0){
    (double e0, matrix v) = EVD.hydrogen_s_wave(rmax_fixed, dr);
    WriteLine($"{dr}    {e0}");
    }
return 0;
} // Main

} // class main