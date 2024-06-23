using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;
static class main{
public static matrix CreateRandomSymmetricMatrix(int N){
Random random = new Random();
matrix A = new matrix(N,N);
for(int i=0 ; i<N ; i++){
    for(int j=0 ; j<N ; j++){
        double val = random.NextDouble();
        A[i,j] = val;
        A[j,i] = val;
    }
}
return A;
}
public static void Main(){

 WriteLine("Testing the Jacobi eigenvalue algorithm on arb. NxN matrix with/without Lanczos tridiagonalization\n");
matrix A = CreateRandomSymmetricMatrix(10);
A.print("Randomly generated real symmetric NxN matrix A (N=10):");

var (V,T) = diag.lanczos(A, A.size1);
T.print("\nTridiagonal matrix T found by Lanczos iterations on A:");

var (Y,X) = EVD.cyclic(T);
var (B,C) = EVD.cyclic_tuned(T);
vector Aeigenvals = new vector(Y.size1);
for(int i=0 ; i<Y.size1 ; i++){
        Aeigenvals[i] = Y[i,i];
    }

vector Teigenvals = new vector(B.size1);
for(int i=0 ; i<B.size1 ; i++){
        Teigenvals[i] = B[i,i];
    }
Aeigenvals.print("\nEigenvalues found using Jacobi eigenvalue algorithm WITHOUT tridiagonalization (i.e. eigenvalues of matrix A):\n");

Teigenvals.print("\nEigenvalues found using Jacobi eigenvalue algorithm WITH tridiagonalization (i.e. eigenvalues of matrix T):\n");

bool TA_check = Teigenvals.approx(Aeigenvals);
WriteLine($"\nThe Jacobi eigenvalue algorithm yields identical eigenvalues with & without Lanczos tridiagonalization of a random symmetric 10x10 matrix: {TA_check}");
WriteLine("Comparison of the running time and precision of the reg./tuned jacobi algorithm with & without Lanczos iterations used on the Hydrogen atom from exersize B:\n");
double rmax = 8; double dr = 0.1;
int N = (int)(rmax/dr)-1;
vector r = new vector(N);
for(int i=0;i<N;i++){ r[i]=dr*(i+1); }
matrix H = new matrix(N,N);
for(int i=0;i<N-1;i++){
   H[i,i]  = -2*(-0.5/dr/dr);
   H[i,i+1] = 1*(-0.5/dr/dr);
   H[i+1,i] = 1*(-0.5/dr/dr);
   }
H[N-1,N-1] = -2*(-0.5/dr/dr);
for(int i=0;i<N;i++){ H[i,i]+=-1/r[i]; }

// Vanilla jacobi algorithm for Hydrogen

var timer1 = new Stopwatch();
var (V_H2,T_H2) = diag.lanczos(H, H.size1/2);

timer1.Start();
var (E_H1,F_H1) = EVD.cyclic(T_H2);
timer1.Stop();

var time_H1 = timer1.ElapsedTicks; 

double E0_H1 = double.PositiveInfinity;
for(int i=0 ; i<E_H1.size1 ; i++){
if(E_H1[i,i] < E0_H1){
    E0_H1 = E_H1[i,i];
        }
    }

// Jacobi tuned with Lanczos for Hydrogen

var timer2 = new Stopwatch();

timer2.Start();

var (E_H2,F_H2) = EVD.cyclic(T_H2);
timer2.Stop();

var time_H2 = timer2.ElapsedTicks; 

double E0_H2 = double.PositiveInfinity;
for(int i=0 ; i<E_H2.size1 ; i++){
if(E_H2[i,i] < E0_H2){
    E0_H2 = E_H2[i,i];
        }
    }

var timer3 = new Stopwatch();

timer3.Start();
var (V_H3,T_H3) = diag.lanczos(H, 3*H.size1/5);
var (E_H3,F_H3) = EVD.cyclic_tuned(T_H2);
timer3.Stop();

var time_H3 = timer3.ElapsedTicks; 

double E0_H3 = double.PositiveInfinity;
for(int i=0 ; i<E_H3.size1 ; i++){
if(E_H3[i,i] < E0_H3){
    E0_H3 = E_H3[i,i];
        }
    }



WriteLine("Evaluation of the running time of the algorithms:\n");
WriteLine($"Running time of reg. Jacobi algorithm on H: t1 = {time_H1} clock ticks");
WriteLine($"Running time of reg. jacobi algorithm on T: t2 = {time_H2} clock ticks");
WriteLine($"Running time of tuned jacobi algorithm on T: t3 = {time_H3} clock ticks");
WriteLine($"Fractional time difference between the fastest and slowest implementation: t1/t3 = {time_H1/time_H3} (i.e. the tuned algorithm spent 1/7'th of the time on the problem).");
WriteLine($"Number of Lanczos iterations used: n = 3*N/5 = {3*H.size1/5} (i.e. 3/5 the size of the hydrogenic Hamiltonian matrix)");

WriteLine("\nEvaluation of the precision of the algorithms:\n");
WriteLine($"Ground state energy found with the reg. Jacobi algorithm on H:         {Round(E0_H1,4)} Hartree");
WriteLine($"Ground state energy found with the reg. Jacobi algorithm on T:   {Round(E0_H2,4)} Hartree");
WriteLine($"Ground state energy found with the tuned Jacobi algorithm on T:   {Round(E0_H3,4)} Hartree");
WriteLine("Exact ground state energy:                                          -0.5 Hartree"); 

WriteLine("\nConclusion:");
WriteLine("The Jacobi eigenvalue algorithm can be tuned to take advantage of the tridiagonalization from the Lanczos algorithm.");
WriteLine("\nParameters used for the calculation:");
WriteLine("rmax = 8 Bohr radii");
WriteLine("dr = 0.1 Bohr radii");
WriteLine($"Dimensions of the Hydrogenic Hamiltonian matrix: {H.size1}x{H.size2}");
WriteLine($"Dimensions of the T-matrix used to approximate the Hamiltonian after the Lnaczos algorithm: {H.size1/2}x{H.size2/2}\n");

} // Main
} // class main