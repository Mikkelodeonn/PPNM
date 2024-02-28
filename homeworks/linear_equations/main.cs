using static System.Console;

class main{
static int Main(){
    WriteLine("TASK A:");
    WriteLine("\n____________________________________________________\nTest of QRGS.decomp\n");

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

    WriteLine("\n____________________________________________________\nTest of QRGS.solve\n");

    vector b = random.CreateRandomVector(5);
    matrix C = random.CreateRandomMatrix(5,5);
    C.print("Random square matrix:");
    (matrix Q_, matrix R_) = QRGS.decomp(C);
    vector x = QRGS.solve(Q_,R_,b);
    x.print("Solution to QRx=b:\n x = ");
    vector Ax = C*x;
    Ax.print("A*x:");
    b.print("b:");

    WriteLine("\n____________________________________________________\nTest of QRGS.det\n");

    double determinant = QRGS.det(R);
    WriteLine($"Determinant of R:\n det(R) = {determinant}");

return 0;
} // Main
} // class main