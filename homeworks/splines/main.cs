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
        double s_lin = spline.linear(x,y,j);
        double s_lin_int = spline.linear_integrate(x,y,j);
        WriteLine($"{j} {s_lin}, {s_lin_int}"); 
    }

    WriteLine("\n\n");
    (double[] b, double[] c) = spline.quad_build(x,y);
    Write("b: ");
    for(int k=0;k<index;k++){Write($"{b[k]}   ");} 
    Write("\nc: ");
    for(int k=0;k<index;k++){Write($"{c[k]}   ");}
    WriteLine("\n\n");
    for(double h=0 ; h<=index-1 ; h+=0.125){
        double s_quad = spline.quad_eval(x,y,b,c,h);
        //double s_quad_int = spline.quad_integrate(x,y,j);
        //double ds = spline.quad_derivative();
        WriteLine($"{h} {s_quad}"); 
    }


return 0;
}

}