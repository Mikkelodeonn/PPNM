using System;
using static System.Console;
using static System.Math;
using System.Globalization;
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
        energy.add(double.Parse(words[0], CultureInfo.InvariantCulture));
        signal.add(double.Parse(words[1], CultureInfo.InvariantCulture));
        error .add(double.Parse(words[2], CultureInfo.InvariantCulture));
}while(true);

Func<vector,double> breitwigner = x =>{ // x -> (E,m,G,A)
    double E = x[0], m = x[1], G = x[2], A = x[3];
    return A/((E-m)*(E-m) + (G*G)/4);
};

Func<vector,double> dev_func = x => { // x -> (m,G,A)
    ncalls++;
    double sum = 0; vector args;
    double m = x[0], G = x[1], A = x[2];
    for(int i=0 ; i<energy.size ; i++){
        double e = energy[i];
        double y = signal[i];
        double dy = error[i];
        args = new vector(e,m,G,A);
        double bw = breitwigner(args);
        sum += ((bw-y)*(bw-y))/(dy*dy);
    }
    return sum;
}; 

vector start=new vector(123,3,6); 
double mass, Gamma, Const; 
vector res = minimize.newton(dev_func, start, acc:1e-3); 
//res.print("res:",file:Console.Error); 
mass=res[0]; Gamma=res[1]; Const=res[2]; 
Error.WriteLine($"ncalls        = {ncalls}\n"); 
Error.WriteLine($"mass          = {mass}\n"); 
Error.WriteLine($"Gamma         = {Gamma}\n"); 
Error.WriteLine($"Sqrt(chi^2/n) = {Sqrt(dev_func(res)/energy.size)}\n"); 

for(double e=energy[0] ; e<=energy[energy.size-1] ; e+=1.0/16){
    vector args = new vector(e,mass,Gamma,Const);
    // args.print("args:", file:Console.Error);
	WriteLine($"{e} {breitwigner(args)}");
	}
} // Main
} // class main