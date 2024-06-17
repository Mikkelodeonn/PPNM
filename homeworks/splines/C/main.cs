using static System.Console;
using static System.Math;
static class main{
static int Main(){
    int steps = 32;
    double h=0, k=7;
    double[] x = new double[steps];
    double[] y = new double[steps];
    double[] y_int = new double[steps];
    double[] dy = new double[steps];
    //WriteLine("x sin(x)");
    for(int i=0 ; i<steps ; i++){
        x[i] = h+i*(k-h)/(steps-1);
        y[i] = Sin(x[i]); 
        WriteLine($"{x[i]} {y[i]}");
    }
    WriteLine("\n\n\n"); //x integral of sin(x)");
    for(int i=0 ; i<steps ; i++){ 
        y_int[i] = 1 - Cos(x[i]); 
        WriteLine($"{x[i]} {y_int[i]}");
    }
    WriteLine("\n\n\n"); //x derivative of sin(x)
    for(int i=0 ; i<steps ; i++){
        dy[i] = Cos(x[i]); 
        WriteLine($"{x[i]} {dy[i]}");
    }

    double n = x[x.Length-1];

    var (b,c,d) = spline.cubic_build(x,y);
    WriteLine("\n\n\n"); // quadratic spline
    for(double j=0.0 ; j<=n ; j+=1.0/32){
        double s_cube = spline.cubic_eval(x,y,b,c,d,j);
        WriteLine($"{j} {s_cube}"); 
    }
    WriteLine("\n\n\n"); // quadratic integral
    for(double j=0.0 ; j<=n ; j+=1.0/32){
        double s_cube_int = spline.cubic_integral(x,y,b,c,d,j);
        WriteLine($"{j} {s_cube_int}"); 
    }
    WriteLine("\n\n\n"); // quadratic derivative
    for(double j=0.0 ; j<=n ; j+=1.0/32){
        double s_cube_derivative = spline.cubic_derivative(x,b,c,d,j);
        WriteLine($"{j} {s_cube_derivative}"); 
    }
return 0;
}

}