all: Out.txt Out.rosenbrock.png Out.himmelblau.png

Out.rosenbrock.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set output "$@";\
		set title "Rosenbrock valley function";\
		set xlabel "x";\
		set ylabel "y";\
		set zlabel "z";\
		set xrange [-10:10];\
		set yrange [-10:10];\
		set zrange [-1:1e6];\
		splot\
			(1-x)**2 + 100*(y-x**2)**2 title "f(x,y) = (1-x)^2 + 100(y-x^2)^2"\
			,"$<" index 2 with points pt 7 title "found minimum (1,1)";\
		' | tee log.gpi | gnuplot

Out.himmelblau.png: Out.txt Makefile
	echo '\
		set terminal png background "white";\
		set output "$@";\
		set title "The Himmelblau function";\
		set xlabel "x";\
		set ylabel "y";\
		set zlabel "z";\
		set xrange [-10:10];\
		set yrange [-10:10];\
		set zrange [-1:3e4];\
		splot\
			(x**2+y-11)**2+(x+y**2-7)**2 title "f(x,y) = (x^2+y-11)^2+(x+y^2-7)^2"\
			,"$<" index 3 with points pt 7 title "found minimum (3,2)";\
		' | tee log.gpi | gnuplot

Out.txt: main.exe
	mono $< >$@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe: main.cs roots.dll
	mcs -target:exe -out:main.exe -reference:roots.dll main.cs

roots.dll: roots.cs qrgs.cs matrix.cs vector.cs 
	mcs -target:library -out:roots.dll roots.cs qrgs.cs matrix.cs vector.cs 

clean:
	$(RM) *.txt *.exe *.dll *.png *.gpi [Oo]ut*
