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
    double sum=0,dx,dy;
	for(int j=0 ; j<i ; j++){
		dx = x[j+1]-x[j];
        dy = y[j+1]-y[j];
        double p = dy/dx;
		sum += dx * (y[j] + dx*p/2);
		}
	dx=z-x[i];
    dy=y[i+1]-y[i];
    double p_i = dy/dx;
    double s_int = sum + dx * (y[i] + dx*p_i);
return s_int;
} // linear_integral

public static (double[],double[]) quad_build(double[] x, double[] y){
    // vector x = xs.copy(); vector y = ys.copy();
    if(!(x.Length == y.Length)) throw new Exception("x & y have different dimensions.");
    int n = x.Length;
    double[] b = new double[n-1];
    double[] c = new double[n-1];
    double[] p = new double[n-1];
    double[] dx = new double[n-1];
    c[0] = 0;
    for(int i=0 ; i<n-1 ; i++){
        dx[i] = x[i+1] - x[i]; // if(!(dx[i]>0)) throw new Exception("x not continuous...");
        double dy = y[i+1] - y[i];
        p[i] = dy/dx[i];
        }
    for(int i=0 ; i<n-2 ; i++){ // up recursion
		c[i+1]=(p[i+1]-p[i]-c[i]*dx[i])/dx[i+1];
        }
	c[n-2]/=2;                                 
	for(int i=n-3 ; i>=0 ; i--){ // down recursion
		c[i]=(p[i+1]-p[i]-c[i+1]*dx[i+1])/dx[i];
        }
	for(int i=0 ; i<n-1 ; i++){
		b[i]=p[i]-c[i]*dx[i];
        }
return (b,c);
} // quad_build

public static double quad_eval(double[] x, double[] y, double[] b, double[] c, double z){
    int i = locate_index.binsearch(x,z);
    double s = y[i] + b[i]*(z-x[i]) + c[i]*Pow((z-x[i]),2);
return s;
} // quad_eval

public static double quad_derivative(double[] x, double[] b, double[] c, double z){
    int i = locate_index.binsearch(x,z);
    double ds_dx = b[i] + 2*c[i]*(z-x[i]);
return ds_dx;
} // quad_derivative

public static double quad_integrate(double[] x, double[] y, double[] b, double[] c, double z){
    int i = locate_index.binsearch(x,z);
    double sum=0,dx;
	for(int j=0 ; j<i ; j++){
		dx=x[j+1]-x[j];
		sum += dx*(y[j]+dx*(b[j]/2+dx*c[j]/3));
		}
	dx=z-x[i];
    double s_int = sum + dx *(y[i]+dx*(b[i]/2+dx*c[i]/3));
	return s_int;
} // quad_integrate
} // class interpol