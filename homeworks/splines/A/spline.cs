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
        //c[i+1] = (1/dx) * (p[i+1] - p[i] - c[i]*dx);
        //b[i] = p[i] - c[i]*dx;
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

public static (double[],double[],double[]) cubic_build(double[] xs, double[] ys){
int n = xs.Length;
double [] x = new double[n]; double [] y = new double[n]; 
double[] b = new double[n]; double[] c = new double[n-1]; double[] d = new double[n-1];
for(int i=0 ; i<n ; i++){
    x[i]=xs[i];
    y[i]=ys[i];
    }
double[] h = new double[n-1]; double[] p = new double[n-1]; 
double[] D = new double[n]; double[] Q = new double[n-1]; double[] B = new double[n]; // building the tridiagonal matrix
for(int i=0 ; i<n-1 ; i++){
    h[i] = x[i+1] - x[i];
    }
for(int i=0 ; i<n-1 ; i++){
    p[i] = (y[i+1] - y[i])/h[i];
    }
D[0] = 2; Q[0] = 1; B[0] = 3*p[0]; 
D[n-1] = 2; B[n-1] = 3*p[n-2]; // gauss elimination
for(int i=0 ; i<n-2 ; i++){
    D[i+1] = 2*h[i]/h[i+1] + 2; 
    Q[i+1] = h[i]/h[i+1];
    B[i+1] = 3*(p[i] + p[i+1] * h[i]/h[i+1]);
    }
for(int i=1 ; i<n ; i++){
    D[i] -= Q[i-1]/D[i-1]; 
    B[i] -= B[i-1]/D[i-1];
    }
b[n-1] = B[n-1]/D[n-1]; // back-substitution
for(int i=n-2 ; i>=0 ; i--){
    b[i] = (B[i]-Q[i]*b[i+1])/D[i];
    }
for(int i=0 ; i<n-1 ; i++){
    c[i] = (-2*b[i]-b[i+1]+3*p[i])/h[i]; 
    d[i] = (b[i]+b[i+1]-2*p[i])/h[i]/h[i];
    }
return (b,c,d);
} // cubic_build

public static double cubic_eval(double[] x, double[] y, double[] b, double[] c, double[] d, double z){
int i = locate_index.binsearch(x,z);
double dx = z-x[i];
return y[i] + dx * (b[i] + dx * (c[i] + dx * d[i]));
} // qubic_eval

public static double cubic_derivative(double[] x, double[] b, double[] c, double[] d, double z){
int i = locate_index.binsearch(x,z);
double dx = z-x[i];
return b[i] + dx * (2 * c[i] + dx * 3 * d[i]);
} // cubic_derivative

public static double cubic_integral(double[] x, double [] y, double[] b, double[] c, double[] d, double z){
int i = locate_index.binsearch(x,z);
double dx, sum=0;
for(int j=0 ; j<i ; j++){
    dx = x[j+1] - x[j];
    sum += dx * (y[j] + dx * (b[j]/2 + dx * (c[j]/3 + dx * d[j]/4)));
}
dx = z - x[i];
sum += dx * (y[i] + dx * (b[i]/2 + dx * (c[i]/3 + dx * d[i]/4)));
return sum;
} // cubic_integral
} // class interpol