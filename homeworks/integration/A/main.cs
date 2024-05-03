using static System.Console;
using static System.Math;
using System;

public static class main{

public static int Main(){
int n1=0, n2=0, n3=0, n4=0;
Func<double,double> func_1 = x => {n1++; return Sqrt(x);};                   double a = integrate.RAI(func_1, 0, 1);
Func<double,double> func_2 = x => {n2++; return 1/(Sqrt(x));};               double b = integrate.RAI(func_2, 0, 1);
Func<double,double> func_3 = x => {n3++; return 4 * Sqrt(1 - Pow(x,2));};    double c = integrate.RAI(func_3, 0, 1);
Func<double,double> func_4 = x => {n4++; return Log(x) / Sqrt(x);};          double d = integrate.RAI(func_4, 0, 1);

WriteLine("Various functions numerically integrated from 0 to 1:");
WriteLine($"                  sqrt(x):          1/sqrt(x):           4sqrt(1-x**2):         ln(x)/sqrt(x):  \n");
WriteLine($"Values found:     {Round(a,5)}           {Round(b,5)}              {Round(c,5)}                 {Round(d,5)}\n");
WriteLine("Values given:     2/3               2                    pi                      -4\n");
WriteLine($"Evaluations:      {n1}                {n2}                 {n3}                      {n4}");
WriteLine("\n\n\n");

for(double i=-3.0 ; i<3.0 ; i+=1.0/32){
    double erf = integrate.erf(i);
    WriteLine($"{i} {erf}");
}

WriteLine("\n\n\n");
WriteLine("-3   -0.999977910");
WriteLine("-2.5 -0.999593048");
WriteLine("-2   -0.995322265");
WriteLine("-1.5 -0.966105146");
WriteLine("-1   -0.842700793");
WriteLine("-0.5 -0.520499878");
WriteLine("0    0");
WriteLine("0.5  0.520499878");
WriteLine("1    0.842700793");
WriteLine("1.5  0.966105146");
WriteLine("2    0.995322265");
WriteLine("2.5  0.999593048");
WriteLine("3    0.999977910");
return 0;
}

} // class main