all: Out.txt Out.wave_func.png Out.convergence.max.png Out.convergence.min.png Out.acc.png Out.eps.png

Out.acc.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set out "$@";\
		set xlabel "acc parameter value";\
		set ylabel "energy [Hartree]";\
		set title "Convergence with respect to parameter acc";\
		set xrange [*:*] reverse;\
		plot\
			"$<" index 6 with points title "calculated"\
			,-0.5  with lines ls 2 lw 2 title "exact";\
	'| tee log.gpi | gnuplot

Out.eps.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set out "$@";\
		set xlabel "eps parameter value";\
		set ylabel "energy [Hartree]";\
		set title "Convergence with respect to parameter eps";\
		set xrange [*:*] reverse;\
		plot\
			"$<" index 5 with points title "calculated"\
			,-0.5  with lines ls 2 lw 2 title "exact";\
	'| tee log.gpi | gnuplot

Out.wave_func.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set output "$@";\
		set title "Found wave function for the lowest bound state of hydrogen";\
		set ylabel "wave function";\
		set xlabel "r [bohr radii]";\
		plot\
		"$<" index 2 with lines lw 6 lc "royalblue" title "exact"\
		,"$<" index 1 with lines lw 3 lc "dark-orange" title "calculated";\
		' | tee log.gpi | gnuplot

Out.convergence.min.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set output "$@";\
		set title "Convergence with respect to rmin";\
		set ylabel "energy [Hartree]";\
		set xlabel "rmin [bohr radii]";\
		set xrange [*:*] reverse;\
		set yrange [-1:-0.4];\
		plot\
			"$<" index 3 with points pt 13 title "calculated energy (rmax=8.0)"\
			, -0.5 with lines ls 2 lw 2 title "exact result";\
		' | tee log.gpi | gnuplot

Out.convergence.max.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set output "$@";\
		set title "Convergence with respect to rmax";\
		set ylabel "energy [Hartree]";\
		set xlabel "rmax [bohr radii]";\
		set xrange [1.5:8.5];\
		plot\
			"$<" index 4 with points pt 13 title "calculated energy (rmin=1e-4)"\
			, -0.5 with lines ls 2 lw 2 title "exact result";\
		' | tee log.gpi | gnuplot


Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs roots.dll
	mcs -target:exe -out:main.exe -reference:roots.dll main.cs

roots.dll: ../A/roots.cs RK.cs matrix.cs vector.cs qrgs.cs genlist.cs
	mcs -target:library -out:roots.dll $^

clean:
	$(RM) *.exe *.dll *.gpi *.png [Oo]ut*
