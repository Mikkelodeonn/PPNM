using static System.Console;

class main{
static int Main(){
    WriteLine("TASK A:");
    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.decomp\n");

    matrix A = random.CreateRandomMatrix(6,3);
    A.print("Random matrix A:");

    (matrix Q, matrix R) = QRGS.decomp(A);
    Q.print("\nQ-matrix:"); R.print("\nR-matrix:");

    matrix Q_transposed = Q.transpose(); matrix B = Q_transposed * Q;
    B.print("\nQ.transposed times Q:");

    bool identity = B.approx(matrix.id(3));
    WriteLine($"\nQ.transposed times Q is approximately equal to identity: {identity}");

    matrix QR = Q*R; bool QRA = QR.approx(A);
    QR.print("\nQ times R:"); WriteLine($"\nQR is approximately equal to A: {QRA}");

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.solve\n");

    vector b = random.CreateRandomVector(5); matrix C = random.CreateRandomMatrix(5,5);
    C.print("Random square matrix:");
    (matrix Q_, matrix R_) = QRGS.decomp(C); vector x = QRGS.solve(Q_,R_,b);
    x.print("\nSolution to QRx=b:\n x = ");
    vector Ax = C*x;
    Ax.print("\nA*x:"); b.print("b:");
    bool Ax_b = Ax.approx(b); WriteLine($"\nAx is approximately equal to b: {Ax_b}");

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.det\n");

    double determinant = QRGS.det(R);
    WriteLine($"Determinant of R:\n det(R) = {determinant}\n");

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.inverse\n");
    C.print("\nRandom square matrix A:");
    matrix A_inv = QRGS.inverse(Q_,R_);
    A_inv.print("\nInverse B of square matrix A:");
    matrix AA_ = C*A_inv;
    AA_.print("\nA times it's inverse:");
    bool AA_I = AA_.approx(matrix.id(AA_.size1));
    WriteLine($"\nAB approximately equal to identity: {AA_I}\n");

return 0;
} // Main
} // class main