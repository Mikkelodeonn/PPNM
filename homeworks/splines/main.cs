using static System.Console;
using static System.Math;
static class main{
static int Main(){
    int index = 10;
    double[] x = new double[index];
    double[] y = new double[index];
    for(int i=0 ; i<index ; i++){
        x[i] = i;
        y[i] = Sin(x[i]);
        WriteLine($"{x[i]} {y[i]}");
    }
    WriteLine("\n\n");
    for(double j=0 ; j<=index-1 ; j+=0.25){
        double s = spline.linear(x,y,j);
        double s_int = spline.linear_integral(x,y,j);
        WriteLine($"{j} {s}, {s_int}"); 
    }
return 0;
}

}