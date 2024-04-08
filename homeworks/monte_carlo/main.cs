using static System.Math;
using static System.Console;
using System;

public class main{
static (double,double) plain(Func<vector,double> f, vector a, vector b, int N){
int dim = a.size; 
double V = 1; 
for(int i=0 ; i<dim ; i++){
    V *= b[i] - a[i];
    }
double sum = 0, sum2 = 0;
var x = new vector(dim);
var rnd = new Random();
for(int i=0 ; i<N ; i++){
    for(int k=0 ; k<dim ; k++){
        x[k] = a[k] + rnd.NextDouble() * (b[k] - a[k]);
        }
            double fx = f(x); 
            sum += fx; 
            sum2 += fx*fx;
    }
        double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
        var result=(mean*V,sigma*V/Sqrt(N));
        return result;
} // plain monte carlo integration

static double corput(int n, int b){
double q = 0;
double bk = (double)1/b;
while(n > 0){
    q += (n % b) * bk;
    n /= b;
    bk /= b;
}
return q;
} // corput (for quasi-random integrator)
public static void Main(string[] args){
int n = 1000;
if(args.Length > 0){
   n = (int)double.Parse(args[0]);
   }
double R = 1;
Func<vector,double> f = x =>{
	if(x.norm()<=R)return 1;
	else return 0;
	};
vector a = new vector(0.0, 0.0);
vector b = new vector(1.0, 1.0);
(double q, double e) = plain(f,a,b,n);
double exact = PI/4;
WriteLine($"{n} {q} {e} {Abs(q-exact)}");
} // Main
} // class main