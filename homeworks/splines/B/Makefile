Out.quadratic_spline.png:Out.txt Makefile
	echo '\
			set terminal png background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "sin(x)"; \
			set yrange [-1.5:3.5]; \
			set title "Quadratic spline interpolation of sin(x)"; \
			plot \
					"$<" index 0 with points pointtype 6 title "Sin(x)" \
					,"$<" index 1 with points pointtype 6 title "Integral of sin(x)" \
					,"$<" index 2 with points pointtype 6 title "Derivative of sin(x)" \
					,"$<" index 3 with lines title "Quadratic spline" \
					,"$<" index 4 with lines title "Integral of quadratic spline" \
					,"$<" index 5 with lines title "Derivative of quadratic spline"; \
		'| tee log.spline.gpi | gnuplot

Out.txt:main.exe
	mono $< > $@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs spline.dll 
	mcs -target:exe -out:main.exe -reference:spline.dll main.cs 

spline.dll:../A/spline.cs ../A/binary_search.cs ../A/vector.cs ../A/matrix.cs
	mcs -target:library -out:spline.dll $^

clean:
	$(RM) *.exe *.dll *.svg *.gpi [Oo]ut*

