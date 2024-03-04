using System;
public static class lslib{
public static (vector,matrix) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){

    // fs -> fitting functions
    // x,y -> data
    // dy -> errors of data

    int n = x.size, m = fs.Length;
    var A = new matrix(n,m);
    var b = new vector(n);
    for(int i=0 ; i<n ; i++){
        b[i] = y[i] / dy[i];
        for(int j=0 ; j<m ; j++){
            A[i,j] = fs[j](x[i]) / dy[i];
        }
    }

    var (Q,R) = QRGS.decomp(A);
    vector c = QRGS.solve(Q,R,b);

    var A_inv = QRGS.inverse(Q,R);
    matrix cov_mat = A_inv * A_inv.transpose(); // calculating the covariance matrix as A_inv * (A_inv)^T (27).

    return (c,cov_mat);

} // lsfit

} // lslib