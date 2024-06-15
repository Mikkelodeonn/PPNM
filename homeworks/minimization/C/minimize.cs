using System; 
using static System.Math;
using static System.Console;

public class minimize{

public static matrix hessian(Func<vector,double> phi,vector x){ // implementation of the central difference approx. of the Hessian is needed.
	matrix H=new matrix(x.size);
	double square_eps = Pow(2,-26);
	vector dphix=gradient(phi,x);
	for(int j=0;j<x.size;j++){
		double dx=Abs(x[j])*square_eps;
		x[j]+=dx;
		vector grad_plus = gradient(phi,x);
		x[j]-=2*dx;
		vector grad_minus = gradient(phi,x);
		vector ddphi=grad_plus-grad_minus;
		for(int i=0;i<x.size;i++){H[i,j]=ddphi[i]/(dx*dx);}
		x[j]+=dx;
	}
	//return H; 
	return (H+H.T)/2; 
}
public static vector gradient(Func<vector,double> phi, vector x){ // central difference gradient
vector dphi = new vector(x.size);
double square_eps = Pow(2,-26);
double phix = phi(x); 
for(int i=0;i<x.size;i++){
	double dx=Abs(x[i])*square_eps;
	x[i]+=dx;
	double phi_plus = phi(x);
	x[i]-=2*dx;
	double phi_minus = phi(x);
	dphi[i]=(phi_plus-phi_minus)/(2*dx);
	x[i]+=dx;
}
return dphi;
}

public static vector newton(Func<vector,double> phi, vector x, double acc=1e-3){ // (objective function, starting point, accuracy goal)
do{ 
	var dphi = gradient(phi,x);
	if(dphi.norm() < acc) break; 
	var H = hessian(phi,x);
	var (Q,R) = QRGS.decomp(H);  
	var dx = QRGS.solve(Q,R,-dphi); 
	double lambda=1,phix=phi(x);
    double lambda_min = 1.0/1024;
	do{ 
		if( phi(x + lambda * dx) < phix ) break; 
		if( lambda < lambda_min ) break; 
		lambda /= 2;
	}while(true);
	x += lambda*dx;
}while(true);
return x;
} // newton
} // minimize