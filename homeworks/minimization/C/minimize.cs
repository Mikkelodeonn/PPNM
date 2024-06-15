using System;
using static System.Math;
using static System.Console;

public class minimize{
    public static matrix hessian(Func<vector, double> phi, vector x){
        matrix H = new matrix(x.size);
        double eps = Pow(2, -26);
        vector dphix = gradient(phi, x);
        for(int j = 0; j < x.size; j++){
            double dx = Abs(x[j]) * eps;
            x[j] += dx;
            vector dphix_plus = gradient(phi, x);
            x[j] -= 2 * dx;
            vector dphix_minus = gradient(phi, x);
            vector ddphi = (dphix_plus - dphix_minus) / (2 * dx);
            for(int i = 0; i < x.size; i++){H[i, j] = ddphi[i];}
            x[j] += dx;
        }
        return (H + H.T) / 2; 
    }
    public static vector gradient(Func<vector, double> phi, vector x){
        vector dphi = new vector(x.size);
        double eps = Pow(2, -26);
        for(int i = 0; i < x.size; i++){
            double dx = Abs(x[i]) * eps;
            x[i] += dx;
            double phix_plus = phi(x);
            x[i] -= 2 * dx;
            double phix_minus = phi(x);
            dphi[i] = (phix_plus - phix_minus) / (2 * dx);
            x[i] += dx;
        }
        return dphi;
    }

    public static vector newton(Func<vector, double> phi, vector x, double acc = 1e-3){ // (objective function, starting point, accuracy goal)
        do{
            var dphi = gradient(phi, x);
            if(dphi.norm() < acc) break;
            var H = hessian(phi, x);
            var (Q, R) = QRGS.decomp(H);
            var dx = QRGS.solve(Q, R, -dphi);
            double lambda = 1, phix = phi(x);
            double lambda_min = 1.0 / 1024;
            do{
                if(phi(x + lambda * dx) < phix) break;
                if(lambda < lambda_min) break;
                lambda /= 2;
            } while(true);
            x += lambda * dx;
        } while(true);
        return x;
    }
} // minimize
