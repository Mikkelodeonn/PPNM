public static class QRGS{
   public static (matrix,matrix) decomp(matrix A){
        matrix Q=A.copy(); 
        matrix R=new matrix(A.size2,A.size2); 
         for(int i=0 ; i<A.size2 ; i++){ 
            R[i,i] = Q[i].norm();
            Q[i]/=R[i,i]; 
            for(int j=i+1 ; j<A.size2 ; j++){ 
                R[i,j] = Q[i].dot(Q[j]); 
                Q[j]-=Q[i]*R[i,j]; 
        }
      } 
      return (Q,R);
      } // decomp 
   public static vector solve(matrix Q, matrix R, vector b){ // QRx=b -> Rx = b/Q = y
        vector y = Q.transpose() * b;
        int n = y.size;
        vector x = new vector(n);
        for(int i=n-1 ; i>=0 ; i--){
            double sum = 0.0;
            for(int j=i+1 ; j<n ; j++){
                sum += R[i,j] * x[j];
                }
            x[i] = (y[i] - sum)/R[i,i];      
        }
    return x;
    } // solve
   public static double det(matrix R){
        double determinant = 0;
        double U_sum = 0;
        double L_sum = 0;
        for(int i=0 ; i<R.size1 ; i++){
            for(int j=0 ; j<R.size2 ; j++){
                if(i<j){
                    L_sum += R[i,j];
                }
                else if(i>j){
                    U_sum +=R[i,j];
                }
                else{
                    determinant += R[i,j];
                }
            }
        }
        if(U_sum > 0 && L_sum > 0){
            System.Console.WriteLine("Error: Matrix is not triangular.");
        }
        else{
            return determinant;
        }
    return 0.0;
   } // det
   public static matrix inverse(matrix Q,matrix R){
        matrix Q_inverse = Q.transpose();
        matrix R_inverse = new matrix(R.size1, R.size2);

        int n = R.size1; // dimension of upper triangular matrix

        for(int i=n-1 ; i>=0 ; i--){
            R_inverse[i,i] = 1.0/R[i,i];
            for(int j=i+1 ; j<n ; j++){
                double sum = 0.0;
                for(int k=i+1 ; k<n ; k++){
                    sum += R[i,k] * R_inverse[k,j];
                }
            R_inverse[i,j] = -sum/ R[i,i];
            }
        }
        matrix A_inverse = R_inverse * Q_inverse;
    return A_inverse;
   } // inverse
} // QRGS
