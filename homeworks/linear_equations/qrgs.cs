public static class QRGS{
   public static (matrix,matrix) decomp(matrix A){
        matrix Q=A.copy(); // A copy of A is made and denoted Q
        matrix R=new matrix(A.size2,A.size2); // size2 -> m
         /* orthogonalize Q and fill-in R */
         for(int i=0 ; i<A.size2 ; i++){            // for i=0 to m:
            R[i,i] = Q[i].norm();                   // R(i,i) = ||Q(i)|| (Q(i) points to the i'th column)
            Q[i]/=R[i,i];                           // Q(i) = Q(i)/R(i,i)
            for(int j=i+1 ; j<A.size2 ; j++){            // for j=i+1 to m:
                R[i,j] = Q[i].dot(Q[j]);                // R(i,j) = Q(i) * Q(j)
                Q[j]-=Q[i]*R[i,j];                      // Q(j) = Q(j) - Q(i) * R(i,j)
        }
      } 
      return (Q,R);
      } // decomp 
   public static vector solve(matrix Q, matrix R, vector b){ // QRx=b
        vector y = Q.transpose() * b;
        int n = Q.size2;
        vector x = new vector(n);
        for(int i=n-1 ; i>=0 ; i--){
            double sum = 0.0;
            for(int j=i+1 ; j<n ; j++){
                sum += R[i,j] * x[j];
                x[i] = (y[i] - sum)/R[i,i];      
            }
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
   //public static matrix inverse(matrix Q,matrix R){ ... }
} // QRGS