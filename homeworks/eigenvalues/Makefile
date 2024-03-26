all: E0_dr.png E0_rmax.png psi.png

E0_dr.png:out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set yrange [-0.501:-0.487];\
			set xlabel "dr [bohr radius]";\
			set ylabel "energy [hartree]";\
			set title "eigenenergy of hydrogen (s-wave) as a function of dr";\
			plot\
					"$<" index 1 with linespoints pointtype 6 title "calculated" \
					,-0.5 with lines title "exact";\
		'| tee log.gpi | gnuplot

E0_rmax.png:out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set yrange [-0.55:-0.1];\
			set xlabel "rmax [bohr radius]";\
			set ylabel "energy [hartree]";\
			set title "eigenenergy of hydrogen (s-wave) as a function of rmax";\
			plot\
					"$<" index 2 with linespoints pointtype 6 title "calculated" \
					,-0.5 with lines title "exact";\
		'| tee log.gpi | gnuplot

psi.png:out.txt Makefile
	echo '\
			set terminal png background "white";\
			set out "$@";\
			set grid;\
			set xrange [-0.1:10];\
			set xlabel "r [bohr radius]";\
			set ylabel "f(r) [arbitrary units]";\
			set title "Hydrogen atom ground state radial s-wave";\
			plot\
					"$<" index 3 using 1:2 with points pointtype 7 pointsize 0.5 title "calculated"\
					,"$<" index 3 using 1:3 with lines title "exact";\
		' | tee log.gpi | gnuplot

out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs EVD.dll
	mcs -target:exe -out:main.exe -reference:EVD.dll main.cs

EVD.dll:EVD.cs matrix.cs vector.cs random.cs
	mcs -target:library -out:EVD.dll EVD.cs matrix.cs vector.cs random.cs

clean: 
	$(RM) *.exe *.dll *.png *.gpi [Oo]ut* 