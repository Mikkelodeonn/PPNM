using System;
using static System.Math;
public static class spline{
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

public static double quad_build(vector xs, vector ys){
    vector x = xs.copy(); vector y = ys.copy();
    if(x.size != y.size);{ throw new Exception("x & y have different dimensions.");}
    vector b = new vector(x.size);
    vector c = new vector(x.size);
    vector p = new vector(x.size);
    for(int i=0 ; i<x.size-1 ; i++){
        double dx = xs[i+1] - xs[i]; double dy = ys[i+1] - ys[i];
        if(!(dx>0));{ throw new Exception("x not continuous...");}
        p[i] = dy/dx;
        c[0] = 0;
        c[i+1] = (1/dx) * (p[i+1] - p[i] - c[i]*dx);
        b[i] = p[i] - c[i]*dx; 
    }
return (b,c);
} // quad_build
} // class interpol