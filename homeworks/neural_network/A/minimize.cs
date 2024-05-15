using System; 
using static System.Math;
using static System.Console;

public class minimize{
public static matrix hessian(Func<vector,double> phi,vector x){
	matrix H=new matrix(x.size);
	//x.print("x:",file:Console.Error);
	double square_eps = Pow(2,-13);
	vector dphix=gradient(phi,x);
	for(int j=0;j<x.size;j++){
		double dx=Max(Abs(x[j]),1)*square_eps;
		x[j]+=dx;
		vector ddphi=gradient(phi,x)-dphix;
		for(int i=0;i<x.size;i++) H[i,j]=ddphi[i]/dx;
		x[j]-=dx;
	}
	return H;
}
public static vector gradient(Func<vector,double> phi, vector x){
vector dphi = new vector(x.size);
//x.print("x:",file:Console.Error);
double square_eps = Pow(2,-26);
double phix = phi(x); 
//Error.WriteLine($"phi(x): {phix}");
for(int i=0 ; i<x.size ; i++){
	double dx=Max(Abs(x[i]),1)*square_eps;
	x[i]+=dx;
	dphi[i]=(phi(x)-phix)/dx;
	x[i]-=dx;
}
return dphi;
}

public static vector newton(Func<vector,double> phi, vector x, double acc=1e-3){ // (objective function, starting point, accuracy goal)
int steps = 0, max_steps = 10000;
while(steps<max_steps){ 
	//x.print("x",file:Console.Error);
	steps++;
	var dphi = gradient(phi,x);
	//dphi.print("newton: grad:",file:Console.Error);
	if(dphi.norm() < acc) break; 
	var H = hessian(phi,x);
	//H.print("Hessian:");
	var (Q,R) = QRGS.decomp(H);  
	var dx = QRGS.solve(Q,R,-dphi); 
	double lambda=1, phix=phi(x);
    double lambda_min = Pow(2,-26);
	do{ 
		if( phi(x + lambda * dx) < phix ) break; 
		if( lambda <= lambda_min ) break; 
		lambda /= 2;
	}while(true);
//System.Console.Error.Write($"newton: lambda={lambda} lambda_min={lambda_min}\n");
	x += lambda*dx;
};
//System.Console.Error.Write($"newton: nsteps={steps}\n");
return x;
} // newton
} // minimize
