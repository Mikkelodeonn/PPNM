using static System.Console;

class main{
static int Main(){
    matrix C = random.CreateRandomMatrix(10,10);
    (matrix Q_, matrix R_) = QRGS.decomp(C);

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.inverse()\n");
    C.print("\nRandom square matrix A:");
    Q_.print("\nCorresponding Q-matrix:");
    R_.print("\nCorresponding R-matrix:");
    matrix A_inv = QRGS.inverse(Q_,R_);
    A_inv.print("\nInverse A' of square matrix A:");
    matrix AA_ = C*A_inv;
    AA_.print("\nA times it's inverse A':");
    bool AA_I = AA_.approx(matrix.id(AA_.size1));
    WriteLine($"\nAA' is approximately equal to identity: {AA_I}\n");

return 0;
} // Main
} // class main