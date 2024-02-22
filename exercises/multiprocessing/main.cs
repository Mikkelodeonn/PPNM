
class main{

public class data{
	public int a,b;
	public double sum;
	} // class data

public static void harm(object obj){
	var arg = (data)obj;
	arg.sum=0;
	for(int i=arg.a;i<arg.b;i++){
		arg.sum+=1.0/i;
		} // forloop
	} // harm

public static int Main(string[] args){
int  nthreads = 1, nterms = (int)1e8;
foreach(var arg in args){
	var words = arg.Split(':');
	if(words[0]=="-threads") nthreads=int.Parse(words[1]);
	if(words[0]=="-terms") nterms=(int)float.Parse(words[1]);
	}

data[] data = new data[nthreads];
for(int i=0;i<nthreads;i++) {
	data[i] = new data();
	data[i].a = 1 + nterms/nthreads*i;
	data[i].b = 1 + nterms/nthreads*(i+1);
	}
data[data.Length-1].b=nterms+1;

var threads = new System.Threading.Thread[nthreads];
for(int i=0;i<nthreads;i++) {
	threads[i] = new System.Threading.Thread(harm); /* create a thread */
	threads[i].Start(data[i]); /* run it with params[i] as argument to "harm" */
	}

foreach(var thread in threads){
	thread.Join();
	}
int a = 0;
double total=0; foreach(var p in data){
	a++;
	total+=p.sum;
	}
System.Console.WriteLine($"\nNumber of threads: {a}");
return 0;
} // Main
} // class main
