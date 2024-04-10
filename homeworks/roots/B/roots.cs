using static System.Math;
using System;
using static vector;
using static matrix;
using static QRGS;

public static class roots{
static public vector newton(Func<vector,vector>f, vector x, double eps=1e-2){
while(true){
    var J = jacobian(f, x);
    (matrix Q, matrix R) = decomp(J);
    vector dx = solve(Q,R,-f(x));
    double lambda = 1;
    while(f(x+lambda*dx).norm() > (1-lambda/2)*f(x).norm()){
        lambda /= 2;
    }
    x += lambda*dx;
    if(f(x).norm() < eps){
        break;
    }
}
return x;
} // newton's method

public static matrix jacobian(Func<vector,vector>f, vector x){
int n = x.size;
matrix J = new matrix(n,n);
vector y = x.copy();
for(int i=0 ; i<n ; i++){
    double dx = Abs(y[i])*Pow(2,-26);
    y[i] += dx;
    for(int j=0 ; j<n ; j++){
        J[j,i] = (f(y) - f(x))[j] / dx;
    }
    y[i] -= dx;
}
return J;
} // building the Jacobian matrix

} // roots