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
    B.print("\nQ(T) times Q:");

    bool identity = B.approx(matrix.id(3));
    WriteLine($"\nQ(T) times Q is approximately equal to identity: {identity}");

    matrix QR = Q*R; bool QRA = QR.approx(A);
    QR.print("\nQ times R:"); WriteLine($"\nQR is approximately equal to A: {QRA}");

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.solve\n");

    vector b = random.CreateRandomVector(5); matrix C = random.CreateRandomMatrix(5,5);
    C.print("Random square matrix:");
    b.print("\nRandom vector b:\n");
    (matrix Q_, matrix R_) = QRGS.decomp(C); vector x = QRGS.solve(Q_,R_,b);
    Q_.print("\nCorresponding Q-matrix:");
    R_.print("\nCorresponding R-matrix:");
    x.print("\nSolution to QRx=b:\n x = ");
    vector Ax = C*x;
    Ax.print("\nA*x:"); b.print("b:");
    bool Ax_b = Ax.approx(b); WriteLine($"\nAx is approximately equal to b: {Ax_b}");

    WriteLine("\n________________________________________________________________________________________________________\nTest of QRGS.det\n");

    double det_R = QRGS.det(R);
    WriteLine($"Determinant of R:\n {det_R}\n");

return 0;
} // Main
} // class main