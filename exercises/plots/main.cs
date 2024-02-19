using static System.Console;

class main{

public static int Main(){
	for(double x=-3;x<=3;x+=1.0/8){
		WriteLine($"{x} {sfuns.erf(x)}");
		}
	WriteLine("\n");
	for(double y=1;y<=4;y+=1.0/8){
		WriteLine($"{y} {sfuns.gamma(y)}");
		}
	WriteLine("\n");
	for(double z=1;z<=4;z+=1.0/8){
		WriteLine($"{z} {sfuns.lngamma(z)}");
		}
return 0;
}
}
