using static System.Math;
static class input{
public static (double[], double[]) make_table(int index){
    double[] x = new double[index];
    double[] y = new double[index];
    for(int i ; i<index ; i++){
        x[i] = i;
        y[i] = Sin(x[i]);
    }
    return (x,y);
} // make_table
} // input