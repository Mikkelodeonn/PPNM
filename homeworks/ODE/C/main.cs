using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class main{

public static void Main(){

Func<double,vector,vector> three_body_problem = delegate(double t, vector y){ // implementation of the 3 body problem (m1=m2=m3=G=1)
int n = y.size;
vector dydt = new vector(n);
for(int i=0 ; i<n/4 ; i++){ // n/4 -> we wish to use 4 distinct values for each mass (x,y,vx,vy)
  vector ri = new vector(y[4*i], y[4*i+1]);
  vector dvdt = new vector(2);
  for(int j=0 ; j<n/4 ; j++){
    if((j!=i)){
      vector rj = new vector(y[4*j], y[4*j+1]);
      dvdt += (rj-ri)/(Pow((rj-ri).norm(), 3));
    }
  }
  dydt[4*i] = y[4*i+2];
  dydt[4*i+1] = y[4*i+3];
	dydt[4*i+2] = dvdt[0];
	dydt[4*i+3] = dvdt[1];
}
return dydt;
};

double start=0, stop=2*6.3259; 
double x1, x2, x3, y1, y2, y3, vx1, vx2, vx3, vy1, vy2, vy3;
x1=-0.97000436; y1=0.24308753; x2=-x1; y2=-y1; x3=0; y3=x3;
vx1=0.466203685; vy1=0.43236573; vx2=vx1; vy2=vy1; vx3=-2*vx1; vy3=-2*vy1;
vector ystart= new vector(x1,y1,vx1,vy1,x2,y2,vx2,vy2,x3,y3,vx3,vy3);
var (ts, ys) = RK.driver(three_body_problem, (start,stop), ystart);

WriteLine("t  x1  y1  vx1 vy1 x2  y2  vx2 vy2 x3  y3  vx3 vy3");
for(int i=0 ; i<ts.size ; i++){
  WriteLine($"{ts[i]}  {ys[i][0]}  {ys[i][1]}  {ys[i][2]} {ys[i][3]}  {ys[i][4]}  {ys[i][5]} {ys[i][6]}  {ys[i][7]}  {ys[i][8]} {ys[i][9]}  {ys[i][10]}  {ys[i][11]}");
}
} // Main
} // class main

