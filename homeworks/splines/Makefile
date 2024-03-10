all: Out.linear_spline.svg Out.linear_integral.svg Out.quadratic_spline.svg Out.quadratic_integral.svg Out.quadratic_derivative.svg

Out.linear_spline.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "s [sin(x)]"; \
			set title "Linear spline interpolation of sin(x)"; \
			plot \
					"$<" index 0 with points pointtype 6 notitle \
					,"$<" index 3 skip 1 with lines notitle; \
		'| tee log.spline.gpi | gnuplot

Out.linear_integral.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "integral of linear spline"; \
			set title "Integral of linear spline interpolation of sin(x)"; \
			plot \
					"$<" index 1 with points pointtype 6 notitle \
					,"$<" index 4 skip 1 with lines notitle; \
		'| tee log.spline.gpi | gnuplot

Out.quadratic_spline.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "quadratic spline"; \
			set title "quadratic spline interpolation of sin(x)"; \
			plot \
					"$<" index 0 with points pointtype 6 notitle \
					,"$<" index 5 skip 1 with lines notitle; \
		'| tee log.spline.gpi | gnuplot

Out.quadratic_integral.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "integral of quadratic spline"; \
			set title "integral of quadratic spline interpolation of sin(x)"; \
			plot \
					"$<" index 1 with points pointtype 6 notitle \
					,"$<" index 6 skip 1 with lines notitle; \
		'| tee log.spline.gpi | gnuplot

Out.quadratic_derivative.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "derivative of quadratic spline"; \
			set title "derivative of quadratic spline interpolation of sin(x)"; \
			plot \
					"$<" index 2 with points pointtype 6 notitle \
					,"$<" index 7 skip 1 with lines notitle; \
		'| tee log.spline.gpi | gnuplot

Out.txt:main.exe
	mono $< > $@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs spline.dll 
	mcs -target:exe -out:main.exe -reference:spline.dll main.cs 

spline.dll:spline.cs binary_search.cs vector.cs matrix.cs
	mcs -target:library -out:spline.dll spline.cs binary_search.cs vector.cs matrix.cs

clean:
	$(RM) *.exe *.dll *.svg *.gpi [Oo]ut*