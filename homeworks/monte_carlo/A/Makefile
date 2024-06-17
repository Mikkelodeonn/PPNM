all: Out.error.png Out.integral.png

Out.error.png: Out.txt Makefile
	echo '\
	set terminal png background "white";\
	set out "$@";\
	set title "Plain MC integration error (integral from homework)";\
	set xlabel "N[number of sampling points]";\
	set ylabel "error";\
	a=1; f(n) = a/sqrt(n);\
	fit f(x) "$<" using 1:4 via a;\
	plot \
	 "$<" u 1:3 with lines title "statistical estimate of the error"\
	,"$<" u 1:4 with linespoints title "error"\
	,f(x) with lines title "1/sqrt(n) fit"\
	'| tee log.error.gpi | gnuplot

Out.integral.png: Out.txt Makefile
	echo '\
	set terminal png background "white";\
	set out "$@";\
	set xlabel "N[number of sampling points]";\
	set ylabel "value of the integral";\
	set title "Plain MC integral value as a function of N (integral from homework)";\
	plot \
	 "$<" with linespoints title "MC integration"\
	,1.3932039296856768591842462603255 with lines title "exact"\
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