using System;
using static System.Console;
using System.Diagnostics;
class main{
public static int Main(){

for(int n=10 ; n<=300 ; n+=10){
    var A = random.CreateRandomMatrix(n,n);

    var timer = new Stopwatch();

	timer.Start();
	var (Q,R) = QRGS.decomp(A);
	timer.Stop();

	var time = timer.ElapsedTicks; 

	WriteLine($"{n} {time}");
}
return 0;
} // Main
} // class main