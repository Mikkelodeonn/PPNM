using System;
using static System.Console;
using static System.Math;
static class main{
public static void Main(){
double rmax = 8; double dr = 0.1;
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

var (V_min,T_min) = diag.lanczos(H, H.size1);

for(int i=0 ; i<T_min.size1 ; i++){
    var (Q,R) = QRGS.decomp(T_min);
    T_min = R*Q;
}
double E0_min = double.PositiveInfinity;
for(int i=0;i<T_min.size1;i++){
    if(T_min[i,i] < E0_min){
        E0_min = T_min[i,i];
    }
}
WriteLine("Evaluation of the ground state energy of hydrogen found by Lanczos tridiagonalization and QR diagonalization:\n");
WriteLine($"Calculated:    {Round(E0_min,3)} Hartree");
WriteLine("Exact:         -0.5 Hartree");
WriteLine($"\ndr =            {dr} Bohr radii");
WriteLine($"rmax =          {rmax} Bohr radii");
WriteLine($"N =             {n}");

var (V8,T8) = diag.lanczos(H,8);
WriteLine("\nAn example of the tridiagonal representation T of the Hamiltonian with n<N:");
T8.print("\nT(n=8)=");
WriteLine("\n\n\n");

WriteLine("# of Lanczos iterations n:    Found ground state energy E0:");
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
    WriteLine($"{j}                             {E0}");
    }
} // Main
} // class main