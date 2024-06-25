all: Out.lanczos+jacobi.png Out.lanczos+jacobi.tuned.png Out.runningtime.comparison.png

Out.lanczos+jacobi.png: Out.txt Makefile
	echo '\
		set terminal pngcairo size 2000,800 background "white";\
		set output "$@";\
		set multiplot layout 2,1;\
		\
		set size 0.5, 1;\
		set origin 0.5, 0;\
		set ylabel "y(n) [arb.u.]";\
		set xlabel "# of Lanczos iterations/dimension of T-matrix [n]";\
		set title "Lowest eigenvalue convergence of the reg. Jacobi algorithm on tridiag. matrix T as a function of n";\
		set x2label "for multiple arb. N-dimensional matrices   ( Note: y(n) = 1-(E_{0,T}(n) / E_{0}) )";\
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
		set title "Runningtime of the reg. Jacobi eigenvalue algorithm with/without tridiagonalization";\
		set x2label "for various # of Lanczos iterations n";\
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
			"$<" index 7 w lp lw 2 lc "dark-orange" title "reg. jacobi";\
		unset multiplot;\
	'| tee log.gpi | gnuplot

Out.lanczos+jacobi.tuned.png: Out.txt Makefile
	echo '\
		set terminal pngcairo size 2000,800 background "white";\
		set output "$@";\
		set multiplot layout 2,1;\
		\
		set size 0.5, 1;\
		set origin 0.5, 0;\
		set ylabel "y(n) [arb.u.]";\
		set xlabel "# of Lanczos iterations/dimension of T-matrix [n]";\
		set title "Lowest eigenvalue convergence of the tuned Jacobi algorithm on tridiag. matrix T as a function of n";\
		set x2label "for multiple arb. N-dimensional matrices ( Note: y(n) = 1-(E_{0,tuned}(n) / E_{0}) )";\
		set xrange [0:30];\
		set grid;\
		plot\
			"$<" index 9 w l lw 2 lc "dark-green" title "N = 10",\
			"$<" index 10 w l lw 2 lc "royalblue" title "N = 40",\
			"$<" index 11 w l lw 2 lc "goldenrod" title "N = 70",\
			"$<" index 12 w l lw 2 lc "dark-orange" title "N = 100";\
		\
		set ylabel "Running time [clock ticks]";\
		set xlabel "Dimension of initial matrix [N]";\
		set title "Runningtime of the regular/tuned Jacobi eigenvalue algorithm";\
		set x2label " on matrices A & T respectively, for various # of Lanczos iterations n";\
		set grid;\
		set size 0.5, 1;\
		set origin 0, 0;\
		set key left top;\
		set xrange [0:100];\
		plot\
			"$<" index 14 using 1:2 w lp lw 2 lc "web-blue" title "n/N = 1/5",\
			"$<" index 14 using 1:3 w lp lw 2 lc "royalblue" title "n/N = 2/5",\
			"$<" index 14 using 1:4 w lp lw 2 lc "blue" title "n/N = 3/5",\
			"$<" index 14 using 1:5 w lp lw 2 lc "dark-blue" title "n/N = 4/5",\
			"$<" index 15 w lp lw 2 lc "dark-orange" title "reg. jacobi";\
		unset multiplot;\
	'| tee log.gpi | gnuplot

Out.runningtime.comparison.png: Out.txt Makefile
	echo '\
			set terminal pngcairo size 1000,800 background "white";\
			set output "$@";\
			set ylabel "Running time [clock ticks]";\
			set xlabel "Dimension of initial matrix [N]";\
			set title "Running time comparison (reg. Jacobi on A and T + tuned Jacobi on T)";\
			set x2label "T: tridiag. matrix with n = (4/5)N	   A: real symmetric matrix of dim. N";\
			set grid;\
			set key top left;\
			f1(x) = a1*x*x*x;\
			f2(x) = a2*x*x*x;\
			f3(x) = a3*x*x;\
			fit f1(x) "$<" index 7 via a1;\
			fit f2(x) "$<" index 6 using 1:5 via a2;\
			fit f3(x) "$<" index 14 using 1:5 via a3;\
			plot\
				"$<" index 7 w p pt 3 lw 7 lc "purple" title "Reg. Jacobi on A",\
				"$<" index 6 using 1:5 w p pt 1 lw 4 lc "royalblue" title "Reg. Jacobi on T ",\
				"$<" index 14 using 1:5 w p pt 2 lw 4 lc "dark-orange" title "Tuned Jacobi on T",\
				f1(x) w l lw 2 lc "dark-green" notitle,\
				f2(x) w l lw 2 lc "dark-green" title "n^3 fit",\
				f3(x) w l lw 2 lc "orange" title "n^2 fit";\
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