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

Func<vector,double> breit_wigner = x =>{ // x -> (E,m,G,A)
    double E = x[0], m = x[1], G = x[2], A = x[3];
    return A/(Pow((E-m),2) + (G*G)/4);
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
        sum += Pow((breit_wigner(args)-y),2)/dy/dy;
    }
    return sum;
}; 

vector start=new vector(100,10,10); 
double mass, Gamma, Const; 
vector res = minimize.newton(dev_func, start, acc:1e-4); 
mass=res[0]; Gamma=res[1]; Const=res[2]; 
WriteLine("---------- Fit of data from Higgs Boson Discovery using Newton's method with numerical gradient/Hessian matrix & back-tracking linesearch -----------");
WriteLine("The data was fitted to the Breit-Wigner function and the fit was constructed by minimizing the deviation function (both are given in the exercise).");
WriteLine($"# of calls                       = {ncalls}"); 
WriteLine($"Found mass                       = {mass} GeV/c^2");
WriteLine("Exact mass (wikipedia)           = 125.3 +/- 0.6 GeV/c^2");
WriteLine($"Experimental width (Gamma)       = {Gamma}"); 
WriteLine($"Initial guess (m G A)            = ({start[0]} {start[1]} {start[2]})");
WriteLine("\n\n\n");
for(double e=energy[0] ; e<=energy[energy.size-1] ; e+=1.0/8){
    vector args = new vector(e, mass, Gamma, Const);
	WriteLine($"{e} {breit_wigner(args)}");
	}
} // Main
} // class main