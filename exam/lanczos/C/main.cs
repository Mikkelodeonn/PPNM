using System;
using static System.Console;
using static System.Math;
static class main{
public static void Main(){
double rmax = 10; double dr = 0.3;
int n = (int)(rmax/dr)-1;
vector r = new vector(n);
for(int i=0;i<n;i++){ r[i]=dr*(i+1); }
matrix H = new matrix(n,n);
for(int i=0;i<n-1;i++){
   H[i,i]  =-2*(-0.5/dr/dr);
   H[i,i+1]= 1*(-0.5/dr/dr);
   H[i+1,i]= 1*(-0.5/dr/dr);
   }
H[n-1,n-1]=-2*(-0.5/dr/dr);
for(int i=0;i<n;i++)H[i,i]+=-1/r[i];

var (V,T) = diag.lanczos(H, H.size1);

(matrix A, matrix X) = EVD.cyclic(H);
double E0 = double.PositiveInfinity;
for(int i=0;i<A.size1;i++){
    if(A[i,i] < E0){
        E0 = A[i,i];
    }
}
//(matrix A_, matrix Q_) = EVD.cyclic(H);
for(int i=0 ; i<1000 ; i++){
    var (Q,R) = QRGS.decomp(T);
    T = R*Q;
}
double E0_ = double.PositiveInfinity;
for(int i=0;i<T.size1;i++){
    if(T[i,i] < E0_){
        E0_ = T[i,i];
    }
}

WriteLine($"E0 = {E0}");
WriteLine($"E0 = {E0_}");
//T.print("T_updated:");


//T.print("T-matrix:");

//matrix vv = V.transpose()*V;


//vv.print("VV=I:");

} // Main
} // class main