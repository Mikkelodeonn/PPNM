all: Out.E0_dr.png Out.E0_rmax.png Out.psi.png

Out.E0_dr.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set yrange [-0.501:-0.487];\
			set xlabel "dr [bohr radius]";\
			set ylabel "energy [hartree]";\
			set title "eigenenergy of hydrogen (s-wave) as a function of dr";\
			plot\
					"$<" index 0 skip 1 with linespoints pointtype 6 title "calculated" \
					,-0.5 with lines title "exact";\
		'| tee log.gpi | gnuplot

Out.E0_rmax.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set yrange [-0.55:-0.1];\
			set xlabel "rmax [bohr radius]";\
			set ylabel "energy [hartree]";\
			set title "eigenenergy of hydrogen (s-wave) as a function of rmax";\
			plot\
					"$<" index 1 with linespoints pointtype 6 title "calculated" \
					,-0.5 with lines title "exact";\
		'| tee log.gpi | gnuplot

Out.psi.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set xrange [-0.1:10];\
			set xlabel "r [bohr radius]";\
			set ylabel "f(r) [arbitrary units]";\
			set title "Hydrogen atom ground state radial wave function";\
			plot\
					"$<" index 2 using 1:2 with points pointtype 7 pointsize 0.5 title "calculated"\
					,"$<" index 2 using 1:3 with lines title "exact";\
		' | tee log.gpi | gnuplot

Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs EVD.dll
	mcs -target:exe -out:main.exe -reference:EVD.dll main.cs

EVD.dll:../A/EVD.cs ../A/matrix.cs ../A/vector.cs ../A/random.cs
	mcs -target:library -out:EVD.dll $^

clean: 
	$(RM) *.exe *.dll *.png *.gpi [Oo]ut* 