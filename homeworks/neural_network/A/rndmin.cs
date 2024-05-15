public class rndmin{
public static vector randomvec(System.Random rnd,vector a,vector b){
	vector x=new vector(a.size);
	for(int i=0;i<x.size;i++)
		x[i]=a[i]+(b[i]-a[i])*rnd.NextDouble();
	return x;
	}
public static vector go
(System.Func<vector,double> phi,vector a,vector b,int N=1000){
	var RND=new System.Random(42);
	vector x = (a+b)/2;
	vector xbest=x;
	double phibest=phi(x);
	for(int i=0;i<N;i++){
		x=randomvec(RND,a,b);
		double phix=phi(x);
		if(phix<phibest){
			xbest=x;
			phibest=phix;
			}
		}
	return xbest;
	}
}
