using static System.Console;
using static System.Math;
using System;
static class main{
public static int Main(){

WriteLine("Task A: Test of implementation of Jacobi diagonalization (with cyclic sweeps):");

matrix A = random.CreateRandomSymmetricMatrix(4); 
A.print("Random symmetric matrix A:");

WriteLine("-----------------------------------------------------------------");

matrix a = A.copy();
(matrix D, matrix V) = EVD.cyclic(a);
D.print("Diagonal matrix D with corresponding eigenvalues:");

V.print("Orthogonal matrix V of eigenvectors:");

WriteLine("-----------------------------------------------------------------");

matrix VDV = V * D * V.transpose();
VDV.print("\nMatrix product VDV:");

bool VDV_A = A.approx(VDV);
WriteLine($"\nVDV == A: {VDV_A} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");

matrix VAV = V.transpose() * A * V;
VAV.print("Matrix product VAV:");

bool VAV_D = D.approx(VAV);
WriteLine($"VAV == D: {VAV_D} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");

matrix VtV = V.transpose() * V;
matrix I = matrix.id(A.size1);
VtV.print("Matrix product V(T) * V:");

bool VtV_I = I.approx(VtV);
WriteLine($"V(T) * V = Identity: {VtV_I} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");

matrix VVt = V * V.transpose();
VVt.print("\nMatrix product V * V(T):");

bool VVt_I = I.approx(VVt);
WriteLine($"V * V(T) = Identity: {VVt_I} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");
WriteLine("Task B: Hydrogen atom, s-wave radial Schrodinger equation on a grid");
EVD.bigskip();
double rmax_fixed = 6; double[] dr_E0 = {0.02, 0.05, 0.1, 0.15, 0.2, 0.25, 0.3};
foreach(double dr in dr_E0){
    (double e0, matrix v) = EVD.hydrogen_s_wave(rmax_fixed, dr);
    WriteLine($"{dr}    {e0}");
    }
EVD.bigskip();
double[] rmax_E0 = {2,3,4,5,6,7,8}; double dr_fixed = 0.1;
foreach(double rmax in rmax_E0){
    (double e0, matrix v) = EVD.hydrogen_s_wave(rmax, dr_fixed);
    WriteLine($"{rmax}  {e0}");
}
EVD.bigskip();
double R = 10; double deltaR = 0.1;
int n = (int)(R/deltaR-1);
(double E, matrix Q) = EVD.hydrogen_s_wave(R,deltaR);
Func<double,double> f0 = z => 2*z*Exp(-z);
vector r = new vector(n);
for(int i=0;i<n;i++){r[i] = deltaR*(i+1);}
WriteLine($"{0} {0} {0}");
for(int i=0;i<99;i++){
	WriteLine($"{r[i]} {Q[i,0]/Sqrt(deltaR)} {f0(r[i])}");
	}
return 0;
} // Main

} // class main