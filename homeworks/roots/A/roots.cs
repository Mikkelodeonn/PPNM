using static System.Math;
using System;
using static vector;
using static matrix;
using static QRGS;
public static class roots{
static public vector newton(Func<vector,vector>f, vector x, double eps=1e-2){
int nsteps=0;
while(nsteps<1000){
x.print("x=",file:System.Console.Error);
	nsteps++;
	vector fx=f(x);
    	if(fx.norm() < eps){ break; }
    var J = jacobian(f, x);
J.print("J=");
    (matrix Q, matrix R) = decomp(J);
Q.print("Q=");
R.print("R=");
    vector dx = solve(Q,R,-fx);
dx.print("dx=",file:System.Console.Error);
    double lambda = 1;
    while(true){
	System.Console.Error.WriteLine($"{lambda}");
	if( f(x+lambda*dx).norm() < (1-lambda/2)*fx.norm() ) break;
	if( lambda < Pow(2,-13) ) break;
	lambda /= 2;
    }
    x += lambda*dx;
}
System.Console.Error.Write($"nsteps={nsteps}\n");
return x;
} // newton's method
public static matrix jacobian(Func<vector,vector>f, vector x){
int n = x.size;
matrix J = new matrix(n,n);
vector y = x.copy();
vector fx=f(x);
for(int i=0 ; i<n ; i++){
    double dx = Abs(y[i])*Pow(2,-26);
    y[i] += dx;
    for(int j=0 ; j<n ; j++){
        J[i,j] = (f(y) - fx)[j] / dx;
    }
    y[i] -= dx;
}
return J;
} // building the Jacobian matrix
} // roots
