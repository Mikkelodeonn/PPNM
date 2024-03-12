all: Out.linear_spline.svg Out.quadratic_spline.svg 

Out.linear_spline.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "sin(x)"; \
			set title "Linear spline interpolation of sin(x)"; \
			plot \
					"$<" index 0 with points pointtype 6 title "Sin(x)" \
					,"$<" index 1 with points pointtype 6 title "integral of Sin(x)" \
					,"$<" index 3 skip 1 with lines title "Linear spline" \
					,"$<" index 4 skip 1 with lines title "Integral of linear spline"; \
		'| tee log.spline.gpi | gnuplot

Out.quadratic_spline.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "sin(x)"; \
			set title "Quadratic spline interpolation of sin(x)"; \
			plot \
					"$<" index 0 with points pointtype 6 title "Sin(x)" \
					,"$<" index 1 with points pointtype 6 title "Integral of sin(x)" \
					,"$<" index 2 with points pointtype 6 title "Derivative of sin(x)" \
					,"$<" index 5 skip 1 with lines title "Quadratic spline" \
					,"$<" index 6 skip 1 with lines title "Integral of quadratic spline" \
					,"$<" index 7 skip 1 with lines title "Derivative of quadratic spline"; \
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

