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
        lny[i] = Log(y[i]); // calculating ln(y)
        dlny[i] = dy[i] / y[i];
    }

    Func<double,double>[] decay_func = new Func<double,double> [] {z => 1, z => -z};

    var (coeffs, cov_mat) = lslib.lsfit(decay_func, x, lny, dlny);

    vector fit_err = new vector(cov_mat.size1);

    for(int i=0 ; i<cov_mat.size1 ; i++){
        fit_err[i] = Sqrt(cov_mat[i,i]);
    }

    WriteLine("Data and corresponding errors are the same as stated in exercise A.");
    cov_mat.print("\nCovariance matrix:");
    //coeffs.print("\nFitting parameters:\n");
    WriteLine("\nFound fitting parameters + errors obtained from the covariance matrix:");
    WriteLine($"a = {Round(coeffs[0],4)} +/- {Round(fit_err[0],4)}");
    WriteLine($"b = {Round(coeffs[1],4)} +/- {Round(fit_err[1],4)}");
    //fit_err.print("Error of fitting parameters:");
    WriteLine($"\nHalf-life of ThX: {Round(Log(2)/coeffs[1],3)} +/- {Round((Log(2)*Abs(fit_err[1]))/(coeffs[1]*coeffs[1]),4)} days");
    WriteLine("Table value: 3.6 days");

    WriteLine("\nThe error of the half-life of ThX is estimated using the variance formula with the errors obtained for the individual fitting parameters.");

return 0;
}

} // class main