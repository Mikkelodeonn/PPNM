using static System.Console;
using static System.Math;
using System;
public class main{
static public void Main(){
int n1=0, n2=0;
Func<double,double> f1 = x => {n1++; return 1/Sqrt(x);};        double a = integrate.clenshaw_curtis(f1, 0, 1);
Func<double,double> f2 = x => {n2++; return Log(x)/Sqrt(x);};   double b = integrate.clenshaw_curtis(f2, 0, 1);

WriteLine("\nVarious functions numerically integrated from 0 to 1 using Clenshaw-Curtis variable transformation:\n");
WriteLine("Function:                                1/sqrt(x)              ln(x)/sqrt(x)");
WriteLine($"Value found:                             {a}       {b}");
WriteLine("Exact value:                             2                      -4");
WriteLine($"Evaluations:                             {n1}                     {n2}");
WriteLine("Evalutions without Clenshaw-Curtis:      8572                   8604\n");
WriteLine("Conclusion: \nClenshaw-Curtis variable transformation provides a substantial speed-up for evaluating \nintegrals with integrable divergencies at the end-points of the intervals.");
} // Main
} // class main