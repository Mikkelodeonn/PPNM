Out.times.png:Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set out "$@";\
		set ylabel "time [arb. u.]";\
		set xlabel "N [arb. u.]";\
		set title "Time elapsed during QR-decomp. of NxN matrix";\
		f(x) = a*x*x*x;\
		fit f(x) "Out.txt" via a;\
		plot\
				"$<" with points title "Data"\
				,f(x) title "n^3 fit";\
	'| tee log.gpi | gnuplot

Out.txt:main.exe
	mono $< > $@

matrix.dll: ../A/matrix.cs ../A/vector.cs
	mcs -target:library -out:matrix.dll $^

main.exe:main.cs matrix.dll 
	mcs -target:exe -out:main.exe -reference:matrix.dll main.cs ../A/qrgs.cs ../A/random.cs

clean:
	$(RM) *.exe *.dll [Oo]ut* *.log *.gpi