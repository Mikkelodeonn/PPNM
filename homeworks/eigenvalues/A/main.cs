using static System.Console;
using static System.Math;
using System;
static class main{
public static int Main(){

WriteLine("Task A: Test of implementation of Jacobi diagonalization (with cyclic sweeps):");

matrix A = random.CreateRandomSymmetricMatrix(4); 
A.print("Random symmetric matrix A:");

WriteLine("-----------------------------------------------------------------");

matrix a = A.copy();
(matrix D, matrix V) = EVD.cyclic(a);
D.print("Diagonal matrix D with corresponding eigenvalues:");

V.print("Orthogonal matrix V of eigenvectors:");

WriteLine("-----------------------------------------------------------------");

matrix VDV = V * D * V.transpose();
VDV.print("\nMatrix product VDV:");

bool VDV_A = A.approx(VDV);
WriteLine($"\nVDV == A: {VDV_A} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");

matrix VAV = V.transpose() * A * V;
VAV.print("Matrix product VAV:");

bool VAV_D = D.approx(VAV);
WriteLine($"VAV == D: {VAV_D} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");

matrix VtV = V.transpose() * V;
matrix I = matrix.id(A.size1);
VtV.print("Matrix product V(T) * V:");

bool VtV_I = I.approx(VtV);
WriteLine($"V(T) * V = Identity: {VtV_I} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");

matrix VVt = V * V.transpose();
VVt.print("\nMatrix product V * V(T):");

bool VVt_I = I.approx(VVt);
WriteLine($"V * V(T) = Identity: {VVt_I} (with precision of order 1e-6).");

WriteLine("-----------------------------------------------------------------");
return 0;
} // Main

} // class main