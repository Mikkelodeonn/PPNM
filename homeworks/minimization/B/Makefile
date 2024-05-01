all: Out.higgs.png

Out.higgs.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set ylabel "signal [arb.u.]";\
			set xlabel "energy [GeV]";\
			set title "Higgs production signal";\
			plot\
				"$<" with lines title "Breit Wigner fit"\
				,"higgs.data.txt" using 1:2:3 with errorbars title "experimental data";\
		'|tee log.gpi|gnuplot

Out.txt: main.exe
	mono main.exe < higgs.data.txt 1> Out.txt 2> log
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs minimize.dll genlist.cs
	mcs -target:exe -out:main.exe -reference:minimize.dll main.cs genlist.cs

minimize.dll: ../A/minimize.cs ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs 
	mcs -target:library -out:minimize.dll $^

clean:
	$(RM) *.exe *.dll *.gpi [Oo]ut* log