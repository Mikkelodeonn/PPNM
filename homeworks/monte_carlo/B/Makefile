all: Out.error.png Out.integral.png

Out.error.png: Out.txt Makefile
	echo '\
	set terminal png background "white";\
	set out "$@";\
	set title "Quasi-random MC integration error";\
	set xlabel "N[number of sampling points]";\
	set ylabel "error";\
	a=1; f(n) = a/n;\
	fit f(x) "$<" using 1:4 via a;\
	plot \
	"$<" u 1:4 with linespoints title "error"\
	,f(x) with lines title "1/N fit";\
	'| tee log.error.gpi | gnuplot

Out.integral.png: Out.txt Makefile
	echo '\
	set terminal png background "white";\
	set out "$@";\
	set xlabel "N[number of sampling points]";\
	set ylabel "value of the integral";\
	set title "Quasi-random MC integral value as a function of N";\
	plot \
	 "$<" with linespoints title "MC integration"\
	,pi/4 with lines title "exact"\
	'| tee log.int.gpi | gnuplot

Out.txt: main.exe
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
	$(RM) *.exe *.dll *.log *.gpi [Oo]ut*