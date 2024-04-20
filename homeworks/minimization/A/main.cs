using System; 
using static System.Math;
using static System.Console;
public static class main{
public static void Main(){
int i=0 , j=0;
Func<vector,double> rosenbrock = x => { // x -> x[0], y -> x[1]
    i++;
    return Pow((1 - x[0]),2) + 100 * Pow((x[1] - Pow(x[0],2)),2);
};
Func<vector,double> himmelblau = x => {
    j++;
    return Pow((Pow(x[0],2) + x[1] - 11),2) + Pow((x[0] + Pow(x[1],2) - 7),2);
};

vector x0 = new vector(0,0); // initial guess

var rosenbrock_minima = minimize.newton(rosenbrock,x0);

rosenbrock_minima.print("Found minimum of the Rosenbrock function: \n");
WriteLine($"Steps used {i}");

} // Main
} // main