using System;
using static System.Console;
using static System.Math;

class main{
public static int Main(){

    vector x = new vector(1,2,3,4,6,9,10,13,15); // time in days
    vector y = new vector(117,100,88,72,53,29.5,25.2,15.2,11.1); // Activity in arbitrary units
    vector dy = new vector(y.size); // error of activity
    vector lny = new vector(y.size); // log of activity
    vector dlny = new vector(y.size); // error of log(y)


    for(int i=0 ; i<y.size ; i++){
        dy[i] = y[i] * 0.05; // assuming errors of 5%
        lny[i] = Math.Log(y[i]); // calculating ln(y)
        dlny[i] = y[i] / dy[i];
    }

    x.print("Time [days]:");
    y.print("Activity of ThX [relative units]:");
    dy.print("Error of the activity (assumed to be 5%):");

    Func<double,double>[] decay_func = new Func<double,double> [] {z => 1, z => -z};

    var (coeffs, cov_mat) = lslib.lsfit(decay_func, x, lny, dlny);

    coeffs.print("Fitting parameters:");
    cov_mat.print("Covariance matrix:");

    vector y_fit = new vector(y.size);
    WriteLine("Fitting function values [value, time]:\n\n\n");
    for(int j=0 ; j<y.size ; j++){
        y_fit[j] = Log(coeffs[0]) - coeffs[1]*x[j];
        WriteLine($"{x[j]}  {y_fit[j]}");
    }

return 0;
}

} // class main