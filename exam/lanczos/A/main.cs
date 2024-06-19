using System;
using static System.Console;
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

WriteLine("---------------Testing of the implemented Lanczos tridiagonalization algorithm for real symmetric matrices---------------");

matrix A = CreateRandomSymmetricMatrix(5);

var (V,T) = diag.lanczos(A);

A.print("\nRandomly generated symmetric matrix A:");

T.print("\nResulting tridiagonal real symmetric matrix T:");

V.print("\nCorresponding (unitary) matrix with orthonormal columns V:"); 

WriteLine("\n---------------Checking the identites of a succesful tridiagonalization -> A = V * T * V^T & T = V^T * A * V---------------");

matrix Y = V*T*V.transpose();

matrix Q = V.transpose()*A*V;

Q.print("\nT = V^T * A * V:");

bool T_check = T.approx(Q, acc:1e-6);

WriteLine($"\nMatrix T is equal to V^T * A * V (within acc=1e-6): {T_check}");

Y.print("\nA = V * T * V^T:");

bool A_check = A.approx(Y, acc:1e-6);

WriteLine($"\nMatrix A is equal to V * T * V^T (within acc=1e-6): {A_check}");

} // Main
} // class main