using System;
using System.Collections.Generic;
using static System.Math;
public static class RK{
public static (vector, vector) rkstep4(
    Func<double,vector,vector> f, double x, vector y, double h){

vector k0 = f(x,y);
vector k1 = f(x+h/2, y+(h*k0)/2);
vector k2 = f(x+h/2, y+(h*k1)/2);
vector k3 = f(x+h, y+h*k2);
vector k = k0/6 + k1/3 + k2/3 + k3/6;

vector yh = y + k*h;
vector dy = (k-k0)*h;
return (yh, dy);
} // rkstep4
public static (genlist<double>,genlist<vector>) driver(
	Func<double,vector,vector> F, (double,double) interval, vector ystart, double h=0.125, double acc=0.01,double eps=0.01){

var (a,b)=interval; double x=a; vector y=ystart.copy();
var xlist=new genlist<double>(); xlist.add(x);
var ylist=new genlist<vector>(); ylist.add(y);
do{
        if(x>=b){
            return (xlist,ylist);
            } 
        if(x+h>b){
            h=b-x;
            }
        var (yh,δy) = rkstep4(F,x,y,h);
        double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
        double err = δy.norm();
        if(err<=tol){ 
		x+=h; y=yh;
		xlist.add(x);
		ylist.add(y);
		}
	h *= Min( Pow(tol/err,0.25)*0.95 , 2); 
        }while(true);
}//driver

public static Func<double,vector> linear_interpolant(genlist<double> x,genlist<vector> y)
{
	Func<double,vector> interpolant = delegate(double z){
		int i=locate_index.binsearch(x,z);
		double Δx=x[i+1]-x[i];
		vector Δy=y[i+1]-y[i];
		return y[i]+Δy/Δx*(z-x[i]);
	};
	return interpolant;
} // linear_interpolant
public static Func<double,vector> ode_interpolant // returns the linear interpolant of the solution of the ODE driver.
(Func<double,vector,vector> f,(double,double)interval,vector y,double acc=0.01,double eps=0.01,double hstart=0.01 )
{
	var (xlist,ylist) = driver(f,interval,y,acc,eps,hstart);
	return linear_interpolant(xlist,ylist);
} // ode_interpolant
} // class RK