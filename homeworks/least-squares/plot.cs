    
static class fitplot{

public static void plot(){
    vector x = new vector(1,2,3,4,6,9,10,13,15); // time in days
    vector y_fit = new vector(x.size);
    for(int j=0 ; j<y.size ; j++){
        y_fit[j] = Log(4.96) - 0.171*x[j];
        WriteLine($"{x[j]}  {y_fit[j]}");
    } 
}
}