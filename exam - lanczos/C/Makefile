Out.jacobi+lanczos.png: Out.txt Makefile
	echo '\
		set terminal pngcairo size 2000,800 background "white";\
		set output "$@";\
		set multiplot layout 2,1;\
		\
		set size 0.5, 1;\
		set origin 0.5, 0;\
		set ylabel "y(n) [arb.u.]";\
		set xlabel "# of Lanczos iterations/dimension of T-matrix [n]";\
		set title "Convergence of Lanczos tuned Jacobi algorithm as a function of n for multiple input matrices (of dim. N)";\
		set x2label "( y(n) = 1-(E_{0,tuned} / E_{0,regular}) )";\
		set xrange [0:30];\
		set grid;\
		plot\
			"$<" index 1 w l lw 2 lc "dark-green" title "N = 10",\
			"$<" index 2 w l lw 2 lc "royalblue" title "N = 40",\
			"$<" index 3 w l lw 2 lc "goldenrod" title "N = 70",\
			"$<" index 4 w l lw 2 lc "dark-orange" title "N = 100";\
		\
		set ylabel "Running time [clock ticks]";\
		set xlabel "Dimension of input matrix [N]";\
		set title "Runningtime of the Jacobi eigenvalue algorithm with/without";\
		set x2label "tridiagonalization for various # of Lanczos iterations n";\
		set grid;\
		set size 0.5, 1;\
		set origin 0, 0;\
		set key left top;\
		set xrange [0:100];\
		plot\
			"$<" index 6 using 1:2 w lp lw 2 lc "web-blue" title "n/N = 1/5",\
			"$<" index 6 using 1:3 w lp lw 2 lc "royalblue" title "n/N = 2/5",\
			"$<" index 6 using 1:4 w lp lw 2 lc "blue" title "n/N = 3/5",\
			"$<" index 6 using 1:5 w lp lw 2 lc "dark-blue" title "n/N = 4/5",\
			"$<" index 7 w lp lw 2 lc "dark-orange" title "regular jacobi";\
		unset multiplot;\
	'| tee log.gpi | gnuplot

Out.txt:main.exe
	mono $< 1> $@ 2> log.txt
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

lanczos.dll: ../A/matrix.cs ../A/vector.cs ../A/qrgs.cs ../A/random.cs ../A/lanczos.cs EVD.cs
	mcs -target:library -out:lanczos.dll $^

main.exe:main.cs lanczos.dll 
	mcs -target:exe -out:main.exe -reference:lanczos.dll main.cs 

clean:
	$(RM) *.exe *.dll *.txt *.gpi [Oo]ut* 