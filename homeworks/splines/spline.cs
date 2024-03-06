using System;
using static System.Math;
public static class interpol{
public static double linear(double[] x, double[] y, double z){
    int i = locate_index.binsearch(x,z);
    double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
    double dy=y[i+1]-y[i];
    return y[i]+dy/dx*(z-x[i]);
} // linear

public static double linear_integral(double[] x, double[] y, double z){
    int i = locate_index.binsearch(x,z);
    double dx=x[i+1]-x[i]; if(!(dx>0));
    double dy=y[i+1]-y[i];
    double integral = y[i] * (z - x[0]) + dy/dx * (Pow((z - x[0]),2))/2;
    return integral;
} // linear_integral
} // class interpol