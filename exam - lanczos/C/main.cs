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
WriteLine("Testing the reg./tuned Jacobi eigenvalue algorithms on arb. NxN matrix with/without Lanczos tridiagonalization\n");
matrix A = CreateRandomSymmetricMatrix(10);
matrix a1, a2; a1 = A.copy(); a2 = A.copy(); 
A.print("Randomly generated real symmetric NxN matrix A (N=10):");

var (V,T) = diag.lanczos(a1, a1.size1);
matrix t1,t2; t1 = T.copy(); t2 = T.copy();
T.print("\nTridiagonal matrix T found by Lanczos iterations on A:");

var (Y,X) = EVD.cyclic(a2);
var (B,C) = EVD.cyclic(t1);
var (M,W) = EVD.cyclic_tuned(t2);
vector Aeigenvals = new vector(Y.size1);
for(int i=0 ; i<Y.size1 ; i++){
        Aeigenvals[i] = Y[i,i];
    }

vector Teigenvals = new vector(B.size1);
for(int i=0 ; i<B.size1 ; i++){
        Teigenvals[i] = B[i,i];
    }

vector Meigenvals = new vector(M.size1);
for(int i=0 ; i<M.size1 ; i++){
        Meigenvals[i] = M[i,i];
    }
//Aeigenvals.print("\nEigenvalues found using reg. Jacobi algorithm WITHOUT tridiagonalization (i.e. eigenvalues of matrix A):\n");
//Teigenvals.print("\nEigenvalues found using reg. Jacobi algorithm WITH tridiagonalization (i.e. eigenvalues of matrix T):\n");
//Meigenvals.print("\nEigenvalues found using tuned Jacobi algorithm WITH tridiagonalization (i.e. eigenvalues of matrix T):\n");
WriteLine("\nComparing extreme eigenvalues:\n");
WriteLine("Comparison of largest eigenvalues found:");
WriteLine($"Reg. Jacobi on A: {Round(Aeigenvals[Aeigenvals.size-1],2)}");
WriteLine($"Reg. Jacobi on T: {Round(Aeigenvals[Teigenvals.size-1],2)}");
WriteLine($"Tuned Jacobi on T: {Round(Meigenvals[Meigenvals.size-1],2)}");
WriteLine("\nComparison of smallest eigenvalues found:");
WriteLine($"Reg. Jacobi on A: {Round(Aeigenvals[0],2)}");
WriteLine($"Reg. Jacobi on T: {Round(Aeigenvals[0],2)}");
WriteLine($"Tuned Jacobi on T: {Round(Meigenvals[0],2)}");

WriteLine("\n================================================================================================================================");
WriteLine("================================================================================================================================\n");
WriteLine("Testing the convergence of the lowest eigenvalue found by reg. Jacobi on tridiagonal matrices for various values of the # of Lanczos iterations n:");

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

WriteLine("Testing the running time of reg. Jacobi on tridiag. matrices T for different values of n<N and comparing with the running time of reg. Jacobi on sym. matrix A from which T is constructed:");
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
WriteLine("\n\n");
WriteLine("Testing the convergence of the lowest eigenvalue found by tuned Jacobi on tridiag. matrices for various values of the # of Lanczos iterations n:");
WriteLine("\n\n");

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
    var (c,d) = EVD.cyclic_tuned(b);
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
    var (k,j) = EVD.cyclic_tuned(t);
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