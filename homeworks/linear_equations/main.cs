using static System.Console;

class main{
static int Main(){
    WriteLine("TASK A:");
    WriteLine("\n____________________________________________________\nTest of QRGS.decomp\n");

    matrix A = CreateRandomMatrix(6,3);
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

    vector b = CreateRandomVector(5);
    matrix C = CreateRandomMatrix(5,5);
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

public static matrix CreateRandomMatrix(int rows, int columns){
    var rnd = new System.Random(1); 
    matrix RndMat = new matrix(rows,columns);

    for(int i=0 ; i<rows ; i++){
        for(int j=0 ; j<columns ; j++){
            double RandomValue = rnd.NextDouble();
            RndMat[i,j] = RandomValue;
        }
    }
return RndMat;
} // CreateRandomMatrix

public static vector CreateRandomVector(int n){
    var rnd = new System.Random(1);
    vector RndVec = new vector(n);

    for(int i=0 ; i<n ; i++){
        double RandomVal = rnd.NextDouble();
        RndVec[i] = RandomVal;
    }
return RndVec;
} // CreateRandomVector

} // class main