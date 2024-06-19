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

WriteLine("---- Testing of Lanczos tridiagonalization algorithm for an arb. real symmetric matrix with dim. n=5 & # of iterations m=5 ----");

matrix A1 = CreateRandomSymmetricMatrix(5);

var (V1,T1) = diag.lanczos(A1, 5);

A1.print("\nRandomly generated symmetric matrix A:");

T1.print("\nResulting tridiagonal real symmetric matrix T:");

V1.print("\nCorresponding matrix with orthonormal columns V:"); 

WriteLine("\n---- Checking the identites of a succesful tridiagonalization, i.e. A = V * T * V^T   &   T = V^T * A * V ----");

matrix Y1 = V1*T1*V1.transpose();

matrix Q1 = V1.transpose()*A1*V1;

Q1.print("\nT = V^T * A * V:");

bool T_check1 = T1.approx(Q1, acc:1e-6);

WriteLine($"\nMatrix T is equal to V^T * A * V (within acc=1e-6): {T_check1}");

Y1.print("\nA = V * T * V^T:");

bool A_check1 = A1.approx(Y1, acc:1e-6);

WriteLine($"\nMatrix A is equal to V * T * V^T (within acc=1e-6): {A_check1}");

WriteLine("\n===============================================================================================================================================");
WriteLine("===============================================================================================================================================\n");

WriteLine("---- Testing of Lanczos tridiagonalization algorithm for an arb. real symmetric matrix with dim. n=5 & # of iterations m=3 ----");

matrix A2 = CreateRandomSymmetricMatrix(5);

var (V2,T2) = diag.lanczos(A2, 3);

A2.print("\nRandomly generated symmetric matrix A:");

T2.print("\nResulting tridiagonal real symmetric matrix T:");

V2.print("\nCorresponding matrix with orthonormal columns V:"); 

WriteLine("\n---- Checking the identites of a succesful tridiagonalization, i.e. A = V * T * V^T   &   T = V^T * A * V ----");

matrix Y2 = V2*T2*V2.transpose();

matrix Q2 = V2.transpose()*A2*V2;

Q2.print("\nT = V^T * A * V:");

bool T_check2 = T2.approx(Q2, acc:1e-6);

WriteLine($"\nMatrix T is equal to V^T * A * V (within acc=1e-6): {T_check2}");

Y2.print("\nA = V * T * V^T:");

bool A_check2 = A2.approx(Y2, acc:1e-6);

WriteLine($"\nMatrix A is equal to V * T * V^T (within acc=1e-6): {A_check2} (this is ONLY true for n=m, when V is unitary)");

} // Main
} // class main