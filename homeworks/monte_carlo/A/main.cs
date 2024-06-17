using static System.Math;
using static System.Console;
using System;

public class main{
static double corput(int n, int b){
double q = 0;
double bk = (double)1/b;
while(n > 0){
    q += (n % b) * bk;
    n /= b;
    bk /= b;
}
return q;
} // corput sequence

static vector halton(int n, int d){
vector x = new vector(d);
int[] Base = {2 ,3 ,5 ,7 ,11 ,13 ,17 ,19 ,23 ,29 ,31 ,37 ,41 ,43 ,47 ,53 ,59 ,61, 67};
int d_max = Base.Length;
if(d > d_max){
    throw new Exception("Bad dimension...");
    }
for(int i=0 ; i<d ; i++){
    x[i] = corput(n, Base[i]);
}
return x;
} // halton sequence


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

static (double,double) quasi_halton(Func<vector,double> f, vector a, vector b, int N){
int dim = a.size; 
double V = 1; 
for(int i=0 ; i<dim ; i++){
    V *= b[i] - a[i];
    }
double sum = 0, sum2 = 0;
var x = new vector(dim);
for(int i=0 ; i<N ; i++){
    var rnd = halton(i, dim);
    for(int k=0 ; k<dim ; k++){
        x[k] = a[k] + rnd[k] * (b[k] - a[k]);
        }
            double fx = f(x); 
            sum += fx; 
            sum2 += fx*fx;
    }
        double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
        var result=(mean*V,sigma*V/Sqrt(N));
        return result;
}

public static void Main(string[] args){
int n = 1000;
if(args.Length > 0){
   n = (int)double.Parse(args[0]);
   }
//double R = 1;
Func<vector,double> f = z =>{
	return 1.0/(1.0 - Cos(z[0])*Cos(z[1])*Cos(z[2]))/(PI*PI*PI);
	};
vector a = new vector(0.0, 0.0, 0.0);
vector b = new vector(PI, PI, PI);
(double q, double e) = plain(f,a,b,n);
double exact = 1.3932039296856768591842462603255;
WriteLine($"{n} {q} {e} {Abs(q-exact)}"); 
} // Main
} // class main