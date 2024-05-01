using System;
using static System.Console;
using static System.Math;
public class main{
static int ncalls = 0;
public static void Main(){
var energy = new genlist<double>();
var signal = new genlist<double>();
var error  = new genlist<double>();
var separators = new char[] {' ','\t'};
var options = StringSplitOptions.RemoveEmptyEntries;
do{
        string line=Console.In.ReadLine();
        if(line==null)break;
        string[] words=line.Split(separators,options);
        energy.add(double.Parse(words[0]));
        signal.add(double.Parse(words[1]));
        error .add(double.Parse(words[2]));
}while(true);

Func<vector,double> breitwigner = x =>{ // x -> (E,m,G)
    double E = x[0]; double m = x[1]; double G = x[2];
    return 1/(Pow((E-m),2) + Pow(G/2,2));
};

Func<vector,double> dev_func = x => { // x -> (m,G,A)
    ncalls++;
    double sum = 0;
    double m = x[0], G = x[1], A = x[2];
    for(int i=0 ; i<energy.size ; i++){
        double e = energy[i];
        double y = signal[i];
        double dy = error[i];
        vector args = new vector(e,m,G);
        sum += Pow((A*breitwigner(args) - y),2)/(dy*dy);
    }
    return sum;
};

vector start=new vector(123,3,6);
double mass, Gamma, Const;
ncalls=0; 
vector res = minimize.newton(dev_func, start, acc:1e-3);
mass=res[0]; Gamma=res[1]; Const=res[2];
Error.WriteLine($"ncalls        = {ncalls}\n");
Error.WriteLine($"mass          = {mass}\n");
Error.WriteLine($"Gamma         = {Gamma}\n");
Error.WriteLine($"Sqrt(chi^2/n) = {Sqrt(dev_func(res)/energy.size)}\n");

for(double e=energy[0] ; e<=energy[energy.size-1] ; e+=1.0/16){
    vector args = new vector(e,mass,Gamma);
	WriteLine($"{e} {Const*breitwigner(args)}");
	}
} // Main
} // class main