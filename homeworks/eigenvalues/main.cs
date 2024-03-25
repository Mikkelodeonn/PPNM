using static System.Console;
static class main{
public static int Main(){

WriteLine("Test of implementation of Jacobi diagonalization (with cyclic sweeps):\n\n");

matrix A = random.CreateRandomSymmetricMatrix(3); 
A.print("Random symmetric matrix A:");

WriteLine("\n-----------------------------------------------------------------");

matrix a = A.copy();
(matrix D, matrix V) = EVD.cyclic(a);
D.print("\nDiagonal matrix D with corresponding eigenvalues:");

V.print("\nOrthogonal matrix V of eigenvectors:");

WriteLine("\n-----------------------------------------------------------------");

matrix VDV = V * D * V.transpose();
VDV.print("\nMatrix product VDV:");

bool VDV_A = A.approx(VDV);
WriteLine($"\nVDV == A: {VDV_A} (with precision of order 1e-6).");

WriteLine("\n-----------------------------------------------------------------");

matrix VAV = V.transpose() * A * V;
VAV.print("\nMatrix product VAV:");

bool VAV_D = D.approx(VAV);
WriteLine($"\nVAV == D: {VAV_D} (with precision of order 1e-6).");

WriteLine("\n-----------------------------------------------------------------");

matrix VtV = V.transpose() * V;
matrix I = matrix.id(A.size1);
VtV.print("\nMatrix product V(T) * V:");

bool VtV_I = I.approx(VtV);
WriteLine($"\nV(T) * V = Identity: {VtV_I} (with precision of order 1e-6).");

WriteLine("\n-----------------------------------------------------------------");

matrix VVt = V * V.transpose();
VVt.print("\nMatrix product V * V(T):");

bool VVt_I = I.approx(VVt);
WriteLine($"\nV * V(T) = Identity: {VVt_I} (with precision of order 1e-6).");
return 0;
} // Main

} // class main