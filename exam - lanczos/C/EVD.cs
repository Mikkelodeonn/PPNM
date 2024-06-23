using System;
using static System.Console;
using static System.Math;

public static class EVD{

public static void bigskip(){
    WriteLine("\n\n\n\n\n");
}
public static void timesJ(matrix A, int p, int q, double theta){
	double c=Cos(theta),s=Sin(theta);
	for(int i=0;i<A.size1;i++){
		double aip=A[i,p],aiq=A[i,q];
		A[i,p]=c*aip-s*aiq;
		A[i,q]=s*aip+c*aiq;
		}
} // timesJ (regular)
public static void Jtimes(matrix A, int p, int q, double theta){
	double c=Cos(theta),s=Sin(theta);
	for(int j=0;j<A.size1;j++){
		double apj=A[p,j],aqj=A[q,j];
		A[p,j]= c*apj+s*aqj;
		A[q,j]=-s*apj+c*aqj;
		}
} // Jtimes (regular)
public static (matrix, matrix) cyclic(matrix A){
if(A.size1 != A.size2) throw new Exception("Matrix has dumb dimensions");
int n = A.size1;
matrix V = matrix.id(n);
bool changed;
do{
	changed=false;
	for(int p=0;p<n-1;p++)
	for(int q=p+1;q<n;q++){
		double apq=A[p,q], app=A[p,p], aqq=A[q,q];
		double theta=0.5*Atan2(2*apq,aqq-app);
		double c=Cos(theta),s=Sin(theta);
		double new_app=c*c*app-2*s*c*apq+s*s*aqq;
		double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
		if(new_app!=app || new_aqq!=aqq) // do rotation
			{
			changed=true;
			timesJ(A,p,q, theta); // A←A*J 
			Jtimes(A,p,q,-theta); // A←JT*A 
			timesJ(V,p,q, theta); // V←V*J
			}
	}
}while(changed);
return (A,V);
} // cyclic (regular)
public static (double,matrix) hydrogen_s_wave(double rmax, double dr){
int n = (int)(rmax/dr)-1;
vector r = new vector(n);
for(int i=0;i<n;i++){
    r[i]=dr*(i+1);
    }
matrix H = new matrix(n,n);
for(int i=0;i<n-1;i++){
   H[i,i]  =-2*(-0.5/dr/dr);
   H[i,i+1]= 1*(-0.5/dr/dr);
   H[i+1,i]= 1*(-0.5/dr/dr);
  }
H[n-1,n-1]=-2*(-0.5/dr/dr);
for(int i=0;i<n;i++){
    H[i,i]+=-1/r[i];
    }
(matrix A, matrix V) = cyclic(H);
double E0 = double.PositiveInfinity;
for(int i=0;i<n;i++){
    if(A[i,i] < E0){
        E0 = A[i,i];
    }
}
return (E0,V);
} // hydrogen_s_wave

} // EVD