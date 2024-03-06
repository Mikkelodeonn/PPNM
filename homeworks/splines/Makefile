all: Out.spline.svg Out.int_spline.svg

Out.spline.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			plot \
					"$<" index 0 with points pointtype 6 notitle \
					,"$<" index 1 with lines notitle; \
		'| tee log.spline.gpi | gnuplot

Out.int_spline.svg:Out.txt Makefile
	echo '\
			set terminal svg background "white"; \
			set out "$@"; \
			plot \
					"$<" index 1 using 0:2 with lines notitle; \
		'| tee log.spline.gpi | gnuplot


Out.txt:main.exe
	mono $< > $@
	sed 's/,/./g' $@ > modified_$@ && mv modified_$@ $@

main.exe:main.cs spline.dll 
	mcs -target:exe -out:main.exe -reference:spline.dll main.cs 

spline.dll:spline.cs binary_search.cs
	mcs -target:library -out:spline.dll spline.cs binary_search.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*