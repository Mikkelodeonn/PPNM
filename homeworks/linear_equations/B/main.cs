using static System.Console;

class main{
static int Main(){
    matrix C = random.CreateRandomMatrix(5,5);
    (matrix Q_, matrix R_) = QRGS.decomp(C);

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.inverse\n");
    C.print("\nRandom square matrix A:");
    matrix A_inv = QRGS.inverse(Q_,R_);
    A_inv.print("\nInverse B of square matrix A:");
    matrix AA_ = C*A_inv;
    AA_.print("\nA times it's inverse B:");
    bool AA_I = AA_.approx(matrix.id(AA_.size1));
    WriteLine($"\nAB approximately equal to identity: {AA_I}\n");

return 0;
} // Main
} // class main