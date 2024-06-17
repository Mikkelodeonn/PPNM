Out.linear_spline.png:Out.txt Makefile
	echo '\
			set terminal png background "white"; \
			set out "$@"; \
			set datafile separator " "; \
			set grid; \
			set xlabel "x"; \
			set ylabel "sin(x)";\
			set yrange [-1.5:3.5];\
			set title "Linear spline interpolation of sin(x)"; \
			plot \
					"$<" index 0 with points pointtype 6 title "Sin(x)" \
					,"$<" index 1 with points pointtype 6 title "integral of Sin(x)" \
					,"$<" index 2 skip 1 with lines title "Linear spline" \
					,"$<" index 3 skip 1 with lines title "Integral of linear spline"; \
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

