using System;
using static System.Console;

class main{
	
	public int Main(){

	int i = 1; while(i + 1 > i) { i++; }
	WriteLine($"Maximum representable integer: {i}");
	
	int j = 1; while(j - 1 < j) { j--; }
	WriteLine($"Minimum representable integer: {j}");

	}

}
