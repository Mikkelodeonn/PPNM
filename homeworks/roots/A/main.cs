using static System.Console;
using static System.Math;
using System;
public class main{
static public void Main(){
var y = new vector(2,2);
Func<vector,vector> rosenbrock = delegate(vector x){
    vector fx = new vector(2);
    fx[0] = -2*(1 - x[0]) -2*x[0]*200*(x[1] - x[0]*x[0]);
	fx[1] = 200*(x[1] - x[0]*x[0]);
	return fx;
    };
var res1 = roots.newton(rosenbrock, y);
WriteLine("Testing my implementation on Rosenbrock's valley function f(x,y) = (1-x)^2 + 100(y-x^2)^2:");
res1.print("Extremum is found at:\n (x,y) = ");

Func<vector,vector> himmelblau = delegate(vector x){
    vector fx = new vector(2);
    fx[0] = 2*(Pow(x[0],2) + x[1] -11)*(2*x[0]) + 2*(x[0] + Pow(x[1],2) -7);
    fx[1] = 2*(Pow(x[0],2) + x[1] -11) + 2*(x[0] + Pow(x[1],2) -7)*(2*x[1]);
    return fx;
};
var res2 = roots.newton(himmelblau, y);
WriteLine("Testing my implementation on the Himmelblau function f(x,y) = (x^2+y-11)^2+(x+y^2-7)^2");
res2.print("Minimum is found at:\n (x,y) = ");

WriteLine("\n\n\n");
WriteLine($"{res1[0]}  {res1[1]}    {0}");
WriteLine("\n\n\n");
WriteLine($"{res2[0]}  {res2[1]}    {0}");



}

} // main