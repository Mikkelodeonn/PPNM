using static System.Math;
using static System.Console;
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
    var J = jacobian(f, x); // J -> matrix
J.print("J=");
    var (Q,R) = decomp(J); // Q,R -> matrix
Q.print("Q=");
R.print("R=");
    vector dx = solve(Q,R,-fx);
dx.print("dx=",file:System.Console.Error);
    double lambda = 1;
    while(f(x+lambda*dx).norm() > (1-lambda/2)*fx.norm() && lambda >= Pow(2,-13) ){
	System.Console.Error.WriteLine($"{lambda}");
	lambda /= 2;
    }
    x += lambda*dx;
}
System.Console.Error.Write($"nsteps={nsteps}\n");
return x;
} // newton's method
public static matrix jacobian(Func<vector,vector>f, vector x){
int n = x.size;
matrix J = new matrix(n);
vector fx=f(x);
for(int j=0 ; j<n ; j++){
    double dx = Abs(x[j]) * Pow(2,-26);
    x[j] += dx;
    for(int i=0 ; i<n ; i++){
        vector df = f(x) - fx;
        J[j,i] = df[i] / dx; 
    }
    x[j] -= dx;
}
return J;
} // building the Jacobian matrix
} // class roots
