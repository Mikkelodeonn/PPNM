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

    var (b,c) = spline.quad_build(x,y);
    WriteLine("\n\n\n0:Index 1:Linear spline");
    for(double j=0 ; j<=n ; j+=1.0/32){
        double s_lin = spline.linear(x,y,j);
        WriteLine($"{j} {s_lin}"); 
    }
      WriteLine("\n\n\n0:Index 2:Linear integral");
    for(double j=0 ; j<=n ; j+=1.0/32){
        double s_lin_integral = spline.linear_integrate(x,y,j);
        WriteLine($"{j} {s_lin_integral}"); 
    }
      WriteLine("\n\n\n0:Index 3:Quadratic spline");
    for(double j=0.0 ; j<=n ; j+=1.0/32){
        double s_quad = spline.quad_eval(x,y,b,c,j);
        WriteLine($"{j} {s_quad}"); 
    }
      WriteLine("\n\n\n0:Index 4:Quadratic integral");
    for(double j=0.0 ; j<=n ; j+=1.0/32){
        double s_quad_integral = spline.quad_integrate(x,y,b,c,j);
        WriteLine($"{j} {s_quad_integral}"); 
    }
      WriteLine("\n\n\n0:Index 5:Quadratic derivative");
    for(double j=0.0 ; j<=n ; j+=1.0/32){
        double s_quad_derivative = spline.quad_derivative(x,b,c,j);
        WriteLine($"{j} {s_quad_derivative}"); 
    }
return 0;
}

}