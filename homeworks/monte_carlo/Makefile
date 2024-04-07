all: out.error.png out.integral.png

out.error.png: out.txt Makefile
	echo '\
	set terminal png background "white";\
	set out "$@";\
	set title "Plain montecarlo integration error";\
	set xlabel "number of sampling points";\
	set ylabel "error";\
	a=1; f(n) = a/sqrt(n);\
	fit f(x) "$<" using 1:4 via a;\
	plot \
	 "$<" u 1:3 with lines title "statistical estimate of the error"\
	,"$<" u 1:4 with linespoints title "actual error"\
	,f(x) with lines title "1/sqrt(n) fit to actual error"\
	'| gnuplot

out.integral.png: out.txt Makefile
	echo '\
	set terminal png background "white";\
	set out "$@";\
	set xlabel "number of points";\
	set ylabel "value of the integral";\
	plot \
	 "$<" with linespoints title "monte carlo integration"\
	,pi/4 with lines title "exact"\
	'| gnuplot

out.txt: main.exe
	>$@
	for N in $$(seq 200 200 10000);\
	do echo $$N; mono $< $$N >> $@;\
	done
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs vector.dll 
	mcs -target:exe -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

clean: 
	$(RM) *.exe *.dll *.log [Oo]ut*