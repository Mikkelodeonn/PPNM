using static System.Math;
using static System.Console;
using System;
public static class diag{

public static (matrix,matrix) lanczos(matrix A, int n, double acc=1e-6){ // n -> number of Lanczos/"Arnoldi" iterations
int m = A.size1; // number of iterations (note: m=n -> V is unitary)

if(!(m >= n)) throw new Exception("Ups! Cannot have more iterations than the dimension of the input...");

vector u = new vector(m); 
vector v = new vector(m);
double[][] W = new double[m][];

vector alpha = new vector(n); // diagonal elements of resulting matrix
vector beta = new vector(n); // "diagonal +/- 1" elements of resulting matrix

matrix T = new matrix(n,n); // creating tri-diagonal matrix T.
matrix V = new matrix(m,n); // creating matrix V.

for(int i=0 ; i<n ; i++){
    if(i==0)
    {
        vector q = random.CreateRandomVector(m);
        v = q / q.norm(); // arbirtary normalized vector for v0
        for(int j=0 ; j<m ; j++){ V[j,0] = v[j]; } // saving the vector v as a column in matrix V.
        u = A*v;
        alpha[i] = v.dot(u); // initial iteration step for alpha
        vector w = u - alpha[i]*v; // initial iteration step for w  
        W[i] = w;
    }
    else
    {
    double s = 0;
    foreach(double val in W[i-1]){ s += val*val; }
    beta[i] = Sqrt(s); 
    for(int j=0 ; j<m ; j++){ v[j] = W[i-1][j]/beta[i]; }
    for(int j=0 ; j<m ; j++){ V[j,i] = v[j]; }
    u = A*v;
    alpha[i] = u.dot(v);
    vector a = new vector(m);
    for(int j=0 ; j<m ; j++){ a[j] = V[j,i-1]; } // mapping the (i-1)'th column of V (v[i-1]) into vector a 
    W[i] = u - alpha[i]*v - beta[i]*a;
    }
    }
for(int i=0 ; i<n ; i++){ 
    T[i,i] = alpha[i]; 
    if(i>0){ T[i,i-1] = beta[i]; }
    if(i<n-1){ T[i,i+1] = beta[i+1]; }
    }
return (V,T);
} // lanczos
} // class diag