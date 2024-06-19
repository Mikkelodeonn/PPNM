using System;
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

matrix A = CreateRandomSymmetricMatrix(5);

var (V,T) = diag.lanczos(A);

A.print("A:");

V.print("V:"); 

T.print("T:");

matrix Q = V.transpose()*A*V;

Q.print("VAV=T:");

} // Main
} // class main