using static System.Math;
using static System.Console;
using System;
public static class diag{

public static (matrix,matrix) lanczos(matrix A, double acc=1e-6){
int m = A.size1; // number of iterations (default: m=n -> V is unitary)

vector u = new vector(m); 
vector v = new vector(m);
double[][] W = new double[m][];

vector alpha = new vector(m); // diagonal elements of resulting matrix
vector beta = new vector(m); // "diagonal +/- 1" elements of resulting matrix

matrix T = new matrix(m,m); // creating tri-diagonal matrix T.
matrix V = new matrix(A.size1,m); // creating matrix V.

for(int i=0 ; i<m ; i++){
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
    beta[i] = Sqrt(s); // beta = norm(w[i-1])
    for(int j=0 ; j<m ; j++){ v[j] = W[i-1][j]/beta[i]; }
    for(int j=0 ; j<A.size1 ; j++){ V[j,i] = v[j]; }
    u = A*v;
    alpha[i] = u.dot(v);
    vector a = new vector(m);
    for(int j=0 ; j<m ; j++){ a[j] = V[j,i-1]; } // mapping the (i-1)'th column of V (v[i-1]) into vector a 
    W[i] = u - alpha[i]*v - beta[i]*a;
    }
    }
for(int i=0 ; i<m ; i++){ 
    T[i,i] = alpha[i]; 
    if(i>0){ T[i,i-1] = beta[i]; }
    if(i<m-1){ T[i,i+1] = beta[i+1]; }
    }
return (V,T);
} // lanczos
} // class diag