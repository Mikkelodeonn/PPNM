using static System.Console;
using static System.Math;
static class main{
static int Main(){
    int index = 10;
    double[] x = new double[index];
    double[] y = new double[index];
    double[] y_int = new double[index];
    double[] dy = new double[index];
    //WriteLine("x sin(x)");
    for(int i=0 ; i<index ; i++){
        x[i] = i; 
        y[i] = Sin(x[i]); 
        WriteLine($"{x[i]} {y[i]}");
    }
    WriteLine("\n\n\n"); //x integral of sin(x)");
    for(int i=0 ; i<index ; i++){ 
        y_int[i] = 1 - Cos(x[i]); 
        WriteLine($"{x[i]} {y_int[i]}");
    }
    WriteLine("\n\n\n"); //x derivative of sin(x)
    for(int i=0 ; i<index ; i++){
        dy[i] = Cos(x[i]); 
        WriteLine($"{x[i]} {dy[i]}");
    }
    var (b,c) = spline.quad_build(x,y);
    WriteLine("\n\n\n0:Index 1:Linear spline");
    for(double j=0 ; j<=index-1 ; j+=1.0/16){
        double s_lin = spline.linear(x,y,j);
        WriteLine($"{j} {s_lin}"); 
    }
      WriteLine("\n\n\n0:Index 2:Linear integral");
    for(double j=0 ; j<=index-1 ; j+=1.0/16){
        double s_lin_integral = spline.linear_integrate(x,y,j);
        WriteLine($"{j} {s_lin_integral}"); 
    }
      WriteLine("\n\n\n0:Index 3:Quadratic spline");
    for(double j=0 ; j<=index-1 ; j+=1.0/16){
        double s_quad = spline.quad_eval(x,y,b,c,j);
        WriteLine($"{j} {s_quad}"); 
    }
      WriteLine("\n\n\n0:Index 4:Quadratic integral");
    for(double j=0 ; j<=index-1 ; j+=1.0/16){
        double s_quad_integral = spline.quad_integrate(x,y,b,c,j);
        WriteLine($"{j} {s_quad_integral}"); 
    }
      WriteLine("\n\n\n0:Index 5:Quadratic derivative");
    for(double j=0 ; j<=index-1 ; j+=1.0/16){
        double s_quad_derivative = spline.quad_derivative(x,b,c,j);
        WriteLine($"{j} {s_quad_derivative}"); 
    }
return 0;
}

}