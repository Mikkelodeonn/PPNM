using System;
static class locate_index{
public static int binsearch(genlist<double> x, double z)
	{/* locates the interval for z by bisection */ 
	if(!(x[0]<=z && z<=x[x.size-1])) throw new Exception("binsearch: bad z");
	int i=0, j=x.size-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}
}