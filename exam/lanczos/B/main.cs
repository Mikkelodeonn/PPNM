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
   H[i,i]  = -2*(-0.5/dr/dr);
   H[i,i+1] = 1*(-0.5/dr/dr);
   H[i+1,i] = 1*(-0.5/dr/dr);
   }
H[n-1,n-1] = -2*(-0.5/dr/dr);
for(int i=0;i<n;i++){ H[i,i]+=-1/r[i]; }

for(int j=1 ; j<H.size1 ; j++){
    var (V,T) = diag.lanczos(H, j);

    for(int i=0 ; i<T.size1 ; i++){
        var (Q,R) = QRGS.decomp(T);
        T = R*Q;
    }
    double E0 = double.PositiveInfinity;
    for(int i=0;i<T.size1;i++){
        if(T[i,i] < E0){
            E0 = T[i,i];
        }
    }
    WriteLine($"{j} {E0}");
    }
} // Main
} // class main