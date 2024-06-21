all: Out.E0_dr.png Out.E0_rmax.png Out.psi1.png Out.psi2.png

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
					"$<" index 4 with linespoints pointtype 6 title "calculated" \
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
					"$<" index 3 with linespoints pointtype 6 title "calculated" \
					,-0.5 with lines title "exact";\
		'| tee log.gpi | gnuplot

Out.psi1.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set xrange [-0.1:10];\
			set xlabel "r [bohr radius]";\
			set ylabel "f(r) [arbitrary units]";\
			set title "Hydrogen atom ground state radial wave function";\
			plot\
					"$<" index 1 skip 1 using 1:2 with points pointtype 7 pointsize 0.5 title "calculated"\
					,"$<" index 1 skip 1 using 1:3 with lines title "exact";\
		' | tee log.gpi | gnuplot

Out.psi2.png:Out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set xrange [-0.1:10];\
			set xlabel "r [bohr radius]";\
			set ylabel "f(r) [arbitrary units]";\
			set title "The 2nd & 3rd radial s-wave functions of the Hydrogen atom";\
			plot\
					"$<" index 2 skip 1 using 1:2 with points pointtype 7 pointsize 0.5 title "n = 2"\
					,"$<" index 3 skip 1 using 1:2 with points pointtype 7 pointsize 0.5 title "n = 3";\
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