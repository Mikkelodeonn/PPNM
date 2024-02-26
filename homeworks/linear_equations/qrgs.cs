public static class QRGS{
   public static (matrix,matrix) decomp(matrix A){
        matrix Q=A.copy(); // A copy of A is made and denoted Q
        matrix R=new matrix(A.size2,A.size2); // size2 -> m
         /* orthogonalize Q and fill-in R */
         for(int i=0 ; i<m ; i++);{            // for i=0 to m:
            R[i,i] = Q[i].norm();                   // R(i,i) = ||Q(i)|| (Q(i) points to the i'th column)
            Q[i]/=R[i,i];                           // Q(i) = Q(i)/R(i,i)
            for(int j=i+1 ; j<m ; j++);{            // for j=i+1 to m:
                R[i,j] = Q[i].dot(Q[j]);                // R(i,j) = Q(i) * Q(j)
                Q[j]-=Q[i]*R[i,j];                      // Q(j) = Q(j) - Q(i) * R(i,j)
        }
      } 
      return (Q,R);
      } // decomp
   public static vector solve(matrix Q, matrix R, vector b){

    } // solve
   public static double det(matrix R){ ... }
   public static matrix inverse(matrix Q,matrix R){ ... }
}