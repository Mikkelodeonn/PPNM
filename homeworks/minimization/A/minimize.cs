using System; 
using static System.Math;

public class minimize{
public static matrix hessian(Func<vector,double> phi,vector x){
	matrix H=new matrix(x.size);
	double square_eps = Pow(2,-26);
	vector dphix=gradient(phi,x);
	for(int j=0;j<x.size;j++){
		double dx=Abs(x[j])*square_eps;
		x[j]+=dx;
		vector ddphi=gradient(phi,x)-dphix;
		for(int i=0;i<x.size;i++) H[i,j]=ddphi[i]/dx;
		x[j]-=dx;
	}
	//return H; 
	return (H+H.T)/2; // you think? 
}
public static vector gradient(Func<vector,double> phi, vector x){
vector dphi = new vector(x.size);
double square_eps = Pow(2,-26);
double phix = phi(x); 
for(int i=0;i<x.size;i++){
	double dx=Abs(x[i])*square_eps;
	x[i]+=dx;
	dphi[i]=(phi(x)-phix)/dx;
	x[i]-=dx;
}
return dphi;
}

public static vector newton(Func<vector,double> phi, vector x, double acc=1e-3){ // (objective function, starting point, accuracy goal)
do{ /* Newton's iterations */
	var dphi = gradient(phi,x);
	if(dphi.norm() < acc) break; /* job done */
	var H = hessian(phi,x);
	var (Q,R) = QRGS.decomp(H);   /* QR decomposition */
	var dx = QRGS.solve(Q,R,-dphi); /* Newton's step */
	double lambda=1,phix=phi(x);
    double lambda_min = 0.9, max_steps = 1000;
    int i = 0;
	do{ /* linesearch */
		if( phi(x + lambda * dx) < phix ) break; /* good step: accept */
		if( lambda < lambda_min ) break; /* accept anyway */
		lambda /= 2;
	}while(true);
	x += lambda*dx;
}while(true);
return x;
}//newton
} // minimize