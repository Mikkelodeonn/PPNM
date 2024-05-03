using System;
using static System.Math;
public static class integrate{

public static double RAI(Func<double,double> f, double a, double b, double acc=0.001, double eps=0.001, double f2=double.NaN, double f3=double.NaN){ // Recursive Adaptive Integrator
    double f1 = f(a + (b-a) / 6);
    double f4 = f(a + 5 * (b-a) / 6);
    if( double.IsNaN(f2) ){
        f2 = f(a + 2 * (b-a) / 6);
        f3 = f(a + 4 * (b-a) / 6);
    }
    double Q = ((2 * f1 + f2 + f3 + 2 * f4) * (b-a)) / 6;
    double q = ((f1 + f2 + f3 + f4) * (b-a)) / 4;

    double tolerance = acc + eps * System.Math.Abs(Q);
    double error = System.Math.Abs(Q - q);

    if( error < tolerance){
        return Q;
    }
    else{
        double Q1 = RAI(f, a, (a+b)/2, acc/System.Math.Sqrt(2.0), eps, f1, f2);
        double Q2 = RAI(f, (a+b)/2, b, acc/System.Math.Sqrt(2.0), eps, f3, f4);
        return Q1+Q2;
    }
} // RAI (Recursive Adaptive Integrator)
public static double erf(double z){
    Func<double,double> f = x => Exp(-x*x);
    Func<double,double> F = t => f(z + (1 - t) /t) /t /t;
    if( z < 0 ){return (-1*erf(-z));}
    if( 0 <= z | z <= 1){return ((2/Sqrt(PI)) * RAI(f, 0, z));}
    if( 1 < z){return (1 - ((2/Sqrt(PI)) * RAI(F, 0, 1)));}
return 0.0;
} // erf (error function)
public static double clenshaw_curtis
(Func<double,double> f,double a,double b,double acc=1e-3,double eps=1e-3)
{
Func<double,double> F = t => f((a+b)/2+(b-a)/2*Cos(t))*Sin(t)*(b-a)/2;
return RAI(F,0,PI,acc,eps);
} // clenshaw_curtis (Adaptive integrator based on Clenshaw-Curtis variable transformation)
} // class integrate