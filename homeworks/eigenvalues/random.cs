public static class random{

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

public static matrix CreateRandomSymmetricMatrix(int dim){
    var rnd = new System.Random(1);
    matrix RndMat = new matrix(dim);

    for(int i=0 ; i<dim ; i++){
        for(int j=i ; j<dim ; j++){
            double RandomValue = rnd.NextDouble();
            RndMat[i,j] = RandomValue;
            RndMat[j,i] = RndMat[i,j];
        }
    }
return RndMat;

} // CreateRandomSymmetricMatrix

} // random