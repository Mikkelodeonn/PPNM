using System;
using static System.Math;
public static class spline{
public static double linear(double[] x, double[] y, double z){
    int i = locate_index.binsearch(x,z);
    double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
    double dy=y[i+1]-y[i];
    return y[i]+dy/dx*(z-x[i]);
} // linear

public static double linear_integrate(double[] x, double[] y, double z){
    int i = locate_index.binsearch(x,z);
    double dx=x[i+1]-x[i]; 
    double dy=y[i+1]-y[i];
    double integral = y[i] * (z - x[0]) + dy/dx * (Pow((z - x[0]),2))/2;
    return integral;
} // linear_integral

public static (double[],double[]) quad_build(double[] x, double[] y){
    // vector x = xs.copy(); vector y = ys.copy();
    if(!(x.Length == y.Length)) throw new Exception("x & y have different dimensions.");
    double[] b = new double[x.Length];
    double[] c = new double[x.Length];
    double[] p = new double[x.Length];
    for(int i=0 ; i<x.Length-1 ; i++){
        double dx = x[i+1] - x[i]; if(!(dx>0)) throw new Exception("x not continuous...");
        double dy = y[i+1] - y[i];
        p[i] = dy/dx;
        c[0] = 0;
        c[i+1] = (1/dx) * (p[i+1] - p[i] - c[i]*dx);
        b[i] = p[i] - c[i]*dx;
    }
return (b,c);
} // quad_build

public static double quad_eval(double[] x, double[] y, double[] b, double[] c, double z){
    int index = locate_index.binsearch(x,z);
    double s = y[index] + b[index]*(z-x[index]) + c[index]*Pow((z-x[index]),2);
    return s;
} // quad_eval
} // class interpol