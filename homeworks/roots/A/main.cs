using static System.Console;
using static System.Math;
using System;
public class main{
static public void Main(){
vector start;
int ncalls=0;
Func<vector,vector> rosenbrock = delegate(vector p){
	ncalls++;
    vector fx = new vector(2);
	double x=p[0],y=p[1];
	fx[0] = 2*(1-x)*(-1)+100*2*(y-x*x)*(-2*x);
	fx[1] = 100*2*(y-x*x);
	return fx;
    };
start=new vector(2,2);
ncalls=0; var res1 = roots.newton(rosenbrock, start);
WriteLine("----Testing my implementation on Rosenbrock's valley function f(x,y) = (1-x)^2 + 100(y-x^2)^2:----\n");
//res1.print("Extremum is found at:\n (x,y)   = ");
WriteLine("Extremum found at:");
WriteLine($"x = {res1[0]:f15} y = {res1[1]:f15}");
rosenbrock(res1).print("Value of the Rosenbrock valley function at found extremum =");
start.print("Initial guess (vector):\n");
WriteLine($"Number of calls = {ncalls}");

Func<vector,vector> himmelblau = delegate(vector x){
	ncalls++;
    vector fx = new vector(2);
    fx[0] = 2*(Pow(x[0],2) + x[1] -11)*(2*x[0]) + 2*(x[0] + Pow(x[1],2) -7);
    fx[1] = 2*(Pow(x[0],2) + x[1] -11) + 2*(x[0] + Pow(x[1],2) -7)*(2*x[1]);
    return fx;
};
start=new vector(5,3);
ncalls=0; var res2 = roots.newton(himmelblau, start);
WriteLine("\n----Testing my implementation on the Himmelblau function f(x,y) = (x^2+y-11)^2+(x+y^2-7)^2----\n");
//res2.print("Extremum is found at:\n (x,y)   = ");
WriteLine("Extremum found at:");
WriteLine($"x={res2[0]:f15} y={res2[1]:f15}");
himmelblau(res2).print("Value of the Himmelblau function at the found extremum =");
start.print("Initial guess (vector):\n");
WriteLine($"Number of calls={ncalls}");
WriteLine("\n\n\n");
WriteLine("Found coordinates, (x,y,0) for 3d-vizualisation (see .png files):");
WriteLine("\n\n\n");
WriteLine($"{res1[0]}  {res1[1]}    {0}");
WriteLine("\n\n\n");
WriteLine($"{res2[0]}  {res2[1]}    {0}");



}

} // main
