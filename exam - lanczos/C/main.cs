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

var (Y,X) = EVD.cyclic(A);
var (B,C) = EVD.cyclic(T);
var (M,W) = EVD.cyclic_tuned(T);
vector Aeigenvals = new vector(Y.size1);
for(int i=0 ; i<Y.size1 ; i++){
        Aeigenvals[i] = Y[i,i];
    }

vector Teigenvals = new vector(B.size1);
for(int i=0 ; i<B.size1 ; i++){
        Teigenvals[i] = B[i,i];
    }
Aeigenvals.print("\nEigenvalues found using reg. Jacobi algorithm WITHOUT tridiagonalization (i.e. eigenvalues of matrix A):\n");
Teigenvals.print("\nEigenvalues found using reg. Jacobi algorithm WITH tridiagonalization (i.e. eigenvalues of matrix T):\n");

bool TA_check = Teigenvals.approx(Aeigenvals);
WriteLine($"\nThe reg. Jacobi eigenvalue algorithm yields identical eigenvalues with & without Lanczos tridiagonalization: {TA_check}");
WriteLine("\n================================================================================================================================\n");
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

// Jacobi tuned with Lanczos for Hydrogen

var timer2 = new Stopwatch();

timer2.Start();
var (V_H2,T_H2) = diag.lanczos(H, H.size1/2);
var (E_H2,F_H2) = EVD.cyclic(T_H2);
timer2.Stop();

var time_H2 = timer2.ElapsedTicks; 

double E0_H2 = double.PositiveInfinity;
for(int i=0 ; i<E_H2.size1 ; i++){
if(E_H2[i,i] < E0_H2){
    E0_H2 = E_H2[i,i];
        }
    }

// Vanilla jacobi algorithm for Hydrogen

var timer1 = new Stopwatch();

timer1.Start();
var (E_H1,F_H1) = EVD.cyclic(H);
timer1.Stop();

var time_H1 = timer1.ElapsedTicks; 

double E0_H1 = double.PositiveInfinity;
for(int i=0 ; i<E_H1.size1 ; i++){
if(E_H1[i,i] < E0_H1){
    E0_H1 = E_H1[i,i];
        }
    }
WriteLine("Evaluation of the running time of the algorithms:\n");
WriteLine($"Running time of the regular Jacobi algorithm: t1 = {time_H1} clock ticks");
WriteLine($"Running time of the Lanczos tuned jacobi algorithm: t2 = {time_H2} clock ticks");
WriteLine($"Fractional time difference between the two algorithms: t1/t2 = {time_H1/time_H2} (i.e. the tuned algorithm spent 1/6'th of the time on the problem).");
WriteLine($"Number of Lanczos iterations used: n = N/2 = {H.size1/2} (i.e. half the size of the hydrogenic Hamiltonian matrix)");

WriteLine("\nEvaluation of the precision of the algorithms:\n");
WriteLine($"Ground state energy found with the regular Jacobi algorithm:         {Round(E0_H1,4)} Hartree");
WriteLine($"Ground state energy found with the Lanczos tuned Jacobi algorithm:   {Round(E0_H2,4)} Hartree");
WriteLine("Exact ground state energy:                                          -0.5 Hartree"); 

WriteLine("\nConclusion:");
WriteLine("The Jacobi eigenvalue algorithm can be tuned to take advantage of the tridiagonalization from the Lanczos algorithm.");
WriteLine("\nParameters used for the calculation:");
WriteLine("rmax = 8 Bohr radii");
WriteLine("dr = 0.1 Bohr radii");
WriteLine($"Dimensions of the Hydrogenic Hamiltonian matrix: {H.size1}x{H.size2}");
WriteLine($"Dimensions of the T-matrix used to approximate the Hamiltonian after the Lanczos algorithm: {H.size1/2}x{H.size2/2}\n");

WriteLine("================================================================================================================================\n");
WriteLine("Testing the convergence of the lowest eigenvalue found by the Jacobi algorithm tuned by the Lanczos algorithm for various values of the # of Lanczos iterations n:");

for(int t=10 ; t<105 ; t+=30){
    WriteLine("\n\n");
    matrix Z = CreateRandomSymmetricMatrix(t);
    var (e,f) = EVD.cyclic(Z);
    double e0_jac = double.PositiveInfinity;
    for(int k=0 ; k<e.size1 ; k++){
        if(e[k,k] < e0_jac){
            e0_jac = e[k,k];
            }
        }
for(int i=1 ; i<Z.size1 ; i++){
    var (a,b) = diag.lanczos(Z,i); // b = T matrix
    var (c,d) = EVD.cyclic(b);
    double e0_lanc = double.PositiveInfinity;
    for(int j=0 ; j<c.size1 ; j++){
        if(c[j,j] < e0_lanc){
            e0_lanc = c[j,j];
            }
        }
    WriteLine($"{i}\t{1-(e0_lanc/e0_jac)}"); // (1-e0_lanc/e0_jac) -> 0 as the the lowest eigenvalue converges!
}
}
WriteLine("\n\n");
WriteLine("Testing the running time of the Lanczos tuned Jacobi algorithm for different values of n<N and comparing with the running time of the regular Jacobi algorithm:");
WriteLine("\n\n");
for(int n=1 ; n<=101 ; n+=10){
    vector times = new vector(10);
for(int i=1 ; i<5 ; i++){
    var q = CreateRandomSymmetricMatrix(n);

    var timer = new Stopwatch();

	timer.Start();
	var (v,t) = diag.lanczos(q,q.size1*i/5);
    var (k,j) = EVD.cyclic(t);
	timer.Stop();

	times[i] = timer.ElapsedTicks; 
}
WriteLine($"{n} {times[1]}  {times[2]}  {times[3]}  {times[4]}");
}
WriteLine("\n\n");
for(int n=1 ; n<=101 ; n+=10){
    var s = CreateRandomSymmetricMatrix(n);

    var timer = new Stopwatch();

	timer.Start();
	//var (V,T) = diag.lanczos(A,A.size1);
    var (x,y) = EVD.cyclic(s);
	timer.Stop();

	var time = timer.ElapsedTicks; 

	WriteLine($"{n} {time}");
}
} // Main
} // class main